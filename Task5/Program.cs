/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
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
    
// Вывести двумерный массив на консоль
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i,j] < 10) 
                Console.Write($"0{matrix[i,j]} ");
            else
                Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

int size = GetNumber("Введите размер квадратной матрицы");
int[,] spiralMatrix = new int[size,size];
int num = 0;

for (int x = 0; x <= size/2 ; x++)
{   
    for (int i = x; i < size - x; i++)
        spiralMatrix[x, i] = ++num; 
    for (int i = x + 1; i < size - x; i++)
        spiralMatrix[i, size - 1 - x] = ++num; 
    for (int i = size - 2 - x; i >= 0 + x; i--)
        spiralMatrix[size - 1 - x, i] = ++num;
    for (int i = size - 2 - x; i > 0 +x; i--)
        spiralMatrix[i, x] = ++num;
}

PrintMatrix(spiralMatrix);