using System;
using System.Security.Cryptography.X509Certificates;

namespace HomeworkCSharp
{
    class TaskOne
    {
        /*  Даден е масив [5,5] от целочислени стойности. 
            Да се намери минималния елемент от всеки стълб.
            От минималните елементи да се намери реда в който е най - малкия (K).
            В нов масив да се запише за всеки минимален елемент I-J*K
            K - Реда в който е минималния елемент; 
        */
        static Random rand = new Random();
        static void InpMatRan(int[,] a) // създава матрица от двумерен масив
        {
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rand.Next(0, 9);
                }
        }
        static void OutMat(int[,] a) // изкарва матрицата на екрана
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
        /*
            Да се намери минималния елемент от всеки стълб.
            От минималните елементи да се намери реда в който е най - малкия (K).
            В нов масив да се запише за всеки минимален елемент I-J*K
            K - Реда в който е минималния елемент; 
         */
        static void MinElement(int[,] a, int x)
        {
            int minVal = 99;

            int[] b = new int[x];//за най-малките елементи
            int[] C = new int[x];//за редовете
            int[] d = new int[x];//за колоните
            int[] f = new int[x];//нов масив с краините изчисления  I-J*K ред- колона по Елемент
            int j, firstIndex = 0, secondIndex = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (j = 0; j < a.GetLength(1); j++)
                {
                    if (a[j, i] < minVal) { firstIndex = i; secondIndex = j; minVal = a[j, i]; } // намира ред колона и минимален елемент на всеки стълб
                }
                b[i] = minVal; //записване на най-малките елементи от всеки стълб в масив
                C[i] = firstIndex;// записва редовете на който се намират елементите от стълбовете
                d[j] = secondIndex;//записва номер на колона на който се намират елементите от стълбовете
            }
            int minValTwo = 99;
            int thirdIndex = 0;
            for (int l = 0; l < x; l++)
            {
                if (b[l] < minValTwo) { minValTwo = b[l]; thirdIndex = l; }// намира най- малкия елемент.
            }
            //  В нов масив да се запише за всеки минимален елемент I - J * K
            for (int t = 0; t < x; t++)
            {
                f[t] = C[t] - d[t] * b[t];
            }
            for (int k = 0; k <= x; k++)
            {
                Console.WriteLine("Изкарване на крайни изчисления: ");
                Console.Write(f[k]);
            }

        }
        public static void Main()
        {
            Console.WriteLine("Матрица с 5 реда и 5 колони рандом числа от 0 до 9:");
            int m = 5, n = 5;
            int[,] a = new int[m, n];
            InpMatRan(a);
            OutMat(a);
            MinElement(a, n);

        }
    }

}     