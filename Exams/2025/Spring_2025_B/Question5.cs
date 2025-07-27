namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question5
    {
        public static void What(Collections.Stack<int> st, bool flag)
        {
            int x, y;
            bool found;
            Collections.Stack<int> temp1 = new Collections.Stack<int>();
            Collections.Stack<int> temp2 = new Collections.Stack<int>();
            while (!st.IsEmpty())
            {
                x = st.Pop();
                found = false;
                while (!st.IsEmpty())
                {
                    y = st.Pop();
                    if (x > y == flag)
                        found = true;
                    temp1.Push(y);
                }
                while (!temp1.IsEmpty())
                    st.Push(temp1.Pop());
                if (!found)
                    temp2.Push(x);
            }
            while (!temp2.IsEmpty())
                st.Push(temp2.Pop());
        }


        public static void RunTest()
        {
            Collections.Stack<int> stack = new Collections.Stack<int>();
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            //stack.Push(2);
            //stack.Push(9);
            //stack.Push(8);

            Console.WriteLine("Stack before calling What:");
            Console.WriteLine(stack);
            What(stack, false);
            Console.WriteLine("Stack after calling What with flag true:");
            Console.WriteLine(stack);


        }
    }
}
