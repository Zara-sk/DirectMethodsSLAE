using System;
using System.Diagnostics;

namespace Svyatazar
{
    class CONST
    {
        public static double EPS = 1e-10;
    }

    class Program
    {
        static double getDelta(Vector x_true, Vector x)
        {
            double RES;

            RES = (x - x_true) * (x - x_true) / (x_true * x_true);

            return RES;
        }
        static void Main(string[] args)
        {
            try
            {
                int[] ns = { 2, 5, 10 };
                foreach(int N in ns)
                {
                    Console.WriteLine($"Для N = {N}");
                    Matrix A = new Matrix(N, N);
                    A.Hilbert();
                    Vector F = new Vector(N);
                    Vector RES = new Vector(N);
                    Vector RES_true = new Vector(N, 1);

                    F = A * RES_true;

                    Matrix Av = new Matrix(N, N);
                    Vector Fv = new Vector(N);

                    //gauss
                    Console.WriteLine();
                    Av.Copy(A);
                    Fv.Copy(F);

                    GaussMethod GaussSolver = new GaussMethod();
                    RES = GaussSolver.Solve(Av, Fv);
                    RES.print();
                    Console.WriteLine($"delta for Gauss = {getDelta(RES_true, RES)}");


                    //lu
                    Console.WriteLine();
                    Av.Copy(A);
                    Fv.Copy(F);

                    LUMethod LUSolver = new LUMethod();
                    RES = LUSolver.Solve(Av, Fv); 
                    RES.print();
                    Console.WriteLine($"delta for LU = {getDelta(RES_true, RES)}");

                    //qr
                    Console.WriteLine();
                    Av.Copy(A);
                    Fv.Copy(F);

                    QRMethod QRSolver = new QRMethod(Av, Fv);
                    RES = QRSolver.Solve();
                    RES.print();
                    Console.WriteLine($"delta for QR = {getDelta(RES_true, RES)}");


                    Console.WriteLine();
                }

            }
            catch (Exception E)
            {
                Console.WriteLine("\n**some error ocured**");
                Console.WriteLine(E.Message);
            }
            Console.ReadKey();
        }
    }
}
