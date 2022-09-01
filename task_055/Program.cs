/*
    Задача 55: Задайте двумерный массив. Напишите программу,
    которая заменяет строки на столбцы. В случае, если это
    невозможно, программа должна вывести сообщение для
    пользователя.
*/

//Console.Clear();

Console.Write("Введите число строк массива: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Введите число столбцов массива: ");
int columns = Convert.ToInt32(Console.ReadLine());

if (rows != columns)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Warning! Трансформация массива не возможна -> (разное количество строк и столбцов)!");
    Console.ResetColor();
}
else
{
    int[,] array = CreateTwoDimensionalArray(rows, columns);
    int[,] newArray = CreateTwoDimensionalNewArray(array); 
    PrintTwoDimensionalArray(array, newArray);
}

int[,] CreateTwoDimensionalArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i,j] = new Random().Next(0, 100);
        }
    }
    return array;
}

int[,] CreateTwoDimensionalNewArray(int[,] array)
{
    int[,] newArray = new int[array.GetLength(0), array.GetLength(1)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            newArray[j,i] = array[i,j];
           
        }
    }
    return newArray;
}

void PrintTwoDimensionalArray(int[,] array, int[,] newArray)
{
    int rows = array.GetUpperBound(0) + 1;
    int columns = array.Length / rows;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("[");

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"\t{array[i,j]}");
        }
        Console.WriteLine();
    }
    Console.WriteLine("]");
    Console.ResetColor();
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("[");

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"\t{newArray[i,j]}");
        }
        Console.WriteLine();
    }
    Console.WriteLine("]");
    Console.ResetColor();
}