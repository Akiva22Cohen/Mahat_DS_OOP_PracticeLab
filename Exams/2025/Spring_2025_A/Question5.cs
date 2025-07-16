namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question5
    {
        public static void What(Collections.Queue<int> q)
        {
            int num1, num2;
            bool found;
            Collections.Queue<int> temp1 = new Collections.Queue<int>();
            Collections.Queue<int> temp2 = new Collections.Queue<int>();
            while (!q.IsEmpty())
            {
                num1 = q.Remove();
                found = false;
                while (!q.IsEmpty())
                {
                    num2 = q.Remove();
                    if (num1 == num2)
                        found = true;
                    temp1.Insert(num2);
                }
                while (!temp1.IsEmpty())
                    q.Insert(temp1.Remove());
                if (!found)
                    temp2.Insert(num1);
            }
            while (!temp2.IsEmpty())
                q.Insert(temp2.Remove());
        }

        public static void RunTest()
        {
            Collections.Queue<int> q = new Collections.Queue<int>();
            q.Insert(3);
            q.Insert(7);
            q.Insert(5);
            q.Insert(5);
            q.Insert(2);
            q.Insert(8);
            q.Insert(5);
            Console.WriteLine("Original Queue: " + q.ToString());
            What(q);
            Console.WriteLine("Modified Queue: " + q.ToString());

            Console.WriteLine();
            Collections.Queue<int> q2 = new Collections.Queue<int>();
            q2.Insert(3);
            q2.Insert(7);
            q2.Insert(2);
            q2.Insert(8);
            q2.Insert(5);
            Console.WriteLine("Original Queue2: " + q2.ToString());
            What(q2);
            Console.WriteLine("Modified Queue2: " + q2.ToString());
            
            Console.WriteLine();
            Collections.Queue<int> q3 = new Collections.Queue<int>();
            q3.Insert(3);
            q3.Insert(3);
            q3.Insert(3);
            q3.Insert(3);
            q3.Insert(3);
            Console.WriteLine("Original Queue2: " + q3.ToString());
            What(q3);
            Console.WriteLine("Modified Queue2: " + q3.ToString());
        }
    }
}
