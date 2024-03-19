int number = default;

Console.WriteLine("Enter numbers from 1 to 100: ");
number = Convert.ToInt32(Console.ReadLine());

if (number % 3 == 0 && number % 5 == 0)
{
Console.WriteLine("Fizz buzz");
}
else if (number % 3 == 0)
{
Console.WriteLine("Fizz");
}
else if (number % 5 == 0)
{
Console.WriteLine("Buzz");
}
else
{
Console.WriteLine("Incorrect");
}
//--------------------
int number1 = default;
int percent = default;

Console.WriteLine("Enter number: ");
number1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter percent: ");
percent = Convert.ToInt32(Console.ReadLine());

Console.WriteLine((number * percent) / 100);
//-------------------------------
int number2 = default;
int number3 = default;
int number4 = default;
int number5 = default;
int result = default;

Console.WriteLine("Enter first number: ");
number2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter second number: ");
number3 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter third number: ");
number4 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter fourth number: ");
number5 = Convert.ToInt32(Console.ReadLine());

result = number2 * 1000 + number3 * 100 + number4 * 10 + number5 * 1;

Console.WriteLine("Your result: ", result);

//-------------------

Console.WriteLine("Enter number with six digits:");
string inputNumber = Console.ReadLine();

if (inputNumber.Length != 6)
{
Console.WriteLine("Error: Not correct number.");
}

Console.WriteLine("Enter numbers of digits for swap numbers:");
string inputPositions = Console.ReadLine();
int position1 = int.Parse(inputPositions.Substring(0, 1));
int position2 = int.Parse(inputPositions.Substring(1, 1));

if (position1 < 1 || position1 > 6 || position2 < 1 || position2 > 6)
{
Console.WriteLine("Error: Digits are not correct.");
}
else
{
char[] charArray = inputNumber.ToCharArray();
char temp = charArray[position1 - 1];
charArray[position1 - 1] = charArray[position2 - 1];
charArray[position2 - 1] = temp;
string res = new string(charArray);
Console.WriteLine($"Result of swapping: {res}");

}

//----------------------------

Console.WriteLine("Enter  date with format dd.mm.yyyy:");
string inputDate = Console.ReadLine();

if (DateTime.TryParse(inputDate, out DateTime date))
{
string season = GetSeason(date.Month);
string dayOfWeek = date.ToString("dddd");

Console.WriteLine($"{season} {dayOfWeek}");
}
else
{
Console.WriteLine("Error: Date is not correct.");
}

static string GetSeason(int month)
{
    switch (month)
    {
        case 12:
        case 1:
        case 2:
            return "Winter";
        case 3:
        case 4:
        case 5:
            return "Spring";
        case 6:
        case 7:
        case 8:
            return "Summer";
        case 9:
        case 10:
        case 11:
            return "Autumn";
        default:
            return "";
    }

    Console.WriteLine("Choose action:");
    Console.WriteLine("1. From farengheit to Celsium");
    Console.WriteLine("2. From Celsium to Farengeit");
    Console.WriteLine("Choose action (1 or 2): ");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.Write("Enter farengeits: ");
        double fahrenheit = double.Parse(Console.ReadLine());
        double celsius = (fahrenheit - 32) * 5 / 9;
        Console.WriteLine($"Temperature in Celsium: {celsius}");
    }
    else if (choice == 2)
    {
        Console.Write("Enter Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        double fahrenheit = celsius * 9 / 5 + 32;
        Console.WriteLine($"Temperature in Farengheit: {fahrenheit}");
    }
    else
    {
        Console.WriteLine("Incorrect choice.");
    }

    //--------------------

    Console.Write("Enter first number: ");
    int num1 = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int num2 = int.Parse(Console.ReadLine());

    int minNum = Math.Min(num1, num2);
    int maxNum = Math.Max(num1, num2);

    if (minNum % 2 != 0)
    {
        minNum++;
    }

    Console.WriteLine($"Even numbers from {minNum} to {maxNum}:");

    for (int i = minNum; i <= maxNum; i += 2)
    {
        Console.WriteLine(i);
    }
}