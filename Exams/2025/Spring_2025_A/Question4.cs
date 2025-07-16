namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class A
    {
        protected int num;
        public A() { }
        public A(int num) { this.num = num; }
        public virtual int Func(int k) { return k + this.num; }


        public int Func() { return 1; }
        public int Func(double k) { return (int)k; }
        //public double Func(int k) { return 1.0 * k; }
        //public int Func(int p) { return p; }
        public void Func(int k, int p) { Console.WriteLine(k * p); }

    }
    public class B : A
    {
        private int x;
        public bool Test() { return this.x > this.num; }

        //public override int Func() { return 1; }
        //public override int Func(double k) { return (int)k; }
        //public override double Func(int k) { return 1.0 * k; }
        //public override int Func(int p) { return p; }
        //public override void Func(int k, int p)
        //{
        //    Console.WriteLine(k * p);
        //}
    }

    public class Question4
    {

        public static void RunTest()
        {

        }
    }
}
