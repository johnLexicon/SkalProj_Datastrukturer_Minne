using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{

    internal enum Operation
    {
        Add,
        Remove
    };

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

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 7, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. Recursive Even"
                    + "\n6. Iterative Fibonacci"
                    + "\n7. Iterative Even"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
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
                        string text = AskForString("Give text to check for parenthesis: ");
                        CheckParantheses(text);
                        break;
                    case '5':
                        int number = AskForInteger("Give a number for the recursive even method: ");
                        int result = RecursiveEven(number);
                        Console.WriteLine("Recursive even result: " + result);
                        break;
                    case '6':
                        int fiNumber = AskForInteger("Give number for the Fibonacci method: ");
                        IList<int> fiResult = IterativeFibonacci(fiNumber);
                        Console.WriteLine("Iterative fibonacci result:");
                        //TODO: Print out the result, look how to use yield in this assignment.
                        break;
                    case '7':
                        int ieNumber = AskForInteger("Give number for the Iterative Even method: ");
                        int ieResult = IterativeEven(ieNumber);
                        Console.WriteLine("Iterative even result: " + ieResult);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6, 7)");
                        break;
                }
            }
        }

        /// <summary>
        /// Used for the assignment 1.1. Decoupled functionality from the ExamineList method for test purposes.
        /// </summary>
        /// <param name="text">The text to add or remove in the list</param>
        /// <param name="theList">Reference to the list to manipulate</param>
        /// <param name="operation">The operation to make to the list</param>
        internal static void ListHandler(string text, List<string> theList, Operation operation)
        {
            if (operation == Operation.Add)
            {
                theList.Add(text);
            }
            else
            {
                theList.Remove(text);
            }
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

            List<string> theList = new List<string>();
            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);

            switch (nav)
            {
                case '+':
                    ListHandler(value, theList, Operation.Add);
                    break;
                case '-':
                    ListHandler(value, theList, Operation.Remove);
                    break;
                default:
                    Console.WriteLine($"{nav} is not an option!!!");
                    break;
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
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("Menu Examine Queue \n0.quit\n1.Add value to queue\n2.Remove from queue\n3.Print queue");
                string menuOption = AskForString("Menu option: ");
                switch (menuOption)
                {
                    case "1":
                        string valueToAdd = AskForString("Write value to add to the queue: ");
                        queue.Enqueue(valueToAdd);
                        break;
                    case "2":
                        queue.Dequeue();
                        break;
                    case "3":
                        queue.ToList().ForEach(item => Console.WriteLine(item));
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine($"{menuOption} is not an option!!!");
                        break;
                }
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

        }

        internal static bool CheckParantheses(string text)
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})]
             * Example of incorrect: (()]), [), {[()}]
             */

            Stack<char> stack = new Stack<char>();

            foreach (var ch in text)
            {
                switch (ch)
                {
                    case '(':
                        stack.Push((char)(ch + 1));
                        break;
                    case '[':
                    case '{':
                        stack.Push((char)(ch + 2));
                        break;
                    case ')':
                    case ']':
                    case '}':
                        //If less opened parentheses than closed OR not the same type of parntheses.
                        if (stack.Count == 0 || !ch.Equals(stack.Pop()))
                        {
                            return false;
                        }
                        break;
                }    
            }

            //If more opened parentheses than closed
            if(stack.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Implemented method for assignment 5.2
        /// </summary>
        /// <param name="n">The number of recusrsions</param>
        /// <returns>The n:th even number</returns>
        internal static int RecursiveEven(int n)
        {
            if(n == 0)
            {
                return 0; //For even values return 0, for odd values return 1
            }
            return RecursiveEven(n - 1) + 2;
        }

        /// <summary>
        /// Implemented method for assignment 6.2
        /// </summary>
        /// <param name="n">The number of iterations</param>
        /// <returns>The n:th even number</returns>
        internal static int IterativeEven(int n)
        {
            int result = 0;

            if(n == 0)
            {
                return result;
            }

            for (int i = 0; i < n; i++)
            {
                result += 2;
            }

            return result;
        }

        //TODO: Implement this if you can:-)
        internal static int RecursiveFibonacci(int n)
        {

            return RecursiveFibonacci(n - 1);
        }

        /// <summary>
        /// Implemented method for assignment 6.3 
        /// </summary>
        /// <param name="elementsCount"></param>
        /// <returns></returns>
        internal static IList<int> IterativeFibonacci(int elementsCount)
        {
            List<int> elements = new List<int> { 1, 1 };

            for(int i = 0; i < elementsCount; i++)
            {
                int newElement = elements[i] + elements[i + 1];
                elements.Add(newElement);
            }

            return elements;
        }

        /// <summary>
        /// Implemented method for assignment 3.2
        /// </summary>
        /// <param name="text">The given string by the user</param>
        /// <returns>A string in reverse order or null</returns>
        internal static string ReverseText(string text)
        {
            if(text is null)
            {
                return text;
            }

            Stack<char> characters = new Stack<char>();
            var reverseText = new StringBuilder();

            foreach (char ch in text)
            {
                characters.Push(ch);
            }

            while (characters.Count() > 0)
            {
                try
                {
                    reverseText.Append(characters.Pop());
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Something went really wrong!!! {e.Message}");
                    break;
                }
            }

            return reverseText.ToString();
        }

        /// <summary>
        /// Asks for string.
        /// </summary>
        /// <returns>The user answer</returns>
        /// <param name="prompt">Prompt for the user</param>
        static string AskForString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Control method for asking after an integer.
        /// </summary>
        /// <returns>The integer given from the user</returns>
        /// <param name="prompt">Prompt for the user</param>
        static int AskForInteger(string prompt)
        {
            bool success = false;
            int result;

            do
            {
                string answer = AskForString(prompt);
                success = int.TryParse(answer, out result);
                if (!success)
                {
                    Console.WriteLine("An integer please!!");
                }

            } while (!success);

            return result;
        }
    }
}
