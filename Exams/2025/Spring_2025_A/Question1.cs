namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question1
    {
        public static Collections.Queue<int> OrderQ(Collections.Queue<int> st)
        {
            Collections.Queue<int> result = new Collections.Queue<int>();
            Collections.Queue<int> temp = new Collections.Queue<int>();

            while (!st.IsEmpty())
            {
                int curr = st.Remove();
                result.Insert(curr);

                // מעבירים את שאר האיברים, אלו ששונים חוזרים ל־st, זהים מצטרפים מייד לתוצאה
                while (!st.IsEmpty())
                {
                    int x = st.Remove();
                    if (x == curr)
                        result.Insert(x);
                    else
                        temp.Insert(x);
                }

                // החזרת כל השונים ל־st לסיבוב הבא
                while (!temp.IsEmpty())
                    st.Insert(temp.Remove());
            }
            return result;
        }


        public static void RunTest()
        {
            Collections.Queue<int> queue = new Collections.Queue<int>();
            queue.Insert(3);
            queue.Insert(10);
            queue.Insert(2);
            queue.Insert(2);
            queue.Insert(3);
            queue.Insert(7);
            queue.Insert(10);
            queue.Insert(2);
            queue.Insert(10);

            Console.WriteLine(OrderQ(queue).ToString());
        }
    }
}
