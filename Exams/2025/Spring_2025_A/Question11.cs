using System.Text;

namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_A
{
    public class Reminder
    {
        private string cust;   // שם הלקוח
        private string tel;    // טלפון
        private string inst;   // שם המכון
        private string date;   // תאריך התור
        private int hour;      // שעת התור
        private int status;    // 2 ביטול, -1 אישור, 0 אין מענה

        // פעולה בונה – מאתחלת את כל השדות, status תמיד 0
        public Reminder(string cust, string tel, string inst, string date, int hour)
        {
            this.cust = cust;
            this.tel = tel;
            this.inst = inst;
            this.date = date;
            this.hour = hour;
            this.status = 0;
        }

        // Getters
        public string GetCust() { return cust; }
        public string GetTel() { return tel; }
        public string GetInst() { return inst; }
        public string GetDate() { return date; }
        public int GetHour() { return hour; }
        public int GetStatus() { return status; }

        // Setters
        public void SetCust(string cust) { this.cust = cust; }
        public void SetTel(string tel) { this.tel = tel; }
        public void SetInst(string inst) { this.inst = inst; }
        public void SetDate(string date) { this.date = date; }
        public void SetHour(int hour) { this.hour = hour; }
        public void SetStatus(int status) { this.status = status; }

        // ToString
        public override string ToString()
        {
            return $"Reminder: customer={cust}, tel={tel}, institute={inst}, date={date}, hour={hour}, status={status}";
        }
    }

    public class DailyReminder
    {
        private Collections.Stack<Reminder> dailyReminder = new Collections.Stack<Reminder>(); //  רשימת תזכורות
        private string date; // ביום מסוים

        public void AddReminder(Reminder reminder)
        {
            dailyReminder.Push(reminder);
        }

        public Collections.Stack<Reminder> GetStack()
        { return dailyReminder; }
    }

    public class WeeklyReminder
    {
        private DailyReminder[] arr = new DailyReminder[7];

        public WeeklyReminder()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new DailyReminder();
            }
        }

        public void AddReminder(string cust, string tel, string inst,
            string date, int hour, int dayReminder)
        {
            Reminder reminder = new Reminder(cust, tel, inst, date, hour);
            arr[dayReminder].AddReminder(reminder);
        }

        public void UpdateReminder(string cust, string inst,
            int dayReminder, int answer)
        {
            Collections.Stack<Reminder> pos = arr[dayReminder].GetStack();
            Collections.Stack<Reminder> tmp = new Collections.Stack<Reminder>();

            while (!pos.IsEmpty())
            {
                Reminder reminder = pos.Pop();

                if (cust == reminder.GetCust() && inst == reminder.GetInst())
                {
                    if (answer == 1 || answer == 2)
                    {
                        reminder.SetStatus(answer);
                        tmp.Push(reminder);
                    }
                    else
                    {
                        arr[0].AddReminder(reminder);
                    }
                }
                else
                {
                    tmp.Push(reminder);
                }
            }

            while (!tmp.IsEmpty())
                pos.Push(tmp.Pop());
        }

        public void PrintList(string[] inst)
        {
            for (int i = 0; i < inst.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    Collections.Stack<Reminder> stack = arr[j].GetStack();
                    Collections.Stack<Reminder> tmp = new Collections.Stack<Reminder>();

                    while (!stack.IsEmpty())
                    {
                        Reminder reminder = stack.Pop();

                        if (reminder.GetInst() == inst[i] &&
                            reminder.GetStatus() == 2)
                        {
                            Console.WriteLine(reminder);
                        }
                        tmp.Push(reminder);
                    }

                    while (!tmp.IsEmpty())
                        stack.Push(tmp.Pop());
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string[] dayNames = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            for (int i = 0; i < arr.Length; i++)
            {
                sb.AppendLine($"--- {dayNames[i]} ---");
                Collections.Stack<Reminder> stack = arr[i]?.GetStack();
                if (stack == null)
                {
                    sb.AppendLine("(no reminders)");
                    continue;
                }

                Collections.Stack<Reminder> tmp = new Collections.Stack<Reminder>();

                if (stack.IsEmpty())
                {
                    sb.AppendLine("(no reminders)");
                }

                while (!stack.IsEmpty())
                {
                    Reminder r = stack.Pop();
                    sb.AppendLine(r.ToString());
                    tmp.Push(r);
                }

                // Restore stack
                while (!tmp.IsEmpty())
                    stack.Push(tmp.Pop());

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public class Question11
    {
        public static void RunTest()
        {
            WeeklyReminder weeklyReminder = new WeeklyReminder();

            weeklyReminder.AddReminder("Tal", "489", "Koll Habriout", "23/07/2025", 18, 4);
            Console.WriteLine(weeklyReminder);

            weeklyReminder.UpdateReminder("Tal", "Koll Habriout", 4, 1);
            Console.WriteLine(weeklyReminder);
            Console.WriteLine("PrintList");
            weeklyReminder.PrintList(["Koll Habriout"]);

            Console.WriteLine();
            weeklyReminder.UpdateReminder("Tal", "Koll Habriout", 4, 2);
            Console.WriteLine("PrintList");
            weeklyReminder.PrintList(["Koll Habriout"]);

            Console.WriteLine();
            Console.WriteLine("PrintList");
            weeklyReminder.UpdateReminder("Tal", "Koll Habriout", 4, 0);
            weeklyReminder.PrintList(["Koll Habriout"]);
            
            Console.WriteLine();
            Console.WriteLine("PrintList");
            weeklyReminder.UpdateReminder("Tal", "Koll Habriout", 4, 2);
            weeklyReminder.PrintList(["Koll Habriout"]);
        }
    }
}
