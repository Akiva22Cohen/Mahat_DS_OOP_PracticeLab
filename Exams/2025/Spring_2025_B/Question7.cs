using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question7
    {
        public static int GetSum(Node<int> p1, Node<int> p2)
        {
            Node<int> pos = p1;
            int sum = 0;

            while (pos != p2)
            {
                sum += pos.GetValue();
                pos = pos.GetNext();
            }
            sum += pos.GetValue(); // Include the value of p2 as well
            return sum;
        }

        public static bool IsAmount(Node<int> ch, int num)
        {
            Node<int> pos = ch;
            Node<int> pos2;
            int sum;

            while (pos != null)
            {
                pos2 = pos.GetNext();
                while (pos2 != null)
                {
                    sum = GetSum(pos, pos2);
                    if (sum == num)
                    {
                        return true; // Found a pair with the required sum
                    }
                    pos2 = pos2.GetNext();
                }
                pos = pos.GetNext();
            }

            return false; // No such pair found
        }

        public static void RunTest()
        {
            Node<int> node = new Node<int>(10);
            Node<int> pos = node;
            pos.SetNext(new Node<int>(14));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(6));
            pos = pos.GetNext();
            Node<int> p1 = pos;
            pos.SetNext(new Node<int>(4));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(10));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(3));
            pos = pos.GetNext();
            Node<int> p2 = pos;
            pos.SetNext(new Node<int>(14));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(14));
            pos = pos.GetNext();

            Console.WriteLine("node: " + node);
            Console.WriteLine("p1: " + p1);
            Console.WriteLine("p2: " + p2);

            int sum = GetSum(p1, p2);
            Console.WriteLine($"The sum of the values from p1 to p2 is: {sum}");

            int numToFind = 26;
            bool found = IsAmount(node, numToFind);
            if (found)
            {
                Console.WriteLine($"There is a pair of nodes in the list that sums to {numToFind}.");
            }
            else
            {
                Console.WriteLine($"No pair of nodes in the list sums to {numToFind}.");
            }
        }
    }
}
