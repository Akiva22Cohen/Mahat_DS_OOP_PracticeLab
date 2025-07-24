namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question1
    {
        public static bool Tmp(Collections.Stack<int> stack)
        {
            if (stack == null) return true;
            Collections.Stack<int> tmp = new Collections.Stack<int>();

            int current, next, max, min;
            while (!stack.IsEmpty())
            {
                current = stack.Pop();

                while (!stack.IsEmpty())
                {
                    next = stack.Pop();
                    max = Math.Max(current, next);
                    min = Math.Min(current, next);

                    if (min != 0 && max % min == 0)
                        return false;

                    tmp.Push(next);
                }

                while (!tmp.IsEmpty())
                    stack.Push(tmp.Pop());
            }

            return true;
        }       

        public static void RunTest()
        {
            Random rnd = new Random();
            Collections.Stack<int> stack = new Collections.Stack<int>();
            int len, num, count = 0;

            do
            {
                while (!stack.IsEmpty())
                    stack.Pop();

                len = rnd.Next(4, 11);
                Console.WriteLine("len: " + len);

                for (int i = 0; i < len; i++)
                {
                    num = rnd.Next(1, 11);
                    stack.Push(num);
                }
                count++;
                Console.WriteLine("stack: " + stack);
                Console.WriteLine();

            } while (!Tmp(stack));
            Console.WriteLine("count: " + count);
        }
    }
}
