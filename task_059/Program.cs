/*
    Задача 59: Задайте двумерный массив из целых чисел.
    Напишите программу, которая удалит строку и столбец, на
    пересечении которых расположен наименьший элемент
    массива.
    Например, задан массив:
    1 4 7 2
    5 9 2 3
    8 4 2 4
    5 2 6 7
    Наименьший элемент - 1, на выходе получим
    следующий массив:
    9 4 2
    2 2 6
    3 4 7
*/

Console.Clear();

int[,] array = CreateTowDimensionalArray();
int[,] newArray = CreateNewTowDimensionalArray(array);
string colorGreen = "Green";
string colorRed = "Red";
PrintTowDimensionalArray(array, colorGreen);
PrintTowDimensionalArray(newArray, colorRed);

int[,] CreateTowDimensionalArray()
{
    int[,] array = new int[4, 4];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1, 10);
        }
    }
    return array;
}

int[,] CreateNewTowDimensionalArray(int[,] array)
{
    int min = array[0, 0];
    int[] position = GetPositionMinElement(min);

    int[,] temp = DeleteRowsColumns(array, position);
   
    int[] GetPositionMinElement(int min)
    {
        int[]  position  = new int[2];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < min)
                {
                    min = array[i, j];
                    position[0] = i;
                    position[1] = j;
                }
            }
        }
        return position;
    }

    int[,] DeleteRowsColumns(int[,] array, int[] position)
    {
        int[,] temp = new int[array.GetLength(0) -1, array.GetLength(1) -1];
        int indexI = 0;
        int indexJ = 0;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (i == position[0]) continue;
            else
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == position[1]) continue;
                    temp[indexI, indexJ] = array[i, j];
                    indexJ++;
                }
                indexI++;
                indexJ = 0;
            }
        }
        return temp;
    }
    return temp; 
}

void PrintTowDimensionalArray(int[,] array, string colorName = "Green")
{
    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
    Console.Write("[ ");
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"\t{array[i, j]}");
        }
        Console.WriteLine();
    }
    
    Console.Write("]");
    Console.ResetColor();
    Console.WriteLine();
}
