namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Question6
    {
        public static Collections.Queue<int> Clone(Collections.Queue<int> q)
        {
            Collections.Queue<int> temp = new Collections.Queue<int>();
            Collections.Queue<int> temp2 = new Collections.Queue<int>();

            int n;

            while (!q.IsEmpty())
            {
                n = q.Remove();
                temp.Insert(n);
                temp2.Insert(n);
            }

            while (!temp.IsEmpty())
            {
                n = temp.Remove();
                q.Insert(n);
            }

            return temp2;
        }

        public static int FirstPosition(Collections.Queue<int> q, int num)
        {
            Collections.Queue<int> temp = Clone(q);
            int position = 0, n;

            while (!temp.IsEmpty())
            {
                position++;
                n = temp.Remove();
                if (n == num)
                    return position;

            }

            return -1;
        }

        public static int LastPosition(Collections.Queue<int> q, int num)
        {
            Collections.Queue<int> temp = Clone(q);
            int position = 0, lastPosition = -1, n;
            while (!temp.IsEmpty())
            {
                position++;
                n = temp.Remove();
                if (n == num)
                    lastPosition = position;
            }
            return lastPosition;
        }

        public static bool IsDistanceK(Collections.Queue<int> q, int k)
        {
            Collections.Queue<int> temp = Clone(q);
            int first, last, num;

            while (!temp.IsEmpty())
            {
                num = temp.Remove();

                first = FirstPosition(q, num);
                last = LastPosition(q, num);

                if ((last - first - 1) == k)
                    return true;
            }

            return false;
        }

        public static void RunTest()
        {
            Collections.Queue<int> queue = new Collections.Queue<int>();
            queue.Insert(18);
            queue.Insert(3);
            queue.Insert(15);
            queue.Insert(13);
            queue.Insert(3);
            queue.Insert(12);
            queue.Insert(21);
            queue.Insert(12);
            queue.Insert(10);
            queue.Insert(3);
            queue.Insert(7);

            Console.WriteLine("Queue before cloning:");
            Console.WriteLine(queue);
            Collections.Queue<int> clonedQueue = Clone(queue);
            Console.WriteLine("Cloned Queue:");
            Console.WriteLine(clonedQueue);

            int numToFind = 3;
            int position = FirstPosition(queue, numToFind);
            if (position != -1)
            {
                Console.WriteLine($"The first position of {numToFind} in the queue is: {position}");
            }
            else
            {
                Console.WriteLine($"{numToFind} is not found in the queue.");
            }

            int lastPosition = LastPosition(queue, numToFind);
            if (lastPosition != -1)
            {
                Console.WriteLine($"The last position of {numToFind} in the queue is: {lastPosition}");
            }
            else
            {
                Console.WriteLine($"{numToFind} is not found in the queue.");
            }

            while (!queue.IsEmpty())
                queue.Remove();

            queue.Insert(4);
            queue.Insert(8);
            queue.Insert(2);
            queue.Insert(11);
            queue.Insert(4);
            queue.Insert(11);
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(8);
            queue.Insert(1);

            Console.WriteLine();
            Console.WriteLine("Queue after inserting new elements:");
            Console.WriteLine(queue);
            int k = 3;

            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine();
                if (IsDistanceK(queue, i))
                {
                    Console.WriteLine($"There are two elements in the queue with a distance of {i}.");
                }
                else
                {
                    Console.WriteLine($"There are no two elements in the queue with a distance of {i}.");
                }
                Console.WriteLine();
            }            
        }
    }
}
