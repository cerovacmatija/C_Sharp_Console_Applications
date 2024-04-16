// See https://aka.ms/new-console-template for more information

int number1, number2, result = 0;

string operation, exit;

Console.WriteLine("Hello, welcome to the calculator program!");
do
{
    Console.WriteLine("Please enter your first number.");
    number1 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Please enter your second number.");
    number2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("What type of operation would you like to do?");
    Console.WriteLine("Type a for addition, s for subtraction, m for multiplication or d for division.");

    do
    {
        operation = Console.ReadLine();

        if (operation == "a")
        {
            result = number1 + number2;
        }
        else if (operation == "s")
        {
            result = number1 - number2;
        }
        else if (operation == "m")
        {
            result = number1 * number2;
        }
        else if (operation == "d")
        {
            result = number1 / number2;
        }
        else
        {
            Console.WriteLine("Wrong input...");
        }
    } while (operation != "a" && operation != "s" && operation != "m" && operation != "d");

    Console.WriteLine("The result is " + result);
    Console.WriteLine("Would you like to do another calculation?");
    Console.WriteLine("Type y to continue or n to exit the application.");

    exit = Console.ReadLine();

} while (exit != "n");

Console.WriteLine("The result is " + result);
Console.WriteLine("Thank you for using the calculator program!");