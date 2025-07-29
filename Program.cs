namespace Mahat_DS_OOP_PracticeLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Running All Exams Tests ===");

            // Spring 2025 A
            //Exams._2025.Spring_2025_A.ExamTests.RunAll();

            // Spring 2025 B
            //Exams._2025.Spring_2025_B.ExamTests.RunAll();

            // Summer 2024 B
            //Exams._2024.Summer_2024_B.ExamTests.RunAll();

            // Run tests from the general drafts folder (for unsorted or experimental practice tasks)
            GeneralPracticeDrafts.ExamTests.RunAll();

            Console.WriteLine("=== All Tests Completed ===");
            Console.ReadLine();
        }
    }
}
