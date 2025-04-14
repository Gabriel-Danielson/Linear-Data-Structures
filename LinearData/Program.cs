using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

class LinearData
{
    static void Main(string[] args)
    {
        int[] testArray = {3, 4, 4, 2, 3, 3, 4, 3, 2};

        printReverse();

        Console.WriteLine("\n");

        Console.WriteLine("Count of numbers in array:");
        printArrayCount(testArray);

        Console.WriteLine("\n");

        printSequence();
    }

    /// <summary>Prints a sequence of integers given by the user in a reversed order.</summary>
    private static void printReverse()
    {
        Stack<int> stack = new Stack<int>();
        string strInput;

        Console.WriteLine("Give any number of integers (Press ENTER to confirm):");
        
        //User Validation
        do
        {
            strInput = Console.ReadLine();
            if (strInput != "")
            {
                if (int.TryParse(strInput, out int intInput))
                {
                    stack.Push(intInput);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }
            else
            {
                Console.WriteLine("\nReversed order:");
            }
        } while (strInput != "");

        if (stack.Count == 0)
        {
            Console.WriteLine("No input to reverse.\n");
        }
        else
        {    while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }

    /// <summary>Counts the amount of times each number in an array of integers appear.</summary>
    /// <param name="testArray">An array containing integers to test function</param>
    private static void printArrayCount(int[] testArray)
    {
        int[] occurences = new int[1001];

        foreach (int p in testArray) //for each element in testArray, add 1 to element at position p to occurences
        {
            occurences[p]++; //adds 1 to occurences array at position p
        }

        for (int i = 0; i < occurences.Length; i++) //for each index in occurences, print the index and value
        {
            if (occurences[i] != 0)
            {
                Console.WriteLine("The number " + i + " occurs " + occurences[i] + " times.");
            }
        }
    }

    /// <summary>Prints the first 50 integers in a specific sequence starting with the number inputted by the user.</summary>
    private static void printSequence()
    {
        Queue<int> queue = new Queue<int>();

        Console.WriteLine("Give an integer to compute first 50 numbers of:");
        string strSequenceStart = Console.ReadLine();

        //User Validation
        if (strSequenceStart != "")
        {
            if (int.TryParse(strSequenceStart, out int intSequenceStart))
            {
                int counter = 0;

                queue.Enqueue(intSequenceStart);
                Console.WriteLine("\nFirst 50 numbers in sequence:");

                while (queue.Count < 50)
                {
                    counter++;

                    int m = queue.Dequeue();
                    
                    queue.Enqueue(m + 1);
                    queue.Enqueue(2 * m + 1);
                    queue.Enqueue(m + 2);
                    
                    Console.WriteLine("S " + counter + " = " + m);
                }
                while (queue.Count > 26)
                {
                    counter++;
                    Console.WriteLine("S " + counter + " = " + queue.Dequeue());
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }
        else if (strSequenceStart == "")
        {
            Console.WriteLine("No input given.");
            printSequence();
        }
    }
}