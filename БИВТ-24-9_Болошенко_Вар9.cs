// Variant_9
using System;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Messaging;
using System.Xml.Schema;

namespace Exam
{
    public class Program
    { 
        
        public static void Main(string[] args)
        {
            var program = new Program();
            // Task_1:
            // Input: T = 4, D = 6, N = 22
            // Output: time = 83885792

            Console.WriteLine("Task_1:");
            Console.WriteLine(program.Task_1(4, 6, 22));

            // Task_2:
            // Input: speedLimit = 4, motorLimit = 6, turnsPerSec = 22
            // Output: time = 5,899999999999999

            Console.WriteLine("Task_2:");
            Console.WriteLine(program.Task_2(4, 6, 22));



            //// Input:
            ///*   23,   7, -13,  24, -21,  18, 
            //      2,   0,  12, -16, -20, -17, 
            //     22,  21,  -6,  19, -22,  -4, 
            //     -13, 13,  18, -15, -20,  -2, 
            //      3,   7,   1, -20,  22,  -8, 
            //    -22, -11,  13,  -2,   0, -14 */
            // Output:
            /*   23,   0,  -2,  13, -11,  18, 
                 -8,   0, -20,   1, -20,   3, 
                 -2, -20,  -6,  19,  13, -13, 
                 -4, -22,  18, -15,  21,  22, 
                -17,   7, -16,  12,  22,   2, 
                -22, -21,  24, -13,   7, -14 */
            int[,] M = new int[6, 6]
            {
            { 23,   7, -13,  24, -21,  18, },
            { 2,   0,  12, -16, -20, -17, },
            { 22,  21,  -6,  19, -22,  -4, },
            {-13, 13,  18, -15, -20,  -2,},
            { 3,   7,   1, -20,  22,  -8,},
            {-22, -11,  13,  -2,   0, -14},
            };
            program.Task_3(M);


            int[] A = new[] { 17, 17, 2, -10, -1, -20 };
            program.Task_4(ref A);
            ////// Task_4:
            // Input:
            /*   17,  17,   2, -10,  -1, -20 */
            // Output:
            /*  -20, -10,  -1 */

            // Task_5:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*   17,  17,   2, -10,  -1, -20 */
            // Output 1:
            /*   23,   7, -13, -20, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                 17, -11,  13,  -2,   0, -14 */

            /*  -20, -10,  -1,   2,  17,  17 */
            // Output 2:
            /*   23,   7, -13,  17, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -20, -11,  13,  -2,   0, -14 */

            /*   17,  17,   2,  -1, -10, -20 */

        }
        public double Task_1(double T, double D, double N)
        {
            if (N <= 0)
                return 0;

            double total = T;
            for (int i = 1; i < N; i++)
            {
                double cast = total + 10 + (i - 1) * D;
                double nw = T + cast;
                total = cast + nw;
            }
            return total;
            
        }
        public double Task_2(double speedLimit, double motorLimit, double turnsPerSec)
        {
            double time = 0;
            double speed = 0;
            double gear = 1; 
            double turns = 0;
            while (speed < speedLimit)
            {
                if (turns < motorLimit)
                {
                    turns += turnsPerSec;
                    time += 0.5;
                }

                else
                {
                    if (gear >= 5)
                    {
                        turns = motorLimit;
                    }

                    else
                    {
                        gear++;
                        turns -= turns * 0.15;
                        time++;
                        motorLimit += 250;
                    }
                }
                turns = Math.Round(turns);
                speed += turns / 180;
                time += 0.1;
                
            }
            return time;
            //Console.WriteLine(time);
            //return 0;
        }
        public void Task_3(int[,] M)
        {
            int n = M.GetLength(1);
            int m = M.GetLength(0);
            if (M is null)
            {
                return;
            } 
            if (M.GetLength(1) != m || n <= 2)
            {
                return;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (j + i + 1 != n)
                    {
                        int temp = M[n - i - 1, n - j - 1];
                        M[n - i - 1, n - j - 1] = M[i, j];
                        M[i, j] = temp;
                    }
                }
            }
            for (int a = 0; a < n; a++)
            {
                for(int b = 0; b < m; b++)
                {
                    Console.WriteLine(M[a, b]);
                }
            }
        }
        public void Task_4(ref int[] A)
        {
            if (A == null)
            {
                return;
            }
            if (A.Length == 0)
            {
                return;
            }
            int[] negArr = GetNegativeSubArray(A);
            int len = negArr.Length;
            if (len == 0)
            {
                A = negArr;
                return;
            }
            int shift = 10 % len;
            for (int i = 0; i < shift; i++)
            {
                int temp = negArr[len - 1];
                for (int j = len - 1; j > 0; j--)
                {
                    negArr[j] = negArr[j - 1];
                    negArr[0] = temp;
                }
            }
            A = negArr;
            
        }
        public int[] GetNegativeSubArray(int[] array)
        {
            int newLen = 0;
            int len = array.Length;
            for (int i = 0; i < len; i++)
            {
                if (array[i] < 0)
                {
                    newLen++;
                }
            }
            int[]negArr = new int[newLen];
            int iter = 0;
            for (int i = 0; i<len; i++)
            {
                if (array[i] < 0)
                {
                    negArr[iter++] = array[i];
                }
               
            }
            for (int i = 0; i < negArr.Length; i++)
            {
                Console.WriteLine(negArr[i]);
            }
            return negArr;
        }
        public void Task_5(ref int[,] M, ref int[] A, SortArray Op)
        {

        }
        public delegate void SortArray(int[] array);
        public void SortAscending(int[] array) { }
        public void SortDescending(int[] array) { }
        public void FindUpperPartMaxIndex(int[,] matrix, out int maxRow, out int maxCol)
        {
            maxRow = 0; maxCol = 0;
        }
        public void FindLowerPartMinIndex(int[,] matrix, out int minRow, out int minCol)
        {
            minRow = 0; minCol = 0;
        }
    }
}
