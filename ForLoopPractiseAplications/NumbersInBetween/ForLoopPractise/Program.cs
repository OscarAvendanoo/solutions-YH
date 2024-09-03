namespace ForLoopPractise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // This program asks for two numbers and types all the numbers in between out to the user

            Console.WriteLine("Hello, please type two number and i will type the numbers in between out for you.");
            Console.WriteLine("first number;");
            string firstNumberString = Console.ReadLine();
            int firstNumberInt = int.Parse(firstNumberString);
            Console.WriteLine("second number;");
            string secondNumberString = Console.ReadLine();
            int secondNumberInt = int.Parse(secondNumberString);
            Console.WriteLine("");
            Console.WriteLine("Here are the numbers;");

            for (int i = firstNumberInt + 1; i < secondNumberInt; i++)
            {
                Console.Write(i + " ");


            }
            Console.WriteLine("");
        }
    }
}