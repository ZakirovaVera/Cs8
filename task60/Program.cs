// Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.

Console.Clear();

int rows = GetNumberFromUser("Введите число строк массива: ", "Ошибка ввода!");
int columns = GetNumberFromUser("Введите число столбцов массива: ", "Ошибка ввода!");
int width = GetNumberFromUser("Введите ширину массива: ", "Ошибка ввода!");
int startArray = GetNumberFromUser("Введите минимальное число массива: ", "Ошибка ввода!");
int endArray = GetNumberFromUser("Введите максимальное число массива: ", "Ошибка ввода!");

int[,,] array = GetArray(rows, columns, width, startArray, endArray);
PrintArray(array);
Console.WriteLine();


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
int[,,] GetArray(int row, int column, int width, int minValue, int maxValue)
{
    int[,,] result = new int[row, column,width];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            for (int k = 0; k < width; k++)
            {
            result[i, j,k] = new Random().Next(minValue, maxValue + 1);
            }
        }
    }
    return result;
}

//вывод массива в консоль
void PrintArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
            Console.Write($"{inArray[i, j, k]}\t");
            }
        }
        Console.WriteLine();
    }
}
