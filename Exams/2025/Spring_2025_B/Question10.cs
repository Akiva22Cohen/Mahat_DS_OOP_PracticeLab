namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    public class Doctor
    {
        protected string name;// שם
        protected string specialization;// התמחות
        protected int numOfPatients; // חולים מספר
        public Doctor(string name, string spec)
        {
            this.name = name;
            this.specialization = spec;
            this.numOfPatients = 0;
        }
        public Doctor(string name, string spec, int num)
        {
            this.name = name;
            this.specialization = spec;
            this.numOfPatients = num;
        }
        public Doctor(Doctor other)
        {
            this.name = other.name;
            this.specialization = other.specialization;
            this.numOfPatients = other.numOfPatients;
        }
        public void AddPatients(int num)
        {
            if (numOfPatients + num >= 0)
                this.numOfPatients += num;
        }
        public override string ToString()
        {
            return "Doctor:" + name + ", " + specialization + ","
           + numOfPatients;
        }

        public string GetName() { return name; }
        public string GetSpecialization() { return specialization; }
        public int GetNumOfPatients() { return numOfPatients; }

        public void SetName(string name) { this.name = name; }
        public void SetSpecialization(string spec) { this.specialization = spec; }
        public void SetNumOfPatients(int num) { this.numOfPatients = num; }
    }

    public class Intern : Doctor
    {
        private Doctor mentor;
        public Intern(string name, string spec, Doctor mentor) :
       base(name, spec)
        {
            this.mentor = mentor;
            this.numOfPatients = mentor.GetNumOfPatients() / 2;
        }

        public Doctor GetMentor() { return mentor; }

        public override string ToString()
        {
            return "Intern: " + name + ", " + specialization +
           ", Mentor: " + mentor.GetName() + ", " +
           mentor.GetNumOfPatients() + "," + numOfPatients;
        }
    }

    public class Question10
    {
        public static void PrintNotSameSpec(Doctor[] d)
        {
            string nameIntern, specIntern, specMentor;
            Doctor doctor, mentor;
            Intern intern;
            for (int i = 0; i < d.Length; i++)
            {
                doctor = d[i];
                if (doctor is Intern)
                {
                    intern = (Intern)doctor;
                    mentor = intern.GetMentor();
                    specIntern = intern.GetSpecialization();
                    specMentor = mentor.GetSpecialization();

                    if (!specIntern.Equals(specMentor))
                    {
                        nameIntern = intern.GetName();
                        Console.WriteLine(nameIntern + " ");
                    }
                }
                
            }
        }

        public static void RunTest()
        {
            Doctor[] d = new Doctor[9];
            d[0] = new Doctor("Dr. Cohen", "Cardiology", 12);
            d[1] = new Doctor("Dr. Levy", "Neurology");
            d[2] = new Doctor("Dr. Sharon", "Pediatrics", 8);
            d[3] = new Intern("Dani", "Cardiology", new Doctor(d[0]));
            d[4] = new Intern("Yael", "Surgery", d[0]);
            d[5] = new Intern("Avi", "Pediatrics", new Doctor(d[2]));
            d[6] = new Intern("Ruth", "Oncology", d[2]);
            d[7] = new Intern("Noam", "Cardiology", new Doctor(d[1]));
            d[8] = new Intern("Maya", "Neurology", new Doctor(d[0]));

            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(d[i].ToString());
            }

            d[0] = new Doctor("Dr. Goldman", "Neurology", 20);
            d[2].SetName("Dr. Galper");
            d[2].AddPatients(100);
            d[3].AddPatients(200);
            d[5].AddPatients(100);

            Console.WriteLine("After change:");
            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(d[i].ToString());
            }

            Console.WriteLine("\nInterns with different specialization than their mentor:");
            PrintNotSameSpec(d);
        }
    }
}
