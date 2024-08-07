using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    public class Daubechies
    {
        public double[] h;
        /** forward transform wave coefficients */
        public double[] g;
        public double[] D;
        //public double[] DN;
        public double[] Ih;
        public double[] Ig;

        public double sqrt_3;
        public double denom;
        bool denoisedaub;
        public double[] a;
        public double[] c;
        public double[] ainv;
        public double[] cinv;
        public double medianwvcoeff;
        public double[] sig5 = new double[1024];
        public double sdnoise; double threshold;

        public double[] daubTrans(double[] sig, bool den)//yvals for signal 1024 samples
        {
            double[] sig1 = new double[1024];
            Array.Copy(sig, sig1, 1024);
            denoisedaub = den;
            h = new double[4];
            g = new double[4];

            a = null;
            c = null;

            sqrt_3 = (double)Math.Sqrt(3);
            denom = (double)(4 * (double)Math.Sqrt(2));
            //
            // forward transform scaling (smoothing) coefficients
            //
            h[0] = (1 + sqrt_3) / denom;
            h[1] = (3 + sqrt_3) / denom;
            h[2] = (3 - sqrt_3) / denom;
            h[3] = (1 - sqrt_3) / denom;
            //
            // forward transform wavelet coefficients
            //
            g[0] = h[3];
            g[1] = -h[2];
            g[2] = h[1];
            g[3] = -h[0];



            for (int m = 10; m >= 1; m--)
            {

                sig1 = transform(m, sig1);//everytime  the returned signal  has to be sent or not..check this out

            }

            if (denoisedaub == true)
            {
                double[] coeffdwtformedian = new double[1023];
                Array.Copy(sig1, 1, coeffdwtformedian, 0, 1023);
                Array.Copy(sig1, sig5, 1024);
                for (int cfd = 0; cfd < coeffdwtformedian.Length; cfd++)
                {
                    if (coeffdwtformedian[cfd] < 0)
                        coeffdwtformedian[cfd] = -coeffdwtformedian[cfd];
                }

                Array.Sort(coeffdwtformedian);
                medianwvcoeff = coeffdwtformedian[511];
                sdnoise = Math.Sqrt(medianwvcoeff / 0.6745);
                threshold = sdnoise * Math.Sqrt(2 * Math.Log(1024));
                // soft thresholding
                for (int i = 1; i < 1024; i++)
                {
                    if (Math.Abs(sig5[i]) > threshold)
                    {
                        sig5[i] = (sig5[i] / Math.Abs(sig5[i])) * (Math.Abs(sig5[i]) - threshold);
                    }
                    else
                    {
                        sig5[i] = 0;
                    }

                }
                Ih = new double[4];
                Ig = new double[4];
                Ih[0] = h[2];
                Ih[1] = g[2];
                Ih[2] = h[0];
                Ih[3] = h[3];
                Ig[0] = h[3];
                Ig[1] = g[3];
                Ig[2] = h[1];
                Ig[3] = g[1];

                for (int inv = 1; inv <= 10; inv++)
                {
                    sig5 = inversedwt(sig5, inv);
                }


            }//end of if (denoisedaub == true)

            int p = 1;
            double mean;
            int j;


            D = new double[10];
            // DN = new double[10];

            for (int i = 1; i <= 10; i++)
            {
                double sum = 0;
                for (j = 0; j < (Math.Pow(2, i - 1)); j++)
                {
                    sum += (double)Math.Pow(sig1[p], 2);
                    p++;

                }
                j = 0;
                mean = sum / ((double)Math.Pow(2, i - 1));
                D[10 - i] = (double)Math.Sqrt(mean);
            }
            return D;



        }


        public double[] transform(int n, double[] sig2)
        {

            a = null;
            c = null;
            int npts = (int)Math.Pow(2, n);

            a = new double[sizeof(double) * npts / 2];
            c = new double[sizeof(double) * npts / 2];
            /* see how to declare and  allocate memory to pointers in cshrp..acc to me.. float []a
           a = new float [sizeof(float) * npts/2];*/

            for (int i = 0; i < npts / 2; i++)
            {
                a[i] = h[0] * sig2[(2 * i) % npts] + h[1] * sig2[(2 * i + 1) % npts] + h[2] * sig2[(2 * i + 2) % npts] + h[3] * sig2[(2 * i + 3) % npts];
                c[i] = h[3] * sig2[(2 * i) % npts] - h[2] * sig2[(2 * i + 1) % npts] + h[1] * sig2[(2 * i + 2) % npts]
                    - h[0] * sig2[(2 * i + 3) % npts];
            }

            for (int i = 0; i < npts / 2; i++)
            {
                sig2[i] = a[i];
                sig2[i + npts / 2] = c[i];
            }
            a = null;
            c = null;


            return sig2;

        }

        public double[] inversedwt(double[] cff, int inv2)
        {
            int i;
            ainv = null;
            cinv = null;
            double[] r = null;
            int nptsinv = (int)Math.Pow(2, inv2);
            int nptsd2 = nptsinv / 2;
            ainv = new double[nptsd2];
            cinv = new double[nptsd2];
            for (int iii = 0; iii < nptsd2; iii++)
            {

                ainv[iii] = cff[iii];
                cinv[iii] = cff[nptsd2 + iii];
            }
            r = new double[nptsinv];

            for (i = 0; i < nptsd2; i++)
            {
                r[2 * i] = Ih[0] * ainv[(i - 1 + nptsd2) % nptsd2] + Ih[1] * cinv[(i - 1 + nptsd2) % nptsd2]
                   + Ih[2] * ainv[i] + Ih[3] * cinv[i];

                r[2 * i + 1] = Ig[0] * ainv[(i - 1 + nptsd2) % nptsd2] + Ig[1] * cinv[(i - 1 + nptsd2) % nptsd2]
                   + Ig[2] * ainv[i] + Ig[3] * cinv[i];
            }


            for (i = 0; i < nptsinv; i++)
            {
                cff[i] = r[i];
            }

            r = null;
            return cff;

        }

    }
}
