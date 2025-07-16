using Mahat_DS_OOP_PracticeLab.Collections;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Question3
    {
        // ומספר ומחזירה את מספר המופעים של המספר ברשימה (Node) פעולה המקבלת רשימה
        public static int Count(Node<int> lst, int num)
        {
            Node<int> pos = lst;  // משתנה עזר המכיל את המיקום התורן ברשימה
            int count = 0;
            while (pos != null)
            {
                if (pos.GetValue() == num)
                    count++;
                pos = pos.GetNext();
            }
            return count;
        }

        public static bool PerfectList(Node<int> chain)
        {
            Node<int> pos = chain;  // משתנה עזר המכיל את המיקום התורן ברשימה
            
            while (pos != null)
            {
                if (pos.GetValue() > 0)
                {
                    if (Count(chain, pos.GetValue()) % 2 != 0)
                    {
                        return false;  
                    }
                }
                else
                {
                    if (Count(chain, pos.GetValue()) % 2 == 0)
                    {
                        return false;  
                    }
                }
                pos = pos.GetNext();
            }

            return true;  // אם הגענו לכאן, הרשימה מושלמת
        }

        public static void RunTest()
        {
            Node<int> chain = new Node<int>(2, new Node<int>(2, new Node<int>(3, new Node<int>(3, new Node<int>(-3)))));
            Console.WriteLine("Is the list perfect? " + PerfectList(chain));
            Node<int> chain2 = new Node<int>(-1, new Node<int>(2, new Node<int>(-3, new Node<int>(2))));
            Console.WriteLine("Is the list perfect? " + PerfectList(chain2));
        }
    }
}
