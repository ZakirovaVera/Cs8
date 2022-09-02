// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.

Console.Clear();

int[,] arrayFirst = InputDataWithArrayFilling();

int[,] arrayTwo = InputDataWithArrayFilling();

PrintArray(arrayFirst);
Console.WriteLine();
PrintArray(arrayTwo);
Console.WriteLine();

int[,] arrayResult = Matrix(arrayFirst, arrayTwo);
PrintArray(arrayResult);

//входные данные с заполнением массива
int[,] InputDataWithArrayFilling()
{
    int rows = GetNumberFromUser("Введите число строк массива: ", "Ошибка ввода!");
    int columns = GetNumberFromUser("Введите число столбцов массива: ", "Ошибка ввода!");
    int startArray = GetNumberFromUser("Введите минимальное число массива: ", "Ошибка ввода!");
    int endArray = GetNumberFromUser("Введите максимальное число массива: ", "Ошибка ввода!");

    return GetArray(rows, columns, startArray, endArray);
}

//ввод данных с клавиатуры
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

int[,] Matrix(int[,] first, int[,] two)
{

    int[,] result = new int[first.GetLength(0), two.GetLength(1)];
    for (int i = 0; i < first.GetLength(0); i++)
    {
        for (int j = 0; j < two.GetLength(1); j++)
        {
            for (int k = 0; k < two.GetLength(0); k++)
            {
                var valueFirs = first[i, k];
                var valueTwo = two[k, j];
                result[i, j] += valueFirs * valueTwo;
            }
        }
    }
    return result;
}


