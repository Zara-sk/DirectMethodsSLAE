using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svyatazar
{
    class QRMethod
    {
        public Matrix A;
        public Matrix X;
        public Matrix Q;
        public Matrix R;

        public Vector F;
        public Vector Y;
        public Vector RES;

        public int N;


        public QRMethod()
        {

        }

        public QRMethod(Matrix a, Vector f)
        {
            N = a.N;

            A = new Matrix(N, N);
            Q = new Matrix(N, N); Q.makeE();
            R = new Matrix(N, N);
            X = new Matrix(N, N);

            F = new Vector(N);
            Y = new Vector(N);
            RES = new Vector(N);

            A.Copy(a);
            X.Copy(a);
            F.Copy(f);
        }

        private void MakeZeroElement(int i, int j)
        {
            double sinFi = X[i][j] / Math.Sqrt(X[i][j] * X[i][j] + X[j][j] * X[j][j]);
            double cosFi = X[j][j] / Math.Sqrt(X[i][j] * X[i][j] + X[j][j] * X[j][j]);

            double res1, res2;

            Matrix Xt = new Matrix(N, N);
            Xt.Copy(X);

            for (int k = 0; k < N; k++)
            {
                res1 = cosFi * X[j][k] + sinFi * X[i][k];
                res2 = -sinFi * X[j][k] + cosFi * X[i][k];
                Xt[j][k] = res1;
                Xt[i][k] = res2;
            }

            for (int k = 0; k < N; k++)
            {
                res1 = cosFi * Q[k][j] + sinFi * Q[k][i];
                res2 = -sinFi * Q[k][j] + cosFi * Q[k][i];
                Q[k][j] = res1;
                Q[k][i] = res2;
            }

            X.Copy(Xt);
        }

        private void BuildMatrixes()
        {
            for(int i = 1; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (X[i][j] > CONST.EPS)
                    {
                        MakeZeroElement(i, j);
                    }
                    X[i][j] = 0;
                }
            }
            R.Copy(X);
        }


        private bool QRMethodCheck()
        {
            return (Q * R == A);
        }

        public Vector Solve()
        {
            BuildMatrixes();

            Q.print();
            R.print();
            Y.Copy(Q.Transpouse() * F);
            Y.print();

            SubstitutionMethod.BackRowSubstitution(R, Y, RES);

            return RES;
        }

    }
}
