/*
    Задача 53: Задайте двумерный массив. Напишите программу,
    которая поменяет местами первую и последнюю строку
    массива.
*/

Console.Clear();

int[,] array = CreateTwoDimensionalArray();
int[,] newArray = CreateTwoDimensionalNewArray(array); 
PrintTwoDimensionalArray(array, newArray);

int[,] CreateTwoDimensionalArray()
{
    int rows = 4;
    int columns = 4;
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
    int[] arr1 = new int[array.GetLength(0)];
    int[] arr2 = new int[array.GetLength(0)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            newArray[i,j] = array[i,j];
            arr1[i] = array[0, j];
            arr2[i] = array[array.GetLength(0) -1, j];
            newArray[0, j] = arr2[i];
            newArray[array.GetLength(0) -1, j] = arr1[i];
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