namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question6
    {
        public static bool FindNumber(Collections.Queue<int> q, int n)
        {
            Collections.Queue<int> temp = new Collections.Queue<int>();

            bool found = false;
            int current;

            while (!q.IsEmpty())
            {
                current = q.Remove();
                if (current == n)
                {
                    found = true;
                }
                temp.Insert(current);
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return found;
        }

        public static bool IsPerfectN(Collections.Queue<int> q, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (!FindNumber(q, i))
                    return false;
            }

            return true;
        }

        public static void DoItSuper(Collections.Queue<int> q, int n)
        {
            Collections.Queue<int> temp = new Collections.Queue<int>();
            int current;
            int i;

            while (!q.IsEmpty())
            {
                current = q.Remove();
                if (current <= n)
                {
                    temp.Insert(current);
                }
            }

            for (i = 1; i <= n; i++)
            {
                if (!FindNumber(temp, i))
                {
                    temp.Insert(i);
                }
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }

        public static void RunTest()
        {
            Collections.Queue<int> q = new Collections.Queue<int>();
            q.Insert(4);
            q.Insert(5);
            q.Insert(3);
            q.Insert(15);
            q.Insert(2);
            q.Insert(4);
            q.Insert(1);
            q.Insert(7);

            Console.WriteLine("Original Queue: " + q.ToString());
            int n = 5;
            Console.WriteLine("Is Perfect N (1 to " + n + "): " + IsPerfectN(q, n));
            n = 7;
            Console.WriteLine("Is Perfect N (1 to " + n + "): " + IsPerfectN(q, n));
            n = 9;
            DoItSuper(q, n);
            Console.WriteLine("Modified Queue after DoItSuper with n = " + n + ": " + q.ToString());
        }
    }
}
