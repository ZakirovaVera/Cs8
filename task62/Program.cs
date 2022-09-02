// Задача 62: Заполните спирально массив 4 на 4. Метод улитка.

int[,] arr = GenerateArray(4,6);
PrintArray(arr);

int[,] GenerateArray(int countRow, int countCol)
{
    int[,] arr = new int[countRow, countCol];
    int countNumbers = countRow * countCol;

    int currentRowIndexElement = 0;
    int currentColIndexElement = 0;
    int currentValue = 1;

    int directionNum = 1; // 1 = вправо, 2 = вниз, -1 = влево, -2 = вверх;
    int[] directionCycle = new int[4] { 0, 0, 0, 0 };

    for (int i = 0; i < countNumbers; i++)
    {
        Console.WriteLine($"Direction ({directionNum})");
        Console.WriteLine($"Index ({currentRowIndexElement},{currentColIndexElement})");
        Console.WriteLine($"Value ({currentValue})");

        // Заполняем.       
        arr[currentRowIndexElement, currentColIndexElement] = currentValue;
        currentValue++;
        Console.WriteLine();

        // Определяем конец направления строки ВПРАВО.
        if (directionNum == 1 && currentColIndexElement >= countCol - 1 + directionCycle[1])
        {
            directionNum = 2;
            printString($"New direction ({directionNum})");

            currentRowIndexElement++;
            directionCycle[0]++;
            continue;
        }
        // Определить конец направления столбца ВНИЗ.
        if (directionNum == 2 && currentRowIndexElement >= countRow - 1 + directionCycle[2])
        {
            directionNum = -1;
            printString($"New direction ({directionNum})");

            currentColIndexElement--;
            directionCycle[1]--;
            continue;
        }
        // Определяем конец направления строки ВЛЕВО.
        if (directionNum == -1 && currentColIndexElement <= directionCycle[3])
        {
            directionNum = -2;
            printString($"New direction ({directionNum})");

            currentRowIndexElement--;
            directionCycle[2]--;
            continue;
        }
        // Определить конец направления столбца ВВЕРХ.
        if (directionNum == -2 && currentRowIndexElement <= directionCycle[0])
        {
            directionNum = 1;
            printString($"New direction ({directionNum})");

            currentColIndexElement++;
            directionCycle[3]++;
            continue;
        }


        // Изменить индекс по направлению.
        if (directionNum == 1)
            currentColIndexElement++;
        if (directionNum == -1)
            currentColIndexElement--;
        if (directionNum == 2)
            currentRowIndexElement++;
        if (directionNum == -2)
            currentRowIndexElement--;
        Console.WriteLine($"Next index ({currentRowIndexElement},{currentColIndexElement})");
    }

    return arr;
}

void printString(string text)
{
    Console.WriteLine(text);
    Console.WriteLine();
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

