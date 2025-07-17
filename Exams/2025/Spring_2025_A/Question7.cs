namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question7
    {
        public static void CopyStack(Collections.Stack<int> stack, Collections.Stack<int> stack2)
        {
            Collections.Stack<int> temp = new Collections.Stack<int>();

            while (!stack.IsEmpty())
            {
                temp.Push(stack.Pop());
            }

            while (!temp.IsEmpty())
            {
                stack.Push(temp.Top());
                stack2.Push(temp.Pop());
            }
        }

        public static bool ExistSum(Collections.Stack<int> s, int num)
        {
            Collections.Stack<int> temp = new Collections.Stack<int>();
            Collections.Stack<int> temp2 = new Collections.Stack<int>();
            CopyStack(s, temp);
            CopyStack(s, temp2);

            int current, next, sum = 0;
            bool flag = false;

            while (!temp.IsEmpty() && !flag)
            {
                current = temp.Pop();
                while (!temp2.IsEmpty() && !flag)
                {
                    next = temp2.Pop();
                    sum = current + next;
                    if (sum == num)
                    {
                        return true;
                    }
                }
                CopyStack(temp, temp2);
            }

            return false;
        }

        public static int MaxSum(Collections.Stack<int> s)
        {
            Collections.Stack<int> stack = new Collections.Stack<int>();
            int x = s.Pop();
            stack.Push(x);

            int y = s.Pop();
            stack.Push(y);

            int max = Math.Max(x, y);
            int second = Math.Min(x, y);
            int num;

            while (!s.IsEmpty())
            {
                num = s.Pop();
                if (num > max)
                {
                    second = max;
                    max = num;
                }
                else if (num > second)
                {
                    second = num;
                }
                stack.Push(num);
            }

            while (!stack.IsEmpty())
                s.Push(stack.Pop());

            return max + second;
        }


        public static void RunTest()
        {
            Collections.Stack<int> stack = new Collections.Stack<int>();
            stack.Push(3);
            stack.Push(16);
            stack.Push(9);
            stack.Push(3);
            stack.Push(2);
            stack.Push(2);
            stack.Push(1);
            stack.Push(3);
            stack.Push(13);
            stack.Push(7);
            stack.Push(10);
            stack.Push(7);

            int num = 22;

            Console.WriteLine("stack: " + stack.ToString());
            //Console.WriteLine("num = " + num);
            Console.WriteLine();

            //Console.WriteLine("ExistSum: " + ExistSum(stack, num));

            Console.WriteLine("MaxSum => " + MaxSum(stack));

            Console.WriteLine("stack: " + stack.ToString());
        }
    }
}
