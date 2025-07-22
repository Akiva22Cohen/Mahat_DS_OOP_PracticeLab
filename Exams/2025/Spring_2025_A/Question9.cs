using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question9
    {
        public static bool What(BinNode<int> bt, int num, int count)
        {
            if (bt == null) return false;
            if (num < 1 || count < 1) return false;
            if (bt.GetLeft() == null && bt.GetRight() == null)
            {
                return bt.GetValue() == num && count == 1;
            }
            return What(bt.GetLeft(), num - bt.GetValue(), count - 1) ||
            What(bt.GetRight(), num - bt.GetValue(), count - 1);
        }

        public static void RunTest()
        {
            BinNode<int> b1 = new BinNode<int>(null, 7, new BinNode<int>(6));
            BinNode<int> b2 = new BinNode<int>(new BinNode<int>(1), 1, b1);

            BinNode<int> b3 = new BinNode<int>(new BinNode<int>(6), 2, null);
            BinNode<int> b4 = new BinNode<int>(b3, 2, new BinNode<int>(3));
            BinNode<int> b5 = new BinNode<int>(null, 5, b4);

            BinNode<int> b6 = new BinNode<int>(b2, 7, b5);

            Console.WriteLine(b6);
            Console.WriteLine($"What({16}, {4}) => " + What(b6, 16, 4)); // false
            Console.WriteLine();
            Console.WriteLine($"What({9}, {3}) => " + What(b6, 9, 3)); // true

            // אחד התנאים כדי שיחזיר 'אמת' הוא שהעץ צריך להיות עלה,
            // והעלים בדוגמה שלנו נמצאים בשכבות 3, 4, 5.
            // ולכן כאונט צריך להיות שונה ממספר השכבות הנ''ל, כדי שיחזיר 'שקר'.

            BinNode<int> b7 = new BinNode<int>(null, 1, new BinNode<int>(1));
            BinNode<int> b8 = new BinNode<int>(new BinNode<int>(1), 1, b7);
            BinNode<int> b9 = new BinNode<int>(new BinNode<int>(1), 1, b8);

            Console.WriteLine();
            Console.WriteLine($"What({2}, {2}) => " + What(b9, 2, 2));
            Console.WriteLine();
            Console.WriteLine($"What({3}, {3}) => " + What(b9, 3, 3));
            Console.WriteLine();
            Console.WriteLine($"What({4}, {4}) => " + What(b9, 4, 4));
        }
    }
}
