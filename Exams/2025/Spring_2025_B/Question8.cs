using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question8
    {
        public static int GetSumOfStack(Collections.Stack<int> st)
        {
            Collections.Stack<int> tmp = new Collections.Stack<int>();
            int sum = 0, value;

            while (!st.IsEmpty())
            {
                value = st.Pop();
                sum += value;
                tmp.Push(value);
            }

            while (!tmp.IsEmpty())
                st.Push(tmp.Pop());

            return sum;
        }

        public static int GetStackLastValue(Collections.Stack<int> st)
        {
            Collections.Stack<int> tmp = new Collections.Stack<int>();
            int lastValue = 0;

            while (!st.IsEmpty())
            {
                lastValue = st.Pop();
                tmp.Push(lastValue);
            }

            while (!tmp.IsEmpty())
                st.Push(tmp.Pop());

            return lastValue;
        }

        public static int LenOfStack(Collections.Stack<int> stack)
        {
            Collections.Stack<int> temp = new Collections.Stack<int>();
            int length = 0;

            while (!stack.IsEmpty())
            {
                temp.Push(stack.Pop());
                length++;
            }

            while (!temp.IsEmpty())
                stack.Push(temp.Pop());
            
            return length;
        }

        public static Collections.Queue<int> DoIt(Node<Collections.Stack<int>> chain)
        {
            Node<Collections.Stack<int>> pos = chain;
            Collections.Stack<int> currentStack;
            Collections.Queue<int> resultQueue = new Collections.Queue<int>();
            int sum, lastValue, len;

            while (pos != null)
            {
                currentStack = pos.GetValue();
                len = LenOfStack(currentStack);

                if (len % 2 == 0) 
                {
                    sum = GetSumOfStack(currentStack);
                    resultQueue.Insert(sum);
                }
                else
                {
                    lastValue = GetStackLastValue(currentStack);
                    resultQueue.Insert(lastValue);
                }

                pos = pos.GetNext();
            }

            return resultQueue;
        }        

        public static void RunTest()
        {
            Collections.Stack<int> stack = new Collections.Stack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);
            stack.Push(20);
            stack.Push(25);
            int sum = GetSumOfStack(stack);
            Console.WriteLine($"The sum of the stack elements is: {sum}");

            int lastValue = GetStackLastValue(stack);
            Console.WriteLine($"The last value in the stack is: {lastValue}");
            
            Console.WriteLine("\n");
            Collections.Stack<int> stack1 = new Collections.Stack<int>();
            stack1.Push(2);
            stack1.Push(7);
            stack1.Push(4);
            stack1.Push(3);
            stack1.Push(1);
            stack1.Push(5);

            Collections.Stack<int> stack2 = new Collections.Stack<int>();
            stack2.Push(3);
            stack2.Push(1);
            stack2.Push(5);

            Collections.Stack<int> stack3 = new Collections.Stack<int>();
            stack3.Push(6);
            stack3.Push(5);
            stack3.Push(1);
            stack3.Push(3);

            Collections.Stack<int> stack4 = new Collections.Stack<int>();
            stack4.Push(7);
            stack4.Push(4);
            stack4.Push(4);
            stack4.Push(1);
            stack4.Push(2);

            Node<Collections.Stack<int>> chain = new Node<Collections.Stack<int>>(stack1);
            Node<Collections.Stack<int>> pos = chain;
            pos.SetNext(new Node<Collections.Stack<int>>(stack2));
            pos = pos.GetNext();
            pos.SetNext(new Node<Collections.Stack<int>>(stack3));
            pos = pos.GetNext();
            pos.SetNext(new Node<Collections.Stack<int>>(stack4));

            Console.WriteLine("chain: " + chain);
            Collections.Queue<int> resultQueue = DoIt(chain);
            Console.WriteLine("Result Queue: " + resultQueue);

        }
    }
}
