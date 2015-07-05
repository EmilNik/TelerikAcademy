using System;

class PlayWithIntDoubleAndString
{
    static void Main()
    { 
        //Write a program that, depending on the user’s choice, inputs an int, double or string variable.
        //    If the variable is int or double, the program increases it by one.
        //    If the variable is a string, the program appends * at the end.
        //Print the result at the console. Use switch statement.

        
        Console.Write("Choose one of the following:\n1 for int\n2 for double\n3 for string\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1": Console.Write("Enter your int: ");
                      int a = int.Parse(Console.ReadLine());
                      Console.WriteLine(a + 1);
                      break;
            case "2": Console.Write("Enter your double: "); 
                      double b = double.Parse(Console.ReadLine());
                      Console.WriteLine(b + 1.0);
                      break;
            case "3": Console.Write("Enter your string: "); 
                      string c = Console.ReadLine();
                      Console.WriteLine(c + "*");
                      break;
            default: Console.WriteLine("Not a valid choice!");
                break;
        }
    }
}
