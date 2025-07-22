namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class SetOfNumbers
    {
        Collections.Stack<int> stack = new Collections.Stack<int>();

        //public SetOfNumbers()
        //{

        //}

        public void AddToSet(int num)
        {
            Collections.Stack<int> tmp = new Collections.Stack<int>();
            bool flag = false;
            int x;

            while (!IsEmpty() && !flag)
            {
                x = stack.Pop();
                if (x == num)
                    flag = true;
                tmp.Push(x);
            }

            while (!tmp.IsEmpty())
                stack.Push(tmp.Pop());

            if (!flag)
                stack.Push(num);
        }

        public int RemoveRandom()
        {
            Random rnd = new Random();
            int i = rnd.Next();
            return stack.Pop();
        }

        public bool IsEmpty()
        {
            return stack.IsEmpty();
        }

        public int SizeOfSet()
        {
            if (IsEmpty())
                return 0;
            int num = RemoveRandom();
            int size = SizeOfSet() + 1;
            AddToSet(num);
            return size;
        }

        public int RemoveMin()
        {
            int[] arr = new int[SizeOfSet()];
            int min = RemoveRandom();
            int num;

            for (int i = 0; !IsEmpty(); i++)
            {
                num = RemoveRandom();
                if (num < min)
                    min = num;

                arr[i] = num;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > min)
                    AddToSet(arr[i]);
            }

            return min;
        }
    }
    public class Question8
    {
        public static bool Bigger(SetOfNumbers sn1, SetOfNumbers sn2)
        {
            int minSn1 = sn1.RemoveMin(); // מוציא את הערך הכי קטן מ sn1
            sn1.AddToSet(minSn1); // מחזיר אותו בחזרה כדי לשמור על הקבוצה
            bool flag = true; // בדיקה אם הערך הכי נמוך ב sn1 גדול מכל הערכים של sn2

            int numSn2; // שמירת ערך מ sn2
            int[] arrSn2 = new int[sn2.SizeOfSet()]; // שמירת ערכים של sn2

            for (int i = 0; i < arrSn2.Length; i++)
            {
                numSn2 = sn2.RemoveRandom(); // מוציא ערך רנדומלי מ sn2 ושומר 
                if (minSn1 < numSn2) // בדיקה האם הערך הכי נמוך של sn1 קטן מהערך הרנדומלי שהוציאתי
                    flag = false;
                arrSn2[i] = numSn2;
            }

            for (int i = 0; i < arrSn2.Length; i++)
                sn2.AddToSet(arrSn2[i]);

            return flag;
        }

        public static void RunTest()
        {
            SetOfNumbers setOfNumbers = new SetOfNumbers();

            setOfNumbers.AddToSet(5); // 1
            setOfNumbers.AddToSet(7); // 2
            setOfNumbers.AddToSet(9); // 3
            setOfNumbers.AddToSet(15); // 4
            setOfNumbers.AddToSet(32); // 5
            setOfNumbers.AddToSet(5);
            setOfNumbers.AddToSet(2); // 6
            setOfNumbers.AddToSet(1); // 7
            setOfNumbers.AddToSet(32);
            
            SetOfNumbers setOfNumbers2 = new SetOfNumbers();

            setOfNumbers2.AddToSet(-5); // 1
            setOfNumbers2.AddToSet(-7); // 2
            setOfNumbers2.AddToSet(-9); // 3
            setOfNumbers2.AddToSet(-15); // 4
            setOfNumbers2.AddToSet(-32); // 5
            setOfNumbers2.AddToSet(-5);
            setOfNumbers2.AddToSet(-2); // 6
            setOfNumbers2.AddToSet(-0); // 7
            setOfNumbers2.AddToSet(-32);

            int minSn1 = setOfNumbers.RemoveMin();
            setOfNumbers.AddToSet(minSn1);

            int minSn2 = setOfNumbers2.RemoveMin();
            setOfNumbers2.AddToSet(minSn2);

            //Console.WriteLine("SizeOfSet => " + setOfNumbers.SizeOfSet());
            //Console.WriteLine();
            //Console.WriteLine("RemoveMin => " + setOfNumbers.RemoveMin());
            Console.WriteLine();
            Console.WriteLine("SizeOfSet => " + setOfNumbers.SizeOfSet());
            Console.WriteLine("SizeOfSet2 => " + setOfNumbers2.SizeOfSet());
            Console.WriteLine();
            Console.WriteLine("minSn1: " + minSn1);
            Console.WriteLine("minSn2: " + minSn2);
            Console.WriteLine();
            Console.WriteLine("Bigger => " + Bigger(setOfNumbers, setOfNumbers2));
            Console.WriteLine();
            Console.WriteLine("SizeOfSet => " + setOfNumbers.SizeOfSet());
            Console.WriteLine("SizeOfSet2 => " + setOfNumbers2.SizeOfSet());
        }
    }
}
