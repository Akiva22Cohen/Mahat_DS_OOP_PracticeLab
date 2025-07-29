using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.GeneralPracticeDrafts
{
    public class Class1
    {
        public static int Height(BinNode<int> t)
        {
            if (t == null)
                return 0;
            return 1 +
                   Math.Max(Height(t.GetLeft()), Height(t.GetRight()));
        }

        public static void RunTest()
        {
            Random rnd = new Random();
            BinNode<int> b1 = new BinNode<int>(new BinNode<int>(rnd.Next(1, 101)), rnd.Next(1, 101), new BinNode<int>(rnd.Next(1, 101)));
            BinNode<int> b2 = new BinNode<int>(new BinNode<int>(rnd.Next(1, 101)), rnd.Next(1, 101), new BinNode<int>(rnd.Next(1, 101)));
            BinNode<int> root = new BinNode<int>(b1, rnd.Next(1, 101), b2);

            Console.WriteLine("Tree Height: " + Height(root));
        }
    }
}
