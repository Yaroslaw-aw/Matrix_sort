int[,] sorted_matrix = Fill_Array(8, 8);

PrintArray(sorted_matrix);

Matrix_sort(sorted_matrix);

PrintArray(sorted_matrix);

//Сортировка Матрицы
void Matrix_sort(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int last_line = matrix.GetLength(0) - 1 - i;
            int last_column = matrix.GetLength(1) - 1 - j;

            int max = matrix[last_line, last_column];
            int max_i = last_line;
            int max_j = last_column;

            bool flag = true;

            for (int k = 0; k < matrix.GetLength(0) - i && flag; k++)
            {
                for (int l = 0; l < matrix.GetLength(1) && flag; l++)
                {
                    if (k == last_line &&
                        l == matrix.GetLength(1) - j)
                    {
                        flag = false;
                        continue;                        
                    }

                    if (matrix[k, l] > max)
                    {
                        max = matrix[k, l];
                        max_i = k;
                        max_j = l;
                    }
                }
            }       
            int temp = matrix[last_line, last_column];
            matrix[last_line, last_column] = max;
            matrix[max_i, max_j] = temp;
        }
    }
}



// Заполнение двумерного массива случайными числами
int[,] Fill_Array(int m, int n)
{
    int[,] array = new int[m, n];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(0, 100);
        }
    }
    return array;
}

//Вывести массив любого типа на консоль
void PrintArray(Array matrix)
{
    switch (matrix.Rank)
    {
        case 1:
            Console.WriteLine("Ваш массив: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
                Console.Write($"{matrix.GetValue(i)} ");
            Console.WriteLine();
            break;
        case 2:
            Console.WriteLine("Ваш массив: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int l = (int)matrix.GetValue(i, j);

                    Console.Write(l.ToString().PadRight(5));                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            break;
    }
}
