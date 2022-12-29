/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/
// Запросить у пользователя целое число
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
}

int[,] MultiplyMatrix(int[,] a, int[,] b)
{
    int[,] c = new int[a.GetLength(0), b.GetLength(1)];

    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < a.GetLength(1); k++)
            {
                sum += a[i,k] * b[k,j];    
            }
            c[i,j] = sum;
        }  
    }
    return c;
}


int rows1 = GetNumber("Введите количество строк матрицы А:");
int columns1 = GetNumber("Введите количество столбцов матрицы А");
int rows2 = columns1;
int columns2 = GetNumber("Введите количество столбцов матрицы B");

int[,] a = InitMatrix(rows1, columns1);
int[,] b = InitMatrix(rows2, columns2);

Console.WriteLine();
Console.WriteLine("Матрица А:");
PrintMatrix(a);

Console.WriteLine("Матрица B:");
PrintMatrix(b);

Console.WriteLine();
Console.WriteLine("A*B:");
PrintMatrix(MultiplyMatrix(a, b));
