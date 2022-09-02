// Задача 62: Заполните спирально массив 4 на 4. Метод улитка.

int[,] arr = GenerateArray(4, 4);
PrintArray(arr);

int[,] GenerateArray(int countRow, int countCol)
{
    //Объявляем и инициализируем массив
    int[,] array = new int[countRow, countCol];
    //С помощью переменной s задаются числа внутри массива начиная с 1
    int count = 1;
    //Для заполнения 
    count = GetArrayBySnail(array, 0, 0, count);
    count = GetArrayBySnail(array, 1, 1, count);
    return array;
}
int GetArrayBySnail(int[,] isArray, int startRow, int startColumn, int countNumber)
{
    int countRow = isArray.GetLength(0) - startRow;
    int countCol = isArray.GetLength(1) - startColumn;

    //Заполняем периметр массива по часовой стрелке
    //вправо
    for (int j = startColumn; j < countCol; j++)
    {
        isArray[startRow, j] = countNumber;
        countNumber++;
    }
    //вниз
    for (int i = startRow + 1; i < countRow; i++)
    {
        isArray[i, countCol - 1] = countNumber;
        countNumber++;
    }
    //влево
    for (int j = countCol - 2; j >= startRow; j--)
    {
        isArray[countRow - 1, j] = countNumber;
        countNumber++;
    }
    //вверх
    for (int i = countRow - 2; i > startColumn; i--)
    {
        isArray[i, startColumn] = countNumber;
        countNumber++;
    }

    return countNumber;
}

//вывод массива в консоль
void PrintArray(int[,] isArray)
{
    for (int i = 0; i < isArray.GetLength(0); i++)
    {
        for (int j = 0; j < isArray.GetLength(1); j++)
        {
            Console.Write($"{isArray[i, j]}\t");
        }
        Console.WriteLine();
    }
}
