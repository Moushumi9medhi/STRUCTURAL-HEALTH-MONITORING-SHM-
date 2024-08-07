using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDemo
{
    class Fourier
    {
        public static complex[] DFT(complex[] x)
        {
            int N = x.Length;
            complex[] X = new complex[N];

            for (int k = 0; k < N; k++)
            {
                X[k] = new complex(0, 0);

                for (int n = 0; n < N; n++)
                {
                complex temp = complex.from_polar(1, -2 * Math.PI * n * k / (double)N);
                    temp *= x[n];
                    X[k] += temp;
                }
            }
            return X;
        }
        public static  complex[] FFT(complex[] x)
        {
            int N = x.Length;
            complex[] X = new complex[N];

            complex[] d, D, e, E;

            if (N == 1)
            {
                X[0] = x[0];
                return X;
            }
            int k;                                                                                                                         

            e = new complex[N / 2];
            d = new complex[N / 2];

            for (k = 0; k < N / 2; k++)
            {
                e[k] = x[2 * k];
                d[k] = x[2 * k + 1];
            }

            D = FFT(d);
            E = FFT(e);

            for (k = 0; k < N / 2; k++)
            {
             complex temp = complex.from_polar(1, -2 * Math.PI * k / N);
                D[k] *= temp;
            }

            for (k = 0; k < N / 2; k++)
            {
                X[k] = E[k] + D[k];
                X[k + N / 2] = E[k] - D[k];
            }

            return X;

        }
    }
}
