using System;
using System.Collections;
using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{

    //Frågor:
    // 1. Stacken och Heapen, hur fungerar de?
    // Stacken och Heapen är två olika minnesområden som används för att lagra data under programmets körning.
    // Garbage Collection hanterar minnet i heapen genom att automatiskt frigöra minne som inte längre används av programmet.

    // 2. Vad är Value types respektive Reference Types och vad är skillnaden mellan dem?
    // Värdetyper som int, char, bool lagras på stacken medan referenstyper som string, andra objekt och arrayer lagras på heapen.
    // För referenstyper lagras en referens på stacken som pekar på objektets plats i heapen.
    // Detta gör att det kan finnas flera referenser på stacken till samma objekt i heapen.

    // 3. Varför returnerar den första metoden 3 och den andra 4?
    // Den första använder en värdetyp (int) som skapas på stacken vilket gör att y = x skapar en kopia av värdet på y.
    // Den andra använder en klass så när y = x görs så refererar båda variablerna (y och x) på samma objekt i heapen.
    // Så när värdet ändras på y så ändras även värdet för x eftersom de refererar till samma objekt på heapen.
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Reverse Text"
                    + "\n6. Recursive Even Number"
                    + "\n7. Recursive Fibonacci"
                    + "\n8. Iterative Even Number"
                    + "\n9. Iterative Fibonacci"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        ReverseText();
                        break;
                    case '6':
                        Console.WriteLine(RecursiveEven(int.Parse(Console.ReadLine())));
                        break;
                    case '7':
                        Console.WriteLine(RecursiveFibonacci(int.Parse(Console.ReadLine())));
                        break;
                    case '8':
                        Console.WriteLine(IterativeEven(int.Parse(Console.ReadLine())));
                        break;
                    case '9':
                        Console.WriteLine(IterativeFibonacci(int.Parse(Console.ReadLine())));
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("Enter text to reverse: ");
            string text = Console.ReadLine() ?? string.Empty;
            string reversedText = "";
            Stack stack = new();

            for (int i = 0; i < text.Length; i++)
            {
                stack.Push(text[i]);
            }

            for (int i = 0; i < text.Length; i++)
            {
                reversedText += stack.Pop();
            }

            Console.WriteLine($"Reversed text: {reversedText}");
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */


            // 1.
            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Please input +item to add or -item to remove an item from the list. Input '0' to exit to main menu.");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added {value} to the list.");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Removed {value} from the list.");
                        break;
                    case '0':
                        return;
                    default:
                        break;
                }
                Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");

                // 2. Listans kapacitet ökar när antalet element överstiger den nuvarande kapaciteten.
                // 3. Kapaciteten dubblas varje gång den överskrids.
                // 4. Listans kapacitet ökar inte i samma takt som element läggs till
                //    för det skulle påverka prestandan negativt att behöva omallokera och kopiera element ofta.
                // 5. Kapaciteten minskar inte när element tas bort från listan.
                // 6. Det är fördelaktigt att använda en egendefinierad array istället för en lista om man vet exakta storleken som behövs.

            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue theQueue = new Queue();

            while (true)
            {
                Console.WriteLine("Please input +item to add an item to the queue or '-' to dequeue. Input '0' to exit to main menu.");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"Added {value} to the queue.");
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                        {
                            Console.WriteLine($"Removing {theQueue.Peek()} from the queue.");
                            theQueue.Dequeue();
                        }
                        break;
                    case '0':
                        return;
                    default:
                        break;
                }
                if (theQueue.Count > 0)
                    Console.WriteLine($"Count: {theQueue.Count} Queue: {theQueue.Peek()}");
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack theStack = new Stack();

            while (true)
            {
                Console.WriteLine("Please input +item to push an item to the stack or '-' to pop item. Input '0' to exit to main menu.");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        Console.WriteLine($"Pushed {value} to the stack.");
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            Console.WriteLine($"Popping {theStack.Peek()} from the stack...");
                            theStack.Pop();
                        }
                        break;
                    case '0':
                        return;
                    default:
                        break;
                }
                if (theStack.Count > 0)
                    Console.WriteLine($"Count: {theStack.Count} Stack: {theStack.Peek()}");
            }

            //1. Den som är först in är den som är sist ut (FILO - First In Last Out)
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Enter sentence: ");
            string input = Console.ReadLine() ?? string.Empty;
            Stack stack = new();
            bool formattedCorrectly = true;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        formattedCorrectly = false;
                        break;
                    }
                    char stackChar = (char)stack.Pop();
                    if (stackChar == '(' && c != ')' || stackChar == '[' && c != ']' || stackChar == '{' && c != '}')
                    {
                        formattedCorrectly = false;
                        break;
                    }
                }
            }
            if (formattedCorrectly)
            {
                Console.WriteLine("String paranthesis formatted correctly.");
            }
            else
            {
                Console.WriteLine("String paranthesis formatted incorrectly.");
            }
        }

        static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 0;
            }
            else
            {
                return RecursiveEven(n - 1) + 2;
            }
        }

        static int RecursiveFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
            }
        }

        static int IterativeEven(int n)
        {
            int result = 0;
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }
            return result;
        }

        static int IterativeFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1) 
            { 
                return 1; 
            }
            int a = 0;
            int b = 1;
            int result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }
            return result;
        }
        //Vilken metod är mest effektiv och varför?
        //De iterativa metoderna är mest effektiva eftersom de inte kräver flera funktionsanrop som de rekursiva metoden gör.
        //Det blir O(n) tidskomplexitet för båda metoderna, men O(n) minneskomplexitet för den rekursiva metoden jämfört med O(1) för den iterativa metoden.
        //Rekursiva Fibonacci metoden blir O(2^n) tidskomplexitet och O(n) minneskomplexitet. Jämfört med O(n) tidskomplexitet och O(1) minneskomplexitet för den iterativa metoden.
    }
}

