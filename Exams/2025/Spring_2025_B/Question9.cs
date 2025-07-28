using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question9
    {
        public static void Mystery(BinNode<int> bt)
        {
            Mystery(bt, "");
        }
        private static void Mystery(BinNode<int> bt, string st)
        {
            st = st + " " + bt.GetValue();
            if (bt.GetLeft() == null && bt.GetRight() == null)
            {
                Console.WriteLine(st);
            }
            else
            {
                if (bt.GetLeft() != null)
                    Mystery(bt.GetLeft(), st);
                if (bt.GetRight() != null)
                    Mystery(bt.GetRight(), st);
            }
        }

        public static void RunTest()
        {
            BinNode<int> b1 = new BinNode<int>(null, 1, new BinNode<int>(3));
            BinNode<int> b2 = new BinNode<int>(b1, 6, null);

            BinNode<int> b3 = new BinNode<int>(new BinNode<int>(1), 17, null);
            BinNode<int> b4 = new BinNode<int>(b3, 20, new BinNode<int>(13));

            BinNode<int> root = new BinNode<int>(b2, 18, b4);

            Console.WriteLine("root: " + root);
            Console.WriteLine("Mystery function output:");
            Mystery(root);
            Console.WriteLine();

            b1 = new BinNode<int>(new BinNode<int>(30), 40, null);
            b2 = new BinNode<int>(b1, 50, new BinNode<int>(60));
            b3 = new BinNode<int>(b2, 20, null);

            b4 = new BinNode<int>(null, 100, new BinNode<int>(120));

            root = new BinNode<int>(b3, 70, b4);
            Console.WriteLine("\nNew root: " + root);
            Console.WriteLine("Mystery function output for new tree:");
            Mystery(root);

            b1 = new BinNode<int>(new BinNode<int>(30), 40, null);
            b2 = new BinNode<int>(b1, 50, new BinNode<int>(60));
            b3 = new BinNode<int>(null, 20, b2);

            b4 = new BinNode<int>(null, 100, new BinNode<int>(120));

            root = new BinNode<int>(b3, 70, b4);
            Console.WriteLine("\nAnother new root: " + root);
            Console.WriteLine("Mystery function output for another new tree:");
            Mystery(root);
        }
    }
}
