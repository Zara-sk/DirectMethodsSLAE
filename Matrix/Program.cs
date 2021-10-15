using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svyatazar
{
    class CONST
    {
        public static double EPS = 1e-10;
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int N = 3;
                Matrix A = new Matrix(N, N);
                Vector F = new Vector(N);
                Vector RES = new Vector(N);

                var Elem_A = new double[][]
                {
                    new double[] { -2, -2, -1 },
                    new double[] {  1,  0, -2 },
                    new double[] {  0,  1,  2 },
                };

                A.Elem = Elem_A;

                var Elem_F = new double[] { -5, -1, 3};
                F.Elem = Elem_F;

                QRMethod Solver = new QRMethod(A, F);
                RES = Solver.Solve();
                RES.print();

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
