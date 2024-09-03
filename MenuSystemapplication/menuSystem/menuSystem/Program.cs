namespace menuSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool runprogram = true;
            string emailAdress = "";
            string name = "";

            do
            {
                Console.WriteLine("Choose one of the following alternatives;");
                Console.WriteLine("1. write out your name");
                Console.WriteLine("2. write out your email adress");
                Console.WriteLine("9. exit program.");
                string choiceString = Console.ReadLine();
                int choiceInt = int.Parse(choiceString);

                switch (choiceInt)
                {
                    case 1:
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("we dont have your name yet, please enter it here;");
                            name = Console.ReadLine();
                            Console.WriteLine("Great, your name is; " + name);
                            Console.WriteLine("");
                        }
                        else
                        { 
                            Console.WriteLine("Your name is; " + name);
                            Console.WriteLine("");
                        }

                        break;
                    case 2:
                        if (string.IsNullOrWhiteSpace(emailAdress))
                        {
                            Console.WriteLine("we dont have your email adress yet, please enter it here;");
                            emailAdress = Console.ReadLine();
                            Console.WriteLine("great! your email adress is; " + emailAdress);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Your email adress is; " + emailAdress);
                            Console.WriteLine("");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Application is now closing, byebye!");
                        runprogram = false;
                        break;
                    default:
                        Console.WriteLine("You can only answer in form of a number, please try again.");
                        Console.WriteLine("Pick a number and then press enter.");
                        Console.WriteLine("");
                        break;
                }
                    
            } while (runprogram == true);
        }
    }
}
