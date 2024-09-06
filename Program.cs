using System.Transactions;
using System;
class TestApp
{
    static void Main(string[] args)
    {
        // Task #1

        int lowNum = GetNum("Enter a low number: ");

        int highNum = GetNum("Enter a high number: ");

        Console.WriteLine(highNum - lowNum);


        // Task #2
        int lowNumInput = GetNum("Enter a positive low number");
        while (lowNumInput < 0)
        {
            lowNumInput = GetNum("Enter a positive low number");
        }

        int highNumInput = GetNum("Enter a high number greater than the low number");
        while (highNumInput < lowNumInput)
        {
            highNumInput = GetNum("Enter a high number greater than the low number");
        }

        // Task #3
        int index = 0;
        int[] inBetween = new int[highNumInput - lowNumInput - 1];
        for (int i = lowNumInput + 1; i < highNumInput; i++)
        {
            inBetween[index] = i;
            index++;
        }

        //Sort list for descending order
        int[] sortedInBetween = new int[inBetween.Length];
        index = inBetween.Length - 1;
        foreach (int i in inBetween) {
            sortedInBetween[index] = i;
            index--;
        }

        //Convert the array to string 
        string[] lines = Array.ConvertAll(sortedInBetween, sortedInBetween => sortedInBetween.ToString());


        //Writes to file
        File.WriteAllLines("numbers.txt", lines);

        // Additional tasks
        Console.WriteLine("Prime Numbers: ");
        List<int> primeNumbers = new List<int>();
        foreach (int i in inBetween)
        {
            if (PrimeNum(i))
            {
                primeNumbers.Add(i);
            }
        }
        foreach (int i in primeNumbers)
        {
            Console.WriteLine(i);
        }


    }
    //Task #1 Additional
    static int GetNum(string prompt)
    {
        Console.WriteLine(prompt);
        int user_input = 0;
        while (user_input == 0)
        {
            try
            {
                user_input = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a valid input, Numbers only");
            }
        }
        return user_input;

    }
    static bool PrimeNum(int num)
    {
        if (num == 0 || num == 1 || num % 2 == 0)
        {
            return false;
        }
        else if (num == 2)
        {
            return true;
        }
        for (int i = 3; i < num; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        
        }
        return true;
    }
}
