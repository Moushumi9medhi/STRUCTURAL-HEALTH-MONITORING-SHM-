using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDemo
{
    class complex
    {
        public double real = 0.0;
        public double imag = 0.0;

        //Empty comstructor
        public complex()
        {
            /*real = new double();
            imag = new double();*/
        }

        public complex(double re, double im)
        {
            this.real = re;
            this.imag = im;
        }

        public string ToString()
        {
            string data = real.ToString() + "+" + imag.ToString() + "i";
            return data;
        }

        //convert from polar to rectangular
        public static complex from_polar(double r, double radians)
        {
            complex data = new complex((float)r * Math.Cos(radians), (float)r * Math.Sin(radians));
            return data;
        }

        //Override addition operator
        public static complex operator +(complex a, complex b)
        {
            complex data = new complex(a.real + b.real, a.imag + b.imag);
            return data;
        }

        //Override subtraction operator
        public static complex operator -(complex a, complex b)
        {
            complex data = new complex(a.real - b.real, a.imag - b.imag);
            return data;
        }

        //Override multiplication operator
        public static complex operator *(complex a, complex b)
        {
            complex data = new complex((a.real * b.real) - (a.imag * b.imag), (a.real * b.imag) + (a.imag * b.real));
            return data;
        }

        //Return magnitude of complex number 
        public double magnitude
        {
            get
            {
                return (double)Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2));
            }
        }

        public float phase
        {
            get
            {
                return (float)Math.Atan(imag / real);
               
            }
        }

    }
}
