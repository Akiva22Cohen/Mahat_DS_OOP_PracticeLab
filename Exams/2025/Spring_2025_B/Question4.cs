namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Car
    {
        private int speed;

        public Car(int s)
        {
            speed = s;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public bool Equals(Car other)
        {
            return (other != null) && (speed == other.speed);
        }
    }

    public class Motorcycle
    {
        private int speed;

        public Motorcycle(int s)
        {
            speed = s;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public bool Equals(Object other)
        {
            return ((other != null) &&
            (other is Motorcycle) &&
            (speed == ((Motorcycle)other).speed));
        }
    }

    public class Question4
    {
        public static int CountCars(object[] vehicles)
        {
            int ccount = 0;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is Motorcycle)
                {
                    Motorcycle motorcycle = (Motorcycle)vehicles[i];
                    if (motorcycle.GetSpeed() >= 180 && motorcycle.GetSpeed() <= 250)
                    {
                        ccount++;
                    }
                }
            }

            return ccount;
        }

        public static void RunTest()
        {
            //object[] vehicles = new object[5];
            //vehicles[0] = new Car(200);
            //vehicles[1] = new Motorcycle(220);
            //vehicles[2] = new Motorcycle(150);
            //vehicles[3] = new Motorcycle(180);
            //vehicles[4] = new Motorcycle(250);

            //int count = CountCars(vehicles);
            //if (count == 3)
            //{
            //    Console.WriteLine("Test passed: CountCars returned the correct count of motorcycles.");
            //}
            //else
            //{
            //    Console.WriteLine($"Test failed: CountCars returned {count}, expected 3.");
            //}

            Car c1 = new Car(180);
            Object c2 = new Car(180);
            Motorcycle m1 = new Motorcycle(180);
            Object m2 = new Motorcycle(180);

            //Console.WriteLine(c1.speed); // שגיאת קומפילציה
            //Console.WriteLine(((Motorcycle)c2).GetSpeed()); // שגיאת זמן ריצה
            //Console.WriteLine(c1.Equals(c2)); // עובד ומחזיר 'שקר'
            //Console.WriteLine(c2.Equals(c1)); // עובד ומחזיר 'שקר'
            //Console.WriteLine(m1.Equals(m2)); // עובד ומחזיר 'אמת'
            //Console.WriteLine(m2.Equals(m1)); // עובד ומחזיר 'שקר'
            //Console.WriteLine(c1.Equals((Motorcycle)m2)); // עובד ומחזיר 'שקר'
            //Console.WriteLine(c1.Equals((Car)c2)); // עובד ומחזיר 'אמת'
            //Console.WriteLine(m1.Equals((Car)c2)); // עובד ומחזיר 'שקר'
            //Console.WriteLine(m1.Equals((Motorcycle)c2)); // שגיאת זמן ריצה
        }
    }
}
