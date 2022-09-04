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
PrintTowDimensionalArray(array, newArray);

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
    int[,] temp = new int[array.GetLength(0), array.GetLength(1)];
    int min = array[0, 0];
    //min = GetMinElement(min);
    int[] position = GetPositionMinElement(min);

    temp = CreateTemp(array);
    temp = DeleteRows(temp, position);
    temp = DeleteColumns(temp, position);

    int[,] newArray = new int[temp.GetLength(0) -1, temp.GetLength(1) -1];
    newArray = GetNewArray(temp);

    // while (GetMinElement(newArray, min) == min)
    // {
    //     position = GetPositionMinElement(newArray, min);
    //     temp = DeleteRows(temp, position);
    //     temp = DeleteColumns(temp, position);
    //     newArray = new int[newArray.GetLength(0) -1, newArray.GetLength(1) -1];
    //     newArray = GetNewArray(temp);
    // }
    // if ((GetMinElement(min)) == min)
    // {
    //     temp = DeleteRows(temp, position);
    //     temp= DeleteColumns(temp, position);
    //     newArray = new int[newArray.GetLength(0) -1, newArray.GetLength(1) -1];
    //     newArray = GetNewArray(temp);
    // }
    
    // int GetMinElement(int[,]array, int min)
    // {
    //     for (int i = 0; i < array.GetLength(0); i++)
    //     {
    //         for (int j = 0; j < array.GetLength(1); j++)
    //         {
    //             if (array[i, j] < min) 
    //             {
    //                 min = array[i, j];
    //             }
    //         }
    //     }
    //     return min;
    // }

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

    // Создаем временный массив temp
    int[,] CreateTemp(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                temp[i, j] = array[i, j];
            }
        }
        return temp;
    }

    // Обрезаем строку и колонку записываем результат в новый массив
    int[,] GetNewArray(int[,] temp)
    {
        for (int i = 0; i < newArray.GetLength(0); i++)
        {
            for (int j = 0; j < newArray.GetLength(1); j++)
            {
                newArray[i, j] = temp[i, j];
            }
        }
        return newArray;
    }

    // Удаляем строку строку с min элементом из массива temp 
    int[,] DeleteRows(int[,] temp, int[] position)
    {
        int index = 0;

        for (int i = 0; i < temp.GetLength(0); i++)
        {
            if (i != position[0])
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[index, j] = temp[i, j];
                }
                index++;
            }
        }
        return temp;
    }

    // Удаляем колонку с min элементом из массива temp
    int[,] DeleteColumns(int[,] temp, int[] position)
    {
        int index = 0;

        for (int j = 0; j < temp.GetLength(1); j++)
        {
            if (j != position[1])
            {
                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    temp[i, index] = temp[i, j];
                }
                index++;
            }
        }
        return temp;
    }
    return newArray; 
}

void PrintTowDimensionalArray(int[,] array, int[,] newArray)
{
    Console.ForegroundColor = ConsoleColor.Green;
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

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("[ ");
    
    for (int i = 0; i < newArray.GetLength(0); i++)
    {
        for (int j = 0; j < newArray.GetLength(1); j++)
        {
            Console.Write($"\t{newArray[i, j]}");
        }
        Console.WriteLine();
    }
    
    Console.WriteLine("]");
    Console.ResetColor(); 
}