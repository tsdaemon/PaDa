using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDa.Task2
{
    public class MatrixMultiplicator4
    {
        public int[,] Multiply(int[,] A, int[,] B)
        {
            var result = new int[4, 4];
            throw new Exception();
        }

        private int[,] Multiply2(int[,] A, int[,] B)
        {
            var result = new int[2, 2];
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    for (var k = 0; k < 2; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return result;
        }

        private void CopyToBig(int[,] A, int[,] B, int offset_i, int offset_j)
        {
            for (var i = 0; i < A.GetLength(0); i++)
            {
                for (var j = 0; j < A.GetLength(1); j++)
                {
                    B[i + offset_i, j + offset_j] = A[i, j];
                }
            }
        }

        private int[,] CopyFromBig(int[,] A, int offset_i, int offset_j, int n)
        {
            var result = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = A[i+offset_i, j+offset_j];
                }
            }
            return result;
        }

        private int[,] Sum(int[,] A, int[,] B)
        {
            var C = new int[A.GetLength(0), A.GetLength(1)];
            for(var i = 0; i < A.GetLength(0); i++)
            {
                for (var j = 0; j < A.GetLength(1); j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }
    }
}
