namespace Mahat_DS_OOP_PracticeLab.Collections
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        //-----------------------------------
        //constructor
        public Queue()
        {
            this.first = null;
            this.last = null;
        }
        //-----------------------------------
        //adds element x to the end of the queue
        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (first == null)
                first = temp;
            else
                last.SetNext(temp);
            last = temp;
        }
        //-----------------------------------
        //removes & returns the element from the head of the queue
        public T Remove()
        {
            if (IsEmpty())
                return default(T);
            T x = first.GetValue();
            first = first.GetNext();
            if (first == null)
                last = null;
            return x;
        }
        //-----------------------------------
        //returns the element from the head of the queue
        public T Head()
        {
            return first.GetValue();
        }
        //-----------------------------------
        //returns true if there are no elements in queue
        public bool IsEmpty()
        {
            return first == null;
        }
        //-------------------------------------
        //ToString
        public override string ToString()
        {
            if (this.IsEmpty())
                return "[]";

            Node<T> temp = first;

            string st = "[";
            while (temp != null)
            {
                st += temp.GetValue();
                if (temp.HasNext())
                    st += ", ";
                temp = temp.GetNext();
            }
            st += "]";

            return "QueueHead" + st;
        }
    }
}