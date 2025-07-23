namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Person
    {
        private string fName; // פרטי שם
        private string lName; // משפחה שם
        private int age; // גיל
        public Person()
        {
            this.fName = "unknown";
            this.lName = "unknown";
            this.age = 120;
        }
        public Person(string fName, string lName, int age)
        {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        }
        public Person(Person other)
        {
            this.fName = other.fName;
            this.lName = other.lName;
            this.age = other.age;
        }
        public void AddAge(int num)
        {
            if (this.age + num < 120)
                this.age += num;
        }
        public override string ToString()
        {
            return this.fName + " " + this.lName + " " + this.age;
        }
    }

    public class Contact : Person
    {
        private string tel; //טלפון של איש קשר
        private Person contact; // קשר איש
        public Contact(string fName, string lName, int age) :
        base(fName, lName, age)
        {
            this.tel = "NO";
            this.contact = new Person();
        }
        public Contact(Person person) : base(person)
        {

            this.tel = "NO";
            this.contact = null;
        }
        public Contact(Person person1, Person person2, string tel) :
        base(person1)
        {
            this.tel = tel;
            this.contact = new Person(person2);
        }
        public Contact(string fName, string lName, int age, Person person, string tel) :
            base(fName, lName, age)
        {
            this.tel = tel;
            this.contact = person;
        }
        public void SetContact(Person person, string tel)
        {
            this.contact = person;
            this.tel = tel;
        }
        public override string ToString()
        {
            if (this.contact == null) return base.ToString();
            return base.ToString() + " --> " + this.contact +
            " tel: " + this.tel;
        }
    }

    public class Question10
    {
        public static void RunTest()
        {
            Person[] p = new Person[6];
            p[0] = new Person("Avi", "Barak", 60);
            p[1] = new Person("Benny", "Coehn", 70);
            p[2] = new Person(p[1]);
            p[3] = p[1];
            p[4] = new Person();
            p[5] = new Person("David", "Ezra", 65);
            p[3].AddAge(30);
            for (int i = 0; i < p.Length; i++)
                Console.WriteLine(i + ") " + p[i]);

            Console.WriteLine();
            Person[] c = new Person[6];
            c[0] = new Contact(p[0], p[5], "123");
            c[1] = new Contact(p[1]);
            c[2] = new Contact(p[5], p[2], "456");
            c[3] = new Contact("Eric", "Far", 65, c[0], "789");
            c[4] = new Contact("Fiona", "Gold", 40);
            c[5] = (Person)c[3];
            ((Contact)c[1]).SetContact(c[5], "999");
            for (int i = 0; i < c.Length; i++)
                Console.WriteLine(i + ") " + c[i]);

        }
    }
}
