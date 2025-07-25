namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    class A
    {
        protected int x;

        public A()
        {
            Console.WriteLine("create A x=" + x);
        }

        public A(int x)
        {
            this.x = x;
            Console.WriteLine("create A(int), x=" + x);
        }
    }

    class B : A
    {
        public B(int n) 
        {
            Console.WriteLine("create B(int)");
        }

        public B():this(45)
        {
            Console.WriteLine("create B");
        }
    }

    public class Question4
    {
        public static void RunTest()
        {
            B b = new B();
        }
    }
}
