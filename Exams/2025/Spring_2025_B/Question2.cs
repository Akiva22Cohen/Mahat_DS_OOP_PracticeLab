namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question2
    {
        public static int Len(Collections.Queue<int> queue)
        {
            Collections.Queue<int> tmp = new Collections.Queue<int>();
            int count = 0;

            while (!queue.IsEmpty())
            {
                count++;
                tmp.Insert(queue.Remove());
            }

            while (!tmp.IsEmpty())
                queue.Insert(tmp.Remove());

            return count;
        }

        public static bool EqualSums(Collections.Queue<int> queue)
        {
            int len = Len(queue);
            if (len % 2 != 0)
                return false;

            Collections.Queue<int> firstHalf = new Collections.Queue<int>();
            Collections.Queue<int> secondHalf = new Collections.Queue<int>();
            Collections.Queue<int> restore = new Collections.Queue<int>();

            // נחלק את התור לשני חצאים
            for (int i = 0; i < len / 2; i++)
                firstHalf.Insert(queue.Remove());

            for (int i = 0; i < len / 2; i++)
                secondHalf.Insert(queue.Remove());

            // נהפוך את החצי השני
            // עושים זאת ע"י הכנסת כל איבר ל־queue והוצאתו מחדש לאחר שהאחרים מוכנסים
            for (int i = 0; i < len / 2; i++)
            {
                // מעבירים i איברים לתור עזר
                for (int j = 0; j < len / 2 - 1 - i; j++)
                    secondHalf.Insert(secondHalf.Remove());

                // שומרים את האיבר האחרון
                int x = secondHalf.Remove();

                // שמים אותו בתור המשוחזר
                restore.Insert(x);
            }

            bool isEqual = true;
            int expectedSum = -1;

            for (int i = 0; i < len / 2; i++)
            {
                int a = firstHalf.Remove();
                int b = restore.Remove();

                if (expectedSum == -1)
                    expectedSum = a + b;
                else if (a + b != expectedSum)
                    isEqual = false;

                // שיחזור התור המקורי
                queue.Insert(a);
                queue.Insert(b);
            }

            return isEqual;
        }

        public static bool EqualsSums(Collections.Queue<int> q)
        {
            Collections.Stack<int> s = new Collections.Stack<int>();
            int len = Len(q);

            if (len % 2 != 0) return false;

            for (int i = 0; i < len / 2; i++)
                s.Push(q.Remove());

            int needednumber = q.Head() + s.Top();
            int x, y;
            bool isEqual = true;

            while (!s.IsEmpty())
            {
                x = s.Pop();
                y = q.Remove();
                if (x + y != needednumber)
                    isEqual = false;
                q.Insert(y);
                q.Insert(x);
            }


            return isEqual;
        }

        public static void RunTest()
        {
            Collections.Queue<int> queue = new Collections.Queue<int>();
            queue.Insert(18);
            queue.Insert(3);
            queue.Insert(15);
            queue.Insert(13);
            queue.Insert(4);
            queue.Insert(21);
            queue.Insert(12);
            queue.Insert(10);
            queue.Insert(22);
            queue.Insert(7);

            Console.WriteLine("queue: " + queue);
            Console.WriteLine();
            Console.WriteLine("EqualSums => " + EqualsSums(queue));
            Console.WriteLine();
            Console.WriteLine("queue: " + queue);
        }
    }
}
