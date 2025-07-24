using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question12
    {
        public static int Zero(Node<int> ch)
        {
            if (ch == null) return 0;
            return 1 + Zero(ch.GetNext());
        }

        public static Node<int> One(Node<int> ch, int n)
        {
            if (ch == null) return null;
            if (n == 1) return ch;
            return One(ch.GetNext(), n - 1);
        }

        public static void Two(Node<int> ch, int n, int m)
        {
            if (n < m)
            {
                Node<int> p1 = One(ch, n);
                Node<int> p2 = One(ch, m);
                int temp = p1.GetValue();
                p1.SetValue(p2.GetValue());
                p2.SetValue(temp);
                Two(ch, n + 1, m - 1);
            }
        }

        public static void RunTest()
        {
            Node<int> ch1 = new Node<int>(10);
            Node<int> pos = ch1;
            pos.SetNext(new Node<int>(12));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(5));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(3));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(6));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(1));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(4));

            Console.WriteLine(ch1);
            Console.WriteLine();
            Console.WriteLine("Zero => " + Zero(ch1));
            Console.WriteLine();
            Console.WriteLine("One => " + One(ch1, 3));
            Console.WriteLine();
            Console.Write("Two => ");
            Two(ch1, 2, 6);
            Console.WriteLine(ch1);


            Node<int> ch2 = new Node<int>(1);
            pos = ch2;
            pos.SetNext(new Node<int>(2));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(3));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(4));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(5));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(6));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(7));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(8));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(9));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(10));

            Console.WriteLine();
            Console.WriteLine("ch2: " + ch2);
            int s = Zero(ch2);
            for (int i = 1; i <= s / 2; i++)
            {
                Two(ch2, i, s - i + 1);
            }
            Console.WriteLine("ch2: " + ch2);
                        
            for (int i = 1; i <= s / 2; i++)
            {
                Two(ch2, i, s - i + 1);
            }
            Console.WriteLine("ch2: " + ch2);
        }
    }
}
