// Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.

Console.Clear();

int rows = GetNumberFromUser("Введите число строк массива: ", "Ошибка ввода!");
int columns = GetNumberFromUser("Введите число столбцов массива: ", "Ошибка ввода!");
int width = GetNumberFromUser("Введите ширину массива: ", "Ошибка ввода!");

int[,,] array = GetArray(rows, columns, width);
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
int[,,] GetArray(int countRows, int countColumns, int countWidth)
{
    int[] arrRandomNum = GenerateArray(countRows, countColumns, countWidth);
    Console.WriteLine(string.Join(",", arrRandomNum).TrimEnd(','));

    int[,,] result = new int[countRows, countColumns, countWidth];
    int nextIndexRandomNumber = 0;
    for (int k = 0; k < countWidth; k++)
    {
        for (int i = 0; i < countRows; i++)
        {
            for (int j = 0; j < countColumns; j++)
            {
                result[i, j, k] = arrRandomNum[nextIndexRandomNumber];
                nextIndexRandomNumber++;
            }
        }
    }

    return result;
}

//вывод массива в консоль
void PrintArray(int[,,] inArray)
{
    for (int k = 0; k < inArray.GetLength(2); k++)
    {
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                Console.Write($"{inArray[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int[] GenerateArray(int countRows, int countColumns, int countWidth)
{
    int lengthThreeArray = countRows * countColumns * countWidth;
    int[] arrRandomNum = new int[lengthThreeArray];
    for (int i = 0; i < arrRandomNum.Length; i++)
    {
        bool contains = true;
        int next = 0;
        while (contains)
        {
            next = new Random().Next(10, 99 + 1);
            contains = arrRandomNum.Contains(next);
        }
        arrRandomNum[i] = next;
    }

    return arrRandomNum;
}
