namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question2
    {
        public static int First(Collections.Stack<int> st, int num)
        {
            Collections.Stack<int> temp = new Collections.Stack<int>();
            int index = 0, current = 0;
            bool found = false;

            while (!st.IsEmpty() && !found)
            {
                index++;
                current = st.Pop();
                if (current == num)
                {
                    found = true;
                }
                temp.Push(current);
            }

            while (!temp.IsEmpty())
            {
                st.Push(temp.Pop());
            }

            return index;
        }

        public static int Last(Collections.Stack<int> st, int num)
        {
            Collections.Stack<int> temp = new Collections.Stack<int>();
            int i = -1, index = 0, x = 0;

            while (!st.IsEmpty())
            {
                index++;
                x = st.Pop();
                if (x == num)
                {
                    i = index;
                }
                temp.Push(x);
            }

            while (!temp.IsEmpty())
            {
                st.Push(temp.Pop());
            }

            return i;
        }

        public static void CopyStack(Collections.Stack<int> st, Collections.Stack<int> temp)
        {
            Collections.Stack<int> temp2 = new Collections.Stack<int>();
            while (!st.IsEmpty())
            {
                int x = st.Pop();
                temp.Push(x);
                temp2.Push(x);
            }
            while (!temp2.IsEmpty())
            {
                st.Push(temp2.Pop());
            }
        }

        public static int MaxDistance(Collections.Stack<int> st)
        {
            Collections.Stack<int> temp = new Collections.Stack<int>();
            CopyStack(st, temp);

            int x = temp.Pop();
            int max = Last(st, x) - First(st, x);
            int num = 0;

            while (!temp.IsEmpty())
            {
                x = temp.Pop();
                num = Last(st, x) - First(st, x);
                if (num > max)
                {
                    max = num;
                }
            }

            return max - 1;
        }

        public static void RunTest()
        {
            Collections.Stack<int> stack = new Collections.Stack<int>();
            stack.Push(6);
            stack.Push(6);
            stack.Push(9);
            stack.Push(3);
            stack.Push(2);
            stack.Push(2);
            stack.Push(10);
            stack.Push(3);
            stack.Push(9);
            stack.Push(7);
            stack.Push(10);
            stack.Push(7);
            Console.WriteLine(MaxDistance(stack));
        }
    }
}
