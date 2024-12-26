using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        if (n < 1 && Math.Abs(k) == 1) return 0;
        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        // end

        return answer;
    }
    public int Factorial(int n)
    {
        int fk = 1;
        for (int i = 1; i <= n; i++)
        {
            fk *= i;
        }
        return fk;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        // проверка на существование треугольника:
        if (first[0] >= (first[1] + first[2])) return -1;
        if (first[1] >= (first[0] + first[2])) return -1;
        if (first[2] >= (first[0] + first[1])) return -1;
        if (second[0] >= (second[1] + second[2])) return -1;
        if (second[1] >= (second[0] + second[2])) return -1;
        if (second[2] >= (second[0] + second[1])) return -1;

        double First = GeronArea(first[0], first[1], first[2]);
        double Second = GeronArea(second[0], second[1], second[2]);

        if (First > Second) return 1;
        if (First < Second) return 2;
        if (First == Second) return 0;

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2.0;
        p = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return p;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours

        double distance_1 = GetDistance(v1, a1, time);
        double dictance_2 = GetDistance(v2, a2, time);
        if (distance_1 > dictance_2) return 1;
        if (distance_1 < dictance_2) return 2;
        if (distance_1 == dictance_2) return 0;

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // use GetDistance(v, a, t); t - hours

        int n = 1;
        while (GetDistance(v1, a1, n) > GetDistance(v2, a2, n))
        {
            n++;
        }
        Console.WriteLine(n);
        // end
        answer = n;


        // end

        return answer;
    }
    public double GetDistance(double v, double a, double t)
    {
        double s = v * t + (a * t * t) / 2;
        return s;
    }

    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);


        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        int maxA = FindMaxIndex(A);
        int maxB = FindMaxIndex(B);
        Console.WriteLine(maxA);
        Console.WriteLine(maxB);
        
        double sumA = 0;
        int countA = 0;
        for (int i = maxA + 1; i < A.Length; i++)
        {
            sumA += A[i];
            countA++;
        }
        double srA = sumA / countA;

        double sumB = 0;
        int countB = 0;
        for (int i = maxB + 1; i < B.Length; i++)
        {
            sumB += B[i];
            countB++;
        }
        double srB = sumB / countB;

        if (A.Length - maxA > B.Length - maxB)
        {
            A[maxA] = srA;
          
        }
        else
        {
            B[maxB] = srB;
        }
        // end
    }
    public int FindMaxIndex(double[] array)
    {
        int imax = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[imax])
            {
                imax = i;
            }
        }
        return imax;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        int max1 = FindDiagonalMaxIndex(A);
        int max2 = FindDiagonalMaxIndex(B);
        Console.WriteLine(max1);
        Console.WriteLine(max2);
        

        for (int i = 0; i < 5; i++)
        {
            int aa = A[max1, i];
            A[max1, i] = B[i, max2];
            B[i, max2] = aa;
            
        }
        Console.WriteLine();
        for (int i = 0; i < A.GetLength(0); i ++)
        {
            for (int j = 0; j < A.GetLength(1); j ++)
            {
                Console.WriteLine(A[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                Console.WriteLine(B[i, j]);
            }
            Console.WriteLine();
        }
        // end
    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int max = matrix[0, 0], imax = 0;
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > max)
            {
                max = matrix[i, i];
                imax = i;
            }
        }
        return imax;
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);
        int maxA = FindMax(A);
        int maxB = FindMax(B);
        Console.WriteLine(maxA);
        A = DeleteElement(A, maxA);

        foreach (int i in A)
        {
            Console.WriteLine(i);
        }

        B = DeleteElement(B, maxB);
        int[] c = new int[A.Length + B.Length];
        for (int i = 0; i < A.Length; i++)
        {
            c[i] = A[i];
        }
        for (int i = 0; i < B.Length; i++)
        {
            c[A.Length + i] = B[i];
        }
        A = c;
        // end
    }
    public int FindMax(int[] array)
    {
        int imax = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[imax])
            {
                imax = i;
            }
        }
        return imax;
    }
    public int[] DeleteElement(int[] array, int index)
    {
        int[] a = new int[array.Length - 1];
        int n = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                a[n] = array[i];
                n++;
            }
        }
        return a;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);
        int maxA = 0;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > A[maxA])
            {
                maxA = i;
            }
        }
        Console.WriteLine(maxA);
        int maxB = 0;
        for (int i = 1; i < B.Length; i++)
        {
            if (B[i] > B[maxB])
            {
                maxB = i;
            }
        }
        SortArrayPart(A, maxA);
        SortArrayPart(B, maxB);
        foreach (int i in A)
        {
            Console.WriteLine(i);
        }
        // end
    }
    public int[] SortArrayPart(int[] array, int startIndex)
    {
        for (int i = startIndex + 1; i < array.Length; i++)
        {
            int key = array[i], j = i - 1;
            while (j > startIndex && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
        return array;
    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        int max = -999, jmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    jmax = j;
                }
            }
        }
        int min = 999, jmin = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min  = matrix[i, j];
                    jmin = j;
                }
            }
        }
        Console.WriteLine(jmax);
        Console.WriteLine(jmin);
        if (jmax > jmin)
        {
            matrix = RemoveColumn(matrix, jmax);
            matrix = RemoveColumn(matrix, jmin);
        }
        else if (jmax < jmin)
        {
            matrix = RemoveColumn(matrix, jmin);
            matrix = RemoveColumn(matrix, jmax);
        }
        else
        {
            matrix = RemoveColumn(matrix, jmax);
        }

        Console.WriteLine();
        foreach (int i in matrix)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        // end
    }
    public int[,] RemoveColumn(int[,] matrix, int columnIndex)
    {
        int c = 0;
        int[,] newmatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j == columnIndex)
            {
                continue;
            }
            for (int i = 0; i < matrix.GetLength(0); i ++)
            {
                newmatrix[i, c] = matrix[i, j];
            }
            c++;
        }
        matrix = newmatrix;
        return matrix;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        int maxA = FindColumnIndex(A);
        int maxB = FindColumnIndex(B);
        Console.WriteLine(maxA);
        Console.WriteLine(maxB);

        for (int i = 0; i < A.GetLength(1); i++)
        {
            int a = A[i, maxA];
            A[i, maxA] = B[i, maxB];
            B[i, maxB] = a;
        }

        // end
    }
    public int FindColumnIndex(int[,] matrix)
    {
        int max = -999, jmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i ++)
        {
            for (int j = 0; j < matrix.GetLength(1); j ++)
            {
                if (matrix[i, j] > max)
                { 
                    max = matrix[i, j];
                    jmax = j;
                }
            }
        }
        return jmax;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
        }

        // end
    }
    public int[,] SortRow(int[,] matrix, int rowIndex)
    {
        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            int key = matrix[rowIndex, j], i = j - 1;
            while (i >= 0 && matrix[rowIndex, i] > key)
            {
                matrix[rowIndex, i + 1] = matrix[rowIndex, i];
                i--;
            }
            matrix[rowIndex, i + 1] = key;
        }
        return matrix;
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);
        SortNegative(A);
        SortNegative(B);
        foreach (int i in A)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        foreach (int i in B)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        // end

    }
    public int[] SortNegative(int[] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
            count++;
            }
        }
        int[] neg = new int[count];
        int n = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                neg[n] = array[i];
                n++;
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1 - i; j ++)
            {
                if (neg[j] < neg[j + 1])
                {
                    int a = neg[j];
                    neg[j] = neg[j + 1];
                    neg[j + 1] = a;
                }
            }
        }
        n = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = neg[n];
                n++;
            }
        }
        return array;
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);
        SortDiagonal(A);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                Console.Write(A[i, j] + " ");
            }
            Console.WriteLine();
        }
        SortDiagonal(B);
        // end
    }
    public int[,] SortDiagonal(int[,] matrix)
    {
        int[] diagonal = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            diagonal[i] = matrix[i, i];
        }
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            int key = diagonal[i], j = i - 1;
            while (j >= 0 && diagonal[j] > key)
            {
                diagonal[j + 1] = diagonal[j];
                j--;
            }
            diagonal[j + 1] = key;
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[i, i] = diagonal[i];
        }
        return matrix;
    }
    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        A = RemoveCountNull(A);
        B = RemoveCountNull(B);

        // end
    }
    public int[,] RemoveCountNull(int[,] matrix)
    {
        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                matrix = RemoveColumn(matrix, j);
            }
        }
        return matrix;
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }

        foreach (int i in rows)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        cols = FindMaxNegativePerColumn(matrix);

        foreach (int i in cols)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        // end
    }
    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (matrix[rowIndex, j] < 0)
            {
                count++;
            }
        }
        return count;
    }
    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] maxi = new int[matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int max = -999;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] < 0 && matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
            maxi[j] = max;
        }
        return maxi;
    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);
        int i = 0, j = 0;
        FindMaxIndex(A, out i, out j);
        Console.WriteLine(j);
        A = SwapColumnDiagonal(A, j);

        for (int k = 0; k < A.GetLength(0); k++)
        {
            for (int l = 0; l < A.GetLength(1); l++)
            {
                Console.Write(A[k, l] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        FindMaxIndex(B, out i, out j);

        Console.WriteLine(j);

        B = SwapColumnDiagonal(B, j);

        for (int k = 0; k < B.GetLength(0); k++)
        {
            for (int l = 0; l < B.GetLength(1); l++)
            {
                Console.Write(B[k, l] + " ");
            }
            Console.WriteLine();
        }
        // end
    }
    public int FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        row = 0; column = 0;
        int max = -999;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
        return column;
    }
    public int[,] SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int a = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = a;
        }
        return matrix;
    }
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        int maxA = FindRowWithMaxNegativeCount(A);
        Console.WriteLine(maxA);

        int maxB = FindRowWithMaxNegativeCount(B);

        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0;  j < A.GetLength(1); j++)
            {
                int a = A[maxA, j];
                A[maxA, j] = B[maxB, j];
                B[maxB, j] = a;
            }
        }
        for (int k = 0; k < A.GetLength(0); k++)
        {
            for (int l = 0; l < A.GetLength(1); l++)
            {
                Console.Write(A[k, l] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        // end
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int max = -999;
        int imax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (CountNegativeInRow(matrix, i) > max)
            {
                max = CountNegativeInRow(matrix, i);
                imax = i;
            }
        }
        return imax;
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence, -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        answerFirst = FindSequence(first, 0, first.Length - 1);
        Console.WriteLine(answerFirst);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        Console.WriteLine(answerSecond);
        // end
    }
    public int FindSequence(int[] array, int A, int B)
    {
        bool incr = true, decr = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
            {
                decr = false;
            }
            if (array[i] > array[i + 1])
            {
                incr = false;
            }
        }
        if (incr)
        {
            return 1;
        }
        if (decr)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        answerFirst = FindSequence_b(first, 0, first.Length - 1);
        answerSecond = FindSequence_b(second, 0, second.Length - 1);

        // end
    }
    public int[,] FindSequence_b(int[] array, int A, int B)
    {
        int count = 0;
        for (int i = A; i < B; i ++)
        {
            for (int j = i + 1; j <= B; j ++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    count++;
                }
            }
        }
        int n = 0;
        int[,] a = new int[count, 2];
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    a[n, 0] = i;
                    a[n, 1] = j;
                    n++;
                }
            }
        }
        return a;
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        int[,] fi = FindSequence_b(first, 0, first.Length - 1);
        int[,] se = FindSequence_b(second, 0, second.Length - 1);

        answerFirst = FindSequence_max(fi);

        Console.WriteLine(answerFirst);

        answerSecond = FindSequence_max(se);
        // end
    }
    public int[] FindSequence_max(int[,] matrix)
    {
        int max = -999, imax = 0, length = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            length = Math.Abs(matrix[i, 0] - matrix[i, 1]);
            if (length > max)
            {
                max = length;
                imax = i;
            }
        }
        int[] a = new int[2];
        a[0] = matrix[imax, 0];
        a[1] = matrix[imax, 1];
        return a;
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        SortRowStyle sortStyle = default(SortRowStyle);
        for (int i = 0; i < matrix.GetLength(0); i ++)
        {
            if (i % 2 == 0)
            {
                sortStyle = SortAscending;
            }
            else
            {
                sortStyle = SortDescending;
            }
            sortStyle(matrix, i);
        }

        // end
    }
    public delegate int[,] SortRowStyle(int[,] matrix, int rowIndex);

    public int[,] SortAscending(int[,] matrix, int rowIndex)
    {
        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            int key = matrix[rowIndex, j], k = j - 1;
            while (k >= 0 && matrix[rowIndex, k] > key)
            {
                matrix[rowIndex, k + 1] = matrix[rowIndex, k];
                k--;
            }
            matrix[rowIndex, k + 1] = key;
        }
        return matrix;
    }
    public int[,] SortDescending(int[,] matrix, int rowIndex)
    {
        for (int j = 1; j < matrix.GetLength(1); j ++)
        {
            int key = matrix[rowIndex, j], k = j - 1;
            while (k >= 0 && matrix[rowIndex, k] < key)
            {
                matrix[rowIndex, k + 1] = matrix[rowIndex, k];
                k--;
            }
            matrix[rowIndex, k + 1] = key;
        }
        return matrix;
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        GetTriange tr;
        if (isUpperTriangle)
        {
            tr = GetUpperTriange;
        }
        else
        {
            tr = GetLowerTriange;
        }
        answer = GetSum(tr, matrix);
        Console.WriteLine(answer);
        // end

        return answer;
    }
    public delegate int[] GetTriange(int[,] matrix);
    public int[] GetUpperTriange(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i ++)
        {
            for (int j = i; j < matrix.GetLength(1); j ++)
            {
                count++;
            }
        }
        int[] a = new int[count];
        int n = 0;
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                a[n] = matrix[i, j] * matrix[i, j];
                n++;
            }
        }
        return a;
    }
    public int[] GetLowerTriange(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                count++;
            }
        }
        int[] a = new int[count];
        int n = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                a[n] = matrix[i, j] * matrix[i, j];
                n++;
            }
        }
        return a;
    }
    public int GetSum(GetTriange array, int[,] matrix)
    {
        int s = 0;
        int[] a = array(matrix);
        for (int i = 0; i < a.Length; i ++)
        {
            s += a[i];
        }
        return s;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        FindElementDelegate elem_d  = FindDiagonalMaxIndex;
        FindElementDelegate elem_f = FindalFirstRowMaxIndex;
        matrix = SwapColumns(matrix, elem_d, elem_f);

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);
    public int FindalFirstRowMaxIndex(int[,] matrix)
    {
        int max = -999;
        int jmax = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > max)
            {
                max = matrix[0, j];
                jmax = j;
            }
        }
        return jmax;
    }
    public int[,] SwapColumns(int[,] matrix, FindElementDelegate diag, FindElementDelegate fr)
    {
        int i_d = diag(matrix);
        int i_f = fr(matrix);
        for (int i = 0; i < matrix.GetLength(0);i++)
        {
            int a = matrix[i, i_d];
            matrix[i, i_d] = matrix[i, i_f];
            matrix[i, i_f] = a;
        }
        return matrix;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        FindIndex below = default(FindIndex);
        below = FindMaxBelowDiagonalIndex;
        FindIndex above = default(FindIndex);
        above = FindMinAboveDiagonalIndex;
        matrix = RemoveColumns(matrix, below, above);

        // end
    }
    public delegate int FindIndex(int[,] matrix);
    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int max = -999, jmax = 0;
        for (int i = 0; i < matrix.GetLength(0);i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    jmax = j;
                }
            }
        }
        return jmax;
    }
    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int min = 999, jmin = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    jmin = j;
                }
            }
        }
        return jmin;
    }
    public int[,] RemoveColumns(int[,] matrix, FindIndex below, FindIndex above)
    {
        int bel = below(matrix);
        int ab = above(matrix);
        if (bel > ab)
        {
            matrix = RemoveColumn(matrix, bel);
            matrix = RemoveColumn(matrix, ab);
        }
        if (bel < ab)
        {
            matrix = RemoveColumn(matrix, ab);
            matrix = RemoveColumn(matrix, bel);
        }
        else
        {
            matrix = RemoveColumn(matrix, bel);
        }
        return matrix;
    }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        GetNegativeArray searcherRows = GetNegativeCountPerRow;
        GetNegativeArray searcherCols = GetMaxNegativePerColumn;
        FindNegative(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }
    public delegate int GetNegativeArray(int[,] matrix, int index);
    public int GetNegativeCountPerRow(int[,] matrix, int index)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (matrix[index, j] < 0)
            {
                count++;
            }
        }
        return count;
    }
    public int GetMaxNegativePerColumn(int[,] matrix, int index)
    {
        int max = -999;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, index] < 0 && matrix[i, index] > max)
            {
                max = matrix[i, index];
            }
        }
        return max;
    }
    public void FindNegative(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)]; cols = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = searcherRows(matrix, i);
        }
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            cols[i] = searcherCols(matrix, i);
        }
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        IsSequence inc = FindIncreasingSequence;
        IsSequence dec = FindDecreasingSequence;

        answerFirst = DefineSequence(first, inc, dec);
        answerSecond = DefineSequence(second, inc, dec);
        // end
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    public bool FindIncreasingSequence(int[] array, int A, int B)
    {
        bool incr = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
            {
                incr = true;
            }
            else
            {
                incr = false;
                break;
            }
        }
        return incr;
    }
    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        bool decr = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] > array[i + 1])
            {
                decr = true;
            }
            else
            {
                decr = false;
                break;
            }
        }
        return decr;
    }
    public int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1))
        {
            return 1;
        }
        if (findDecreasingSequence(array, 0, array.Length - 1))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        IsSequence inc = FindIncreasingSequence;
        IsSequence dec = FindDecreasingSequence;

        answerFirstIncrease = FindLongestSequence(first, inc);
        answerFirstDecrease = FindLongestSequence(first, dec);

        answerSecondIncrease = FindLongestSequence(second, inc);
        answerSecondDecrease = FindLongestSequence(second, dec);

        // end
    }
    public int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int max = -999;
        int[] aaaarray = new int[2];
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j))
                {
                    int ij = j - i;
                    if (ij > max)
                    {
                        max = ij;
                        aaaarray[0] = i;
                        aaaarray[1] = j;
                    }
                }
            }
        }
        return aaaarray;
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
