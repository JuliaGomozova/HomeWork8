/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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

int[,,] Init3DMatrix(int l, int m, int n)
{
    int len = 90;
    int[] nums = new int[len];
    int[,,] matrix = new int[l, m, n];
    Random rnd = new Random();
    for (int i = 0; i < 90; i++)
    {
        nums[i] = i + 10;
    }
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < n; k++)
            {
                int pos = rnd.Next(0, len);
                matrix[i, j, k] = nums[pos];
                len--;
                Console.Write($"{matrix[i,j,k]}({i},{j},{k}) ");
                for (int x = pos; x < len; x++)
                    nums[x] = nums[x + 1];
            }
            
        }
        
    }
    return matrix;
}


int l = GetNumber("Введите число 1 измерения матрицы:");
int m = GetNumber("Введите число 2 измерения матрицы:");
int n = GetNumber("Введите число 3 измерения матрицы:");
if(l*m*n > 90) 
    Console.WriteLine("Слишком большие размеры массива, для заполнения неповторяющимися двузначными числами");
else
    Init3DMatrix(l, m, n);