/*
    Задача 57: Составить частотный словарь элементов
    двумерного массива. Частотный словарь содержит
    информацию о том, сколько раз встречается элемент
    входных данных.
    25 мин
    Набор данных                                           Частотный массив
    { 1, 9, 9, 0, 2, 8, 0, 9 }                              0 встречается 2 раза
                                                            1 встречается 1 раз
                                                            2 встречается 1 раз
                                                            8 встречается 1 раз
                                                            9 встречается 3 раза
    1, 2, 3
    4, 6, 1
    2, 1, 6
                                                            1 встречается 3 раза
                                                            2 встречается 2 раз
                                                            3 встречается 1 раз
                                                            4 встречается 1 раз
                                                            6 встречается 2 раза
*/

Console.Clear();

int[,] array = CreateTwoDimensionalArray();
//int element = GetFrequencyDictionary(array); 
//int[] element = GetFrequencyDictionary(array); 
PrintTwoDimensionalArray(array);
GetFrequencyDictionary(array);

int[,] CreateTwoDimensionalArray()
{
    int rows = 4;
    int columns = 4;
    int[,] array = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i,j] = new Random().Next(1, 10);
        }
    }
    return array;
}

void GetFrequencyDictionary(int[,] array)
{
    //int num = array[0,0];
    
   for (int i = 0; i < array.GetLength(0); i++)
   {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int num = array[i, j];
            int count = GetCount(array, num); 

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{array[i, j]} встречается в массиве {count} раз.");
            Console.ResetColor();
                   
           
        }
   }

   int GetCount(int[,] array, int num, int count = 0)
   {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (num == array[i, j])
                {
                    count++;
                }
            }
        } 
        return count;
    }
}

void PrintTwoDimensionalArray(int[,] array)
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

    // Console.WriteLine($"{array[0, 0]} встречается в массиве {element} раз.");

}

