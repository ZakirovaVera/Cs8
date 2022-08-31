// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.

Console.Clear();

int rows = GetNumberFromUser("Введите число строк массива: ", "Ошибка ввода!");
int columns = GetNumberFromUser("Введите число столбцов массива: ", "Ошибка ввода!");
int startArray = GetNumberFromUser("Введите минимальное число массива: ", "Ошибка ввода!");
int endArray = GetNumberFromUser("Введите максимальное число массива: ", "Ошибка ввода!");

int[,] array = GetArray(rows, columns, startArray, endArray);
PrintArray(array);
Console.WriteLine();

SortRowsInDescendingOrder(array);
PrintArray(array);

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
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
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

void SortRowsInDescendingOrder(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int k = 0; k < inArray.GetLength(1); k++)
        {
            for (int j = 0; j < inArray.GetLength(1) - 1; j++)
            {
                if (inArray[i, j] < inArray[i, j + 1])
                {
                    int temp = inArray[i, j];
                    inArray[i, j] = inArray[i, j + 1];
                    inArray[i, j + 1] = temp;
                }
            }
        }
    }
}
