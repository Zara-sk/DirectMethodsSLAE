using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svyatazar
{
    public interface IMatrix
    {
        int M { set; get; }
        int N { set; get; }
    }

    public class Matrix : IMatrix
    {
        public int M { set; get; }
        public int N { set; get; }

        public double[][] Elem { set; get; }

        public Matrix(){}

        public Matrix(int m, int n)
        {
            M = m; N = n;
            double [][]elem = new double[m][];
            for (int i = 0; i < m; i++)
            {
                elem[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    elem[i][j] = 0;
                }
            }
            Elem = elem;
        }

        public void Copy(Matrix A)
        {
            if (N != A.N || M != A.M) throw new Exception("Копирование невозможно (Размеры матриц различны).");
            
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    Elem[i][j] = A.Elem[i][j];
            
        }

        public void print()
        {
            foreach (var st in Elem)
            {
                foreach (var el in st)
                {
                    Console.Write(Convert.ToString(el).PadRight(20));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static Matrix operator*(Matrix A, Matrix B)
        {
            if (A.N != B.M || A.M != B.N) throw new Exception("Умножение невожможно(размеры матриц отличаются");

            var RES = new Matrix(A.M, A.N);

            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < B.M; j++)
                    for (int k = 0; k < A.N; k++)
                        RES.Elem[i][j] += A.Elem[i][k] * B.Elem[k][j];
            return RES;
        }
        public static Vector operator *(Matrix A, Vector B)
        {
            if (A.M != B.N) throw new Exception("Умножение невожможно(размеры отличаются");

            var RES = new Vector(A.N);
            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < B.N; j++)
                {
                    RES.Elem[i] += A.Elem[i][j] * B.Elem[j];
                }
            }

            return RES;
        }

        public double[] this[int Index] 
        {
            get
            {
                return Elem[Index];
            }
            set
            {
                Elem[Index] = value;
            }
        }

        public void makeE()
        {
            for (int i = 0; i < N; i++)
            {
                Elem[i][i] = 1;
            }
        }

        public Matrix Transpouse()
        {
            double h1, h2;
            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    h1 = Elem[i][j];
                    h2 = Elem[j][i];
                    Elem[i][j] = h2;
                    Elem[j][i] = h1;
                }
            }
            return this;
        }
    }
}

