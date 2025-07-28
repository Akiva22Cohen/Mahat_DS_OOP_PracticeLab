namespace Mahat_DS_OOP_PracticeLab.Exams._2025.Spring_2025_B
{
    class Call
    {
        private int type; // סוג אירוע חירום
        private string location; // אזור
        private string description; // תיאור
        private string callerName; //שם המתקשר
        private int priority; // רמת הדחיפות

        public Call(int type, string location, string description, string callerName, int priority)
        {
            this.type = type;
            this.location = location;
            this.description = description;
            this.callerName = callerName;
            this.priority = priority;
        }

        public int GetType() { return type; }
        public string GetLocation() { return location; }
        public string GetDescription() { return description; }
        public string GetCallerName() { return callerName; }
        public int GetPriority() { return priority; }

        public void SetType(int type) { this.type = type; }
        public void SetLocation(string location) { this.location = location; }
        public void SetDescription(string description) { this.description = description; }
        public void SetCallerName(string callerName) { this.callerName = callerName; }
        public void SetPriority(int priority) { this.priority = priority; }
    }

    class EmergencyList
    {
        Collections.Stack<Call> calls; // רשימת קריאות חירום
        private int type; // סוג אירוע חירום

        public EmergencyList(int type)
        {
            this.type = type;
            calls = new Collections.Stack<Call>();
        }

        public void AddCall(Call call)
        {
            if (call.GetType() == type)
            {
                calls.Push(call);
            }
        }

        public int GetType() { return type; }
        public Collections.Stack<Call> GetCalls()
        {
            return calls;
        }
    }

    class EmergencyCenter
    {
        private EmergencyList[] arr = new EmergencyList[6];

        public EmergencyCenter()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new EmergencyList(i);
            }
        }

        public void AddCall(int type, string location, string description,
            string callerName, int priority)
        {
            Call call = new Call(type, location, description, callerName, priority);
            arr[type].AddCall(call);
        }

        public Call mostUrgentCall(int type)
        {
            Collections.Stack<Call> calls = arr[type].GetCalls();
            Collections.Stack<Call> temp = new Collections.Stack<Call>();
            Call call = calls.Top(), resultCall = calls.Top();
            bool found = false;
            int maxPriority = call.GetPriority(), currentPriority;

            while (!calls.IsEmpty())
            {
                call = calls.Pop();
                currentPriority = call.GetPriority();

                if (currentPriority < maxPriority)
                {
                    maxPriority = currentPriority;
                }
                temp.Push(call);
            }

            while (!temp.IsEmpty())
            {
                call = temp.Pop();
                if (call.GetPriority() == maxPriority && !found)
                {
                    resultCall = call;
                    found = true;
                }
                else
                {
                    calls.Push(call);
                }
            }

            resultCall.SetType(0);
            arr[0].AddCall(resultCall);

            if (found)
            {
                return resultCall;
            }
            else
            {
                return null; // No call found with the maximum priority
            }
        }

        public void PrintCountLocation(string location)
        {
            int count = 0;
            string l;
            Collections.Stack<Call> calls, tmp = new Collections.Stack<Call>();
            Call call;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Type: " + i + ", ");
                calls = arr[i].GetCalls();
                while (!calls.IsEmpty())
                {
                    call = calls.Pop();
                    l = call.GetLocation();
                    if (l.Equals(location))
                    {
                        count++;
                    }
                    tmp.Push(call);
                }

                Console.WriteLine(count);
                Console.WriteLine();
                count = 0; // Reset count for the next type
                while (!tmp.IsEmpty())
                {
                    calls.Push(tmp.Pop());
                }
            }
        }
    }

    public class Question11
    {
        public static void RunTest()
        {
            Call call1 = new Call(1, "Tel Aviv", "Fire in building", "Alice", 5);
            Call call2 = new Call(2, "Haifa", "Car accident", "Bob", 3);
            Call call3 = new Call(1, "Jerusalem", "Medical emergency", "Charlie", 4);
            Call call4 = new Call(3, "Tel Aviv", "Flooding in area", "David", 2);
            Call call5 = new Call(1, "Tel Aviv", "Gas leak", "Eve", 6);
            EmergencyCenter center = new EmergencyCenter();
            center.AddCall(1, call1.GetLocation(), call1.GetDescription(), call1.GetCallerName(), call1.GetPriority());
            center.AddCall(2, call2.GetLocation(), call2.GetDescription(), call2.GetCallerName(), call2.GetPriority());
            center.AddCall(1, call3.GetLocation(), call3.GetDescription(), call3.GetCallerName(), call3.GetPriority());

            center.AddCall(3, call4.GetLocation(), call4.GetDescription(), call4.GetCallerName(), call4.GetPriority());
            center.AddCall(1, call5.GetLocation(), call5.GetDescription(), call5.GetCallerName(), call5.GetPriority());
            Call urgentCall = center.mostUrgentCall(1);
            if (urgentCall != null)
            {
                Console.WriteLine("Most urgent call: ");
                Console.WriteLine("Type: " + urgentCall.GetType() + ", Location: " + urgentCall.GetLocation() +
                    ", Description: " + urgentCall.GetDescription() + ", Caller Name: " + urgentCall.GetCallerName() +
                    ", Priority: " + urgentCall.GetPriority());
            }
            else
            {
                Console.WriteLine("No urgent call found.");
            }

            center.PrintCountLocation("Tel Aviv");
        }
    }
}
