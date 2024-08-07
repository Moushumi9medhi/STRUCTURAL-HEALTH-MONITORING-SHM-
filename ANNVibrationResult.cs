using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using NeuralNetworks.Functions;
using NeuralNetworks.Layers;
using NeuralNetworks.Learning;
using NeuralNetworks.Networks;
using NeuralNetworks.Neurons;
using System.IO;
using System.Windows.Forms;

namespace CSharpDemo
{
    class ANNVibrationResult
    {
        double[] ip_pred;
        double[] input_pred;
        
        private int numInput;
        private int numHidden;
        private int numOutput;
        private double[][] ihWeights; // input-to-hidden
        private double[] ihSums;
        private double[] ihBiases;
        private double[] ihOutputs;

        private double[][] hoWeights;  // hidden-to-output
        private double[] hoSums;
        private double[] hoBiases;
        private double[] outputs;
        public int cbANNV;
        double[] weights;

        public ANNVibrationResult(int cbANN)
        {
            cbANNV = cbANN;

            this.numInput = 11;
            this.numHidden = cbANNV;
            this.numOutput = 1;
            ip_pred = new double[11];

            ihWeights = Helpers.MakeMatrix(numInput, numHidden);
            ihSums = new double[numHidden];
            ihBiases = new double[numHidden];
            ihOutputs = new double[numHidden];
            hoWeights = Helpers.MakeMatrix(numHidden, numOutput);
            hoSums = new double[numOutput];
            hoBiases = new double[numOutput];
            outputs = new double[numOutput];
            using (TextReader reader = File.OpenText("moushumiForPrediction.txt"))
            {
                input_pred = new double[11];
                string line_ip = reader.ReadLine();
                string[] bits = line_ip.Split(' ');

                for (int j = 0; j < 11; j++)
                {
                    input_pred[j] = double.Parse(bits[j]);
                }

            }
            weights = new double[(11 * cbANNV) + (2 * cbANNV) + 1];
           
            if (cbANNV != 4)
            {
                using (TextReader reader = File.OpenText("weightsnbiases.txt"))
                {
                    string line_wt = reader.ReadLine();
                    string[] bits = line_wt.Split(' ');
                    for (int i = 0; i < (11 * cbANNV) + (2 * cbANNV) + 1; i++)
                    {
                        weights[i] = double.Parse(bits[i]);
                    }
                }
            }
            else
            {
                weights = new double[] {
             0.372,0.052,2.122,0.052,
             0.122, 0.122, 0.172, 0.142,
             0.292, 0.222, 0.492, 0.242,
             0.622, 0.332, 1.362, 0.342,
             0.482, 0.432, 1.462, 0.442,
             0.412, 0.542, 0.692, 0.552,
             0.442, 0.632, 0.662, 0.652,
             0.992, 0.742, 1.412, 0.752,
            0.582, 0.842, 0.602, 0.852,
            1.21, 0.932, 2.192, 0.952,
            0.392, 1.042, 0.102, 1.052,
            -2.002, -5.982, 0.052, -6.992, // Bias values to the hidden layers
             1.432, 1.422, 2.302, 1.612, // four hidden neuron weights connected to one output neurons
            -1.382 };
            }




        }

        public double[] feedforwardANN()
        {



            SetWeights(weights);

            double eta = 0.90;  // learning rate - controls the maginitude of the increase in the change in weights. found by trial and error.
            double alpha = 0.04;// momentum - to discourage oscillation. found by trial and error.
            double[] r;

            r = feedforwardComputeOutputs(input_pred, eta, alpha); // back-propagation online training

            return r;

        }

        public double[] feedforwardComputeOutputs(double[] input_pred, double eta, double alpha)
        {

            for (int i = 0; i < input_pred.Length; ++i) // copy x-values to inputs
                this.ip_pred[i] = input_pred[i];
            for (int i = 0; i < numHidden; ++i)
                ihSums[i] = 0.0;
            for (int i = 0; i < numOutput; ++i)
                hoSums[i] = 0.0;
            for (int j = 0; j < numHidden; ++j)  // compute input-to-hidden weighted sums
                for (int i = 0; i < numInput; ++i)
                    ihSums[j] += this.ip_pred[i] * ihWeights[i][j];

            for (int i = 0; i < numHidden; ++i)  // add biases to input-to-hidden sums
                ihSums[i] += ihBiases[i];

            for (int i = 0; i < numHidden; ++i)   // determine input-to-hidden output
                ihOutputs[i] = SigmoidFunction(ihSums[i]);

            for (int j = 0; j < numOutput; ++j)   // compute hidden-to-output weighted sums
                for (int i = 0; i < numHidden; ++i)
                    hoSums[j] += ihOutputs[i] * hoWeights[i][j];

            for (int i = 0; i < numOutput; ++i)  // add biases to input-to-hidden sums
                hoSums[i] += hoBiases[i];

            for (int i = 0; i < numOutput; ++i)   // determine hidden-to-output result
                this.outputs[i] = HyperTanFunction(hoSums[i]);

            double[] result = new double[numOutput]; // could define a GetOutputs method instead
            this.outputs.CopyTo(result, 0);//copies from outputs to result starting at index 0

            return result;


        }


        public void SetWeights(double[] weights)
        {

            int k = 0; // points into weights param

            for (int i = 0; i < numInput; ++i)
                for (int j = 0; j < numHidden; ++j)
                    ihWeights[i][j] = weights[k++];

            for (int i = 0; i < numHidden; ++i)
                ihBiases[i] = weights[k++];

            for (int i = 0; i < numHidden; ++i)
                for (int j = 0; j < numOutput; ++j)
                    hoWeights[i][j] = weights[k++];

            for (int i = 0; i < numOutput; ++i)
                hoBiases[i] = weights[k++];
        }


        private static double SigmoidFunction(double x)
        {
            if (x < -45.0) return 0.0;
            else if (x > 45.0) return 1.0;
            else return 1.0 / (1.0 + Math.Exp(-x));
        }

        private static double HyperTanFunction(double x)
        {
            if (x < -10.0) return -1.0;
            else if (x > 10.0) return 1.0;
            else return Math.Tanh(x);
        }



    } // class ANNVibrationResult

    public class Helpers
    {
        public static double[][] MakeMatrix(int rows, int cols)
        {
            double[][] resu = new double[rows][];
            for (int i = 0; i < rows; ++i)
                resu[i] = new double[cols];
            return resu;
        }



    } // class Helpers


}//namespace

