double[] A_List = new double[5];

Console.WriteLine("Enter 5 digit for list A:");

for (int i = 0; i < A_List.Length; i++)
{
    A_List[i] = double.Parse(Console.ReadLine()!);
}

double[,] B_List = new double[3, 4];

Random random = new Random();

for (int i = 0; i < 3; i++)
    for (int j = 0; j < 4; j++) B_List[i, j] = random.NextDouble() * 100;


Console.Write("List A:");
foreach (var num in A_List)
{
    Console.Write($" {num}");
}
Console.WriteLine();

Console.WriteLine("List B:");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write("   ");
        Console.Write($"{B_List[i, j]}");
    }
    Console.WriteLine();
}

double maxA = A_List[0]; 
double minA = A_List[0];

double maxB = B_List[0, 0]; 
double minB = B_List[0, 0];

foreach (var num in A_List)
{
    if (num > maxA)
        maxA = num;
    if (num < minA)
        minA = num;
}
foreach (var num in B_List)
{
    if (num > maxB)
        maxB = num;
    if (num < minB)
        minB = num;
}

double sumA = 0, sumB = 0;
double multipleA = 1, multipleB = 1;

foreach (var num in A_List)
{
    sumA += num;
    multipleA *= num;
}
foreach (var num in B_List)
{
    sumB += num;
    multipleB *= num;
}

double sum_of_even_A = 0;

foreach (var num in A_List)
{
    if (num % 2 == 0) sum_of_even_A += num;
}

double sum_of_odd_colum_B = 0;

for (int j = 0; j < 4; j++)
{
    for (int i = 0; i < 3; i++)
        if (j % 2 != 0) sum_of_odd_colum_B += B_List[i, j];
}

Console.WriteLine(" ");
Console.WriteLine($"Maximum element in list A: {maxA}");
Console.WriteLine(" ");
Console.WriteLine($"Minimum element in list B: {minB}");
Console.WriteLine(" ");
Console.WriteLine($"Sum of elements in list A: {sumA}");
Console.WriteLine(" ");
Console.WriteLine($"Sum of elements in list B: {sumB}");
Console.WriteLine(" ");
Console.WriteLine($"Multiply of elements in list A: {multipleA}");
Console.WriteLine(" ");
Console.WriteLine($"Multiply of elements in list B: {multipleB}");
Console.WriteLine(" ");
Console.WriteLine($"Sum of even elements of list A: {sum_of_even_A}");
Console.WriteLine(" ");
Console.WriteLine($"Sum of odd columns of list B: {sum_of_odd_colum_B}");

//Task 2

Random random1 = new Random();

int[,] arr = new int[5, 5];

int min_elementI = 0;
int min_elementJ = 0;
int max_elementI = 0;
int max_elementJ = 0;
int sum_between_min_max = 0;

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        arr[i, j] = random1.Next(-100, 101);

        Console.Write($"{arr[i, j]}");
        Console.Write("   ");

        if (arr[i, j] < arr[min_elementI, min_elementJ])
        {
            min_elementI = i;
            min_elementJ = j;
        }
        if (arr[i, j] > arr[max_elementI, max_elementJ])
        {
            max_elementI = i;
            max_elementJ = j;
        }
    }
    Console.WriteLine();
}

int startI = Math.Min(min_elementI, max_elementI);
int startJ = Math.Min(min_elementJ, max_elementJ);
int endI = Math.Max(min_elementI, max_elementI);
int endJ = Math.Max(min_elementJ, max_elementJ);

for (int i = startI + 1; i < endI; i++)

    for (int j = startJ + 1; j < endJ; j++)

        sum_between_min_max += arr[i, j];

Console.WriteLine($"Sum of elements between minimum ({arr[min_elementI, min_elementJ]}) and maximum ({arr[max_elementI, max_elementJ]}) elements: {sum_between_min_max}");