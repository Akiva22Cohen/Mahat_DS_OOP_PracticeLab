using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question12
    {
        public static int One(Node<int> ch, int num)
        {
            if (ch.GetNext() != null)
            {
                if (ch.GetNext().GetValue() == num)
                {
                    ch.SetNext(ch.GetNext().GetNext());
                    return 1 + One(ch, num);
                }
                else
                {
                    ch = ch.GetNext();
                    return One(ch, num);
                }
            }
            else
                return 0;
        }
        public static void Two(Node<int> ch)
        {
            if (ch != null)
            {
                int x = One(ch, ch.GetValue());
                ch.SetNext(new Node<int>(x + 1, ch.GetNext()));
                ch = ch.GetNext();
                Two(ch.GetNext());
            }
        }

        public static void RunTest()
        {
            Node<int> node = new Node<int>(10);
            Node<int> pos = node;
            pos.SetNext(new Node<int>(14));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(12));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(12));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(10));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(12));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(14));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(14));
            pos = pos.GetNext();

            Console.WriteLine("node: " + node);
            Two(node);
            Console.WriteLine("node after Two: " + node);
        }
    }
}
