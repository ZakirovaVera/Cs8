// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

Console.Clear();

int rows = GetNumberFromUser("Введите число строк массива: ", "Ошибка ввода!");
int columns = GetNumberFromUser("Введите число столбцов массива: ", "Ошибка ввода!");
int startArray = GetNumberFromUser("Введите минимальное число массива: ", "Ошибка ввода!");
int endArray = GetNumberFromUser("Введите максимальное число массива: ", "Ошибка ввода!");

bool isRectangular = RectangularArray(rows, columns);

if (isRectangular == false)
{
    Console.WriteLine("Строки и столбцы равны, прямоугольный массив не получится!");
    return;
}

int[,] array = GetArray(rows, columns, startArray, endArray);
PrintArray(array);
Console.WriteLine();

int[] rowMinSum = FindRowsWithMinimumSum(array);

Console.WriteLine($"[{String.Join(", ", rowMinSum)}]");

bool RectangularArray(int numberRows, int numberColumns)
{
    return numberRows != numberColumns;
}

int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.WriteLine(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

//заполнение массива
int[,] GetArray(int numberRows, int numberColumns, int minValue, int maxValue)
{
    int[,] result = new int[numberRows, numberColumns];
    for (int i = 0; i < numberRows; i++)
    {
        for (int j = 0; j < numberColumns; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

//вывод массива в консоль
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t");
        }
        Console.WriteLine();
    }
}

//сумма строки с минимальной суммой элементов
int[] FindRowsWithMinimumSum(int[,] inArray)
{
    int minSum = 0;
    bool isMinSumEmpty = true;
    int[] arrayMinRow = Array.Empty<int>();

    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        int[] currentArray = new int[inArray.GetLength(1)];
        int sum = 0;

        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            currentArray[j] = inArray[i, j];
            sum += inArray[i, j];
        }

        if (isMinSumEmpty)
        {
            isMinSumEmpty = false;

            minSum = sum;            
            arrayMinRow = currentArray;
        }
        if (sum < minSum)
        {            
            minSum = sum;
            arrayMinRow = currentArray;
        }
    }
    Console.WriteLine(minSum);

    return arrayMinRow;
}
