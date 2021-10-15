using System;


namespace Svyatazar
{
    class SubstitutionMethod
    {
        public static void DirectRowSubstitution(Matrix A, Vector F, Vector RES)
        {
            RES.Copy(F);
            
            for (int i = 0; i < F.N; i++)
            {
                if (Math.Abs(A.Elem[i][i]) < CONST.EPS) throw new Exception("Direct row substitution: division by zero");

                for (int j = 0; j < i; j++)
                {
                    RES.Elem[i] -= A.Elem[i][j] * RES.Elem[j];
                }

                RES.Elem[i] /= A.Elem[i][i];
            }
        }
        /*
        public static void DirectColumnSubstitution(Matrix A, Vector F, Vector RES)
        {

        }
        */
        public static void BackRowSubstitution(Matrix A, Vector F, Vector RES)
        {
            RES.Copy(F);

            for (int i = F.N - 1; i >= 0; i--)
            {
                if (Math.Abs(A.Elem[i][i]) < CONST.EPS) throw new Exception("Back row substitution: division by zero");

                for (int j = F.N - 1; j > i; j--)
                {
                    RES.Elem[i] -= A.Elem[i][j] * RES.Elem[j];
                }

                RES.Elem[i] /= A.Elem[i][i];
            }
        }
        /*
        public static void BacktColumnSubstitution(Matrix A, Vector F, Vector RES)
        {

        }
        */

    }
}
