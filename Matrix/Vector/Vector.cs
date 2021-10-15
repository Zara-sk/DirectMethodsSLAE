using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svyatazar
{
    public interface IVector
    {
        int N { set; get; }
    }

    public class Vector : IVector
    {
        public int N { set; get; }
        public double[] Elem { set; get; }


        public Vector()
        {
        }

        public Vector(int n)
        {
            N = n;
            Elem = new double[n];
        }

        public Vector(int n, int x)
        {
            N = n;
            Elem = new double[n];
            for (int i = 0; i < n; i++)
            {
                Elem[i] = x;
            }
        }

        public static Vector operator *(Vector T, double Scal)
        {
            Vector RES = new Vector(T.N);

            for (int i = 0; i < T.N; i++)
            {
                RES.Elem[i] = T.Elem[i] * Scal;
            }
            return RES;
        }

        public void Dot_Scal(double Scal)
        {
            for (int i = 0; i < N; i++)
            {
                Elem[i] = Elem[i] * Scal;
            }
        }

        public static double operator *(Vector V1, Vector V2)
        {
            if (V1.N != V2.N) throw new Exception("Умножение невозможно (Размеры векторов различны).");

            double Res = 0.0;

            for (int i = 0; i < V1.N; i++)
            {
                Res += V1.Elem[i] * V2.Elem[i];
            }

            return Res;
        }


        public static Vector operator -(Vector V1, Vector V2)
        {
            if (V1.N != V2.N) throw new Exception("Вычитание невозможно (Размеры векторов различны).");

            Vector Res = new Vector(V1.N);

            for (int i = 0; i < V1.N; i++)
            {
                Res.Elem[i] = V1.Elem[i] - V2.Elem[i];
            }

            return Res;
        }

        public static Vector operator +(Vector V1, Vector V2)
        {
            if (V1.N != V2.N) throw new Exception("Сложение невозможно (Размеры векторов различны).");

            Vector RES = new Vector(V1.N);

            for (int i = 0; i < V1.N; i++)
            {
                RES.Elem[i] = V1.Elem[i] * V2.Elem[i];
            }

            return RES;
        }

        public void Sum(Vector T)
        {
            if (N != T.N) throw new Exception("Сложение невозможно (Размеры векторов различны).");

            for (int i = 0; i < N; i++)
            {
                Elem[i] += T.Elem[i];
            }
        }

        public void Copy(Vector T)
        {
            if (N != T.N) throw new Exception("Копирование невозможно (Размеры векторов различны).");

            for (int i = 0; i < N; i++)
            {
                Elem[i] = T.Elem[i];
            }
        }

        public void print()
        {
            foreach (var st in Elem)
            {
                Console.Write(Convert.ToString(st) + " ");
            }
            Console.WriteLine();
        }
    }
}
