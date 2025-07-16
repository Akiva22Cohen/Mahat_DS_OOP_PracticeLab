namespace Mahat_DS_OOP_PracticeLab.Collections
{
    public class Stack<T>
    {
        private Node<T> head;

        //-----------------------------------
        //constructor
        public Stack()
        {
            this.head = null;
        }
        //-----------------------------------
        //adds element x to the top of the stack
        public void Push(T x)
        {
            Node<T> temp = new Node<T>(x);
            temp.SetNext(head);
            head = temp;
        }
        //-----------------------------------
        //removes & returns the element from the top of the stack
        public T Pop()
        {
            T x = head.GetValue();
            head = head.GetNext();
            return x;
        }
        //-----------------------------------
        //returns the element from the top of the stack
        public T Top()
        {
            return head.GetValue();
        }
        //-----------------------------------
        //returns true if there are no elements in stack
        public bool IsEmpty()
        {
            return head == null;
        }
        //-------------------------------------
        //ToString
        public override string ToString()
        {
            if (this.IsEmpty())
                return "[]";

            Node<T> temp = head;
            string st = "TOP <== ";

            while (temp != null)
            {
                st += temp.GetValue();
                if (temp.HasNext())
                    st += ", ";
                temp = temp.GetNext();
            }

            st += "]";
            return st;
        }
    }
}