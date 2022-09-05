Console.Clear();

int[,] array = CreateTwoDimensionalArray();
int[] newArray = GetRowArray(array);
newArray =SortNewArray(newArray); 

PrintTwoDimensionalArray(array);
GetCount(newArray);

int[,] CreateTwoDimensionalArray()
{
    int rows = 4;
    int columns = 4;
    int[,] array = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i,j] = new Random().Next(0, 10);
        }
    }
    return array;
}

int[] GetRowArray(int[,] array)
{
    int[] temp = new int[array.Length];
    int count = 0; 

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            temp[count] = array[i, j];
            count++;
        }
    }
    return temp;
}

int[] SortNewArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] > array[j])
            {
                int temp = array[i];
                array[i] = array[j]; 
                array[j] = temp;
            }
        }
    }
    return array;
}

void GetCount(int[] array)
{
    int count = 1;
    int element = array[0];

    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] != element)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{element} встречается {count} раз.");

            element = array[i];
            count = 1;
        }
        else count++;
    }
    Console.WriteLine($"{element} встречается {count} раз.");
    Console.ResetColor();
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
    Console.WriteLine();
}
