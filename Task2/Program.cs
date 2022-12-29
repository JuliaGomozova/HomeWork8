/*
Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

int GetNumber(string message)
{
    int result = 0;

    while(true)
    {
        Console.WriteLine(message);

        if(int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Ввели не число");
        }
    }
    return result;
}

// Инициализировать рандомный двумерный массив 
int[,] InitMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = rnd.Next(1, 10);
        }
    } 
    return matrix;
}

// Вывести двумерный массив на консоль
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }

    Console.WriteLine();
}

int[] FindSumInRows(int[,] matrix)
{
    int[] sumArray = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sumArray[i] += matrix[i,j]; 
        }

    }
    return sumArray;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

int FindIndexOfMin(int[] array)
{
    int min = array[0];
    int indOfMin = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i] < min)
        {
            min = array[i];
            indOfMin = i;
        }
    }
    return indOfMin;
}

int rows = GetNumber("Зададим двумерный массив, для этого введите количество строк:");
int columns = GetNumber("Количество столбцов:");

Console.WriteLine();

int[,] matrix = InitMatrix(rows, columns); 

PrintMatrix(matrix);
Console.WriteLine();

Console.WriteLine("Суммы элементов в строчках массива:");
PrintArray(FindSumInRows(matrix));
Console.WriteLine($"Минимальная сумма элементов в {FindIndexOfMin(FindSumInRows(matrix))+1} строке");