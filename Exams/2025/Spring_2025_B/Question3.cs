using Mahat_DS_OOP_PracticeLab.Collections;
using System.Xml.Linq;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question3
    {
        public static int Count(Node<int> node, int num)
        {
            Node<int> pos = node;
            int count = 0, n;

            while (pos != null)
            {
                n = pos.GetValue();
                if(n == num)
                    count++;
                pos = pos.GetNext();
            }

            return count;
        }

        public static bool PerfectListK(Node<int> chain, int k)
        {
            Node<int> pos = chain;
            int num;

            while (pos != null)
            {
                num = pos.GetValue();
                if (Count(chain, num) != k) 
                    return false;

                pos = pos.GetNext();
            }

            return true;
        }

        public static void RunTest()
        {
            //Random rnd = new Random();
            //int len, num, k, count = 0;
            //Node<int> node;
            //Node<int> pos;

            //do
            //{
            //    num = rnd.Next(11);
            //    node = new Node<int>(num);
            //    pos = node;
            //    len = rnd.Next(6, 16);

            //    for (int i = 0; i < len; i++)
            //    {
            //        num = rnd.Next(11);
            //        pos.SetNext(new Node<int>(num));
            //        pos = pos.GetNext();
            //    }

            //    k = rnd.Next(3, len / 2);
            //    count++;

            //    Console.WriteLine("len: " + len);
            //    Console.WriteLine("k: " + k);
            //    Console.WriteLine("node: " + node);
            //    Console.WriteLine();
            //} while (!PerfectListK(node, k));

            //Console.WriteLine("count: " + count);

            Node<int> node = new Node<int>(3);
            Node<int> pos = node;
            pos.SetNext(new Node<int>(3));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(3));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(3));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(5));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(5));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(5));
            pos = pos.GetNext();
            pos.SetNext(new Node<int>(5));
            pos = pos.GetNext();

            int k = 4;

            Console.WriteLine("k: " + k);
            Console.WriteLine("node: " + node);
            Console.WriteLine();
            Console.WriteLine("PerfectListK => " + PerfectListK(node, k));
            Console.WriteLine();
            Console.WriteLine("node: " + node);
        }
    }
}
