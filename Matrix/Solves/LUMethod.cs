using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svyatazar
{
    class LUMethod
    {
        public int FindMainElement(Matrix A, int j)
        {
            int Index = j;
            for (int i = j + 1; i < A.M; i++)
                if (Math.Abs(A.Elem[i][j]) > Math.Abs(A.Elem[Index][j])) Index = i;
            if (Math.Abs(A.Elem[Index][j]) < CONST.EPS) throw new Exception("GaussMethod: degenerate matrix");
            return Index;
        }

        public void DirectWay(Matrix A, Vector F, Matrix Aorig, Vector Forig)
        {
            double help;

            for (int i = 0; i < A.M - 1; i++)
            {
                int I = FindMainElement(A, i);

                if (I != i)
                {
                    var Help = A.Elem[I];
                    A.Elem[I] = A.Elem[i];
                    A.Elem[i] = Help;

                    Help = Aorig.Elem[I];
                    Aorig.Elem[I] = Aorig.Elem[i];
                    Aorig.Elem[i] = Help;

                    help = F.Elem[i];
                    F.Elem[i] = F.Elem[I];
                    F.Elem[I] = help;

                    help = Forig.Elem[i];
                    Forig.Elem[i] = Forig.Elem[I];
                    Forig.Elem[I] = help;
                }

                for (int j = i + 1; j < A.M; j++)
                {
                    help = A.Elem[j][i] / A.Elem[i][i];
                    A.Elem[j][i] = 0;
                    for (int k = i + 1; k < A.N; k++)
                    {
                        A.Elem[j][k] -= help * A.Elem[i][k];
                    }
                    F.Elem[j] -= help * F.Elem[i];
                }

            }
        }

        public void MakeLMatrix(Matrix A, Matrix U, Matrix L)
        {
            for (int i = 1; i < A.N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < j - 1; k++) sum += L.Elem[i][k] * U.Elem[k][j];
                    L.Elem[i][j] = (A.Elem[i][j] - sum) / U.Elem[j][j];
                }
                L.Elem[i][i] = 1;
            }
            L.Elem[0][0] = 1;
        }

        public Vector Solve(Matrix A, Vector F)
        {
            var N = A.N;
            
            Matrix U = new Matrix(N, N);
            Matrix L = new Matrix(N, N);
            Vector Fcpy = new Vector(N);

            Fcpy.Copy(F);
            U.Copy(A);

            DirectWay(U, Fcpy, A, F);
            U.print();
            Console.WriteLine();
            Fcpy.print();
            Console.WriteLine();
            A.print();
            Console.WriteLine();
            F.print();
            MakeLMatrix(A, U, L);

            Vector Y = new Vector(N);
            Vector RES = new Vector(N);

            SubstitutionMethod.DirectRowSubstitution(L, F, Y);
            SubstitutionMethod.BackRowSubstitution(U, Y, RES);

            return RES;
        }
    }
}
