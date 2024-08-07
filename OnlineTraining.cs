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

namespace consoleuseless1
{
    class OnlineTraining
    {
        public  CSharpDemo.ANN refToANN;
        public  string inputboxline;
        public bool keypressinputbox = false;
        public OnlineTraining(CSharpDemo.ANN refANN)
        {
            this.refToANN = refANN;
        }
     
        public  double[] ANNsetup()
        {
            double[,] X;
            double[,] Target_values;

            using (TextReader reader = File.OpenText("moushumi_withtarget.txt"))
            {
                X = new double[10, 11];
                Target_values = new double[10, 1];
                for (int i = 0; i < 10; i++)
                {
                    string line = reader.ReadLine();
                    string[] bits = line.Split(' ');

                    for (int j = 0; j < 12; j++)
                    {
                        if (j == 11)
                        { Target_values[i, 0] = double.Parse(bits[11]); }
                        else
                        { X[i, j] = double.Parse(bits[j]); }


                    }

                }
            }


            double[] xValues = new double[11];
            double[] tValues = new double[1];
            double[] bestWeights;
            NeuralNetwork nn = new NeuralNetwork(11, refToANN.selectedvalue, 1);

            double[] weights = new double[(11 * refToANN.selectedvalue) + (2 * refToANN.selectedvalue) + 1];
            CSharpDemo.inputbox inpbx = new CSharpDemo.inputbox(refToANN);

            try
            {

                if (refToANN.selectedvalue != 4)
                {
                    inpbx.label6.Text = "Enter initial values of weights and biases.";
                  inpbx.label3.Text = "\nFirst " + (11 * refToANN.selectedvalue) + " values:input to hidden weights\nNext " + (refToANN.selectedvalue) + " values:hidden biases\nNext " + (refToANN.selectedvalue) + " values:hidden to output weights\nNext 1 value:output biases";
                    inpbx.ShowDialog();
                    if (inpbx.incompleteInput == false)
                    {
                        string[] bits = inpbx.textBox1.Text.Split(' ');
                        int u = (11 * refToANN.selectedvalue) + (2 * refToANN.selectedvalue) + 1;

                        for (int j = 0; j < u; j++)
                        {

                            weights[j] = double.Parse(bits[j]);

                        }
                    }
                }
                
                else
                {

                    weights =new double[] {
             0.01,0.02,0.03,0.04,
             0.11, 0.12, 0.13, 0.14,
             0.21, 0.22, 0.23, 0.24,
             0.31, 0.32, 0.33, 0.34,
             0.41, 0.42, 0.43, 0.44,
             0.51, 0.52, 0.53, 0.54,
             0.61, 0.62, 0.63, 0.64,
             0.71, 0.72, 0.73, 0.74,
            0.81, 0.82, 0.83, 0.84,
             0.91, 0.92, 0.93, 0.94,
            1.01, 1.02, 1.03, 1.04,
            -2.0, -6.0, -1.0, -7.0, // Bias values to the hidden layers
             1.3, 1.4, 1.5, 1.6, // four hidden neuron weights connected to one output neurons
            -2.5 }; // one output neurons bias value
                }
                if (inpbx.incompleteInput == false)
                {
                    nn.SetWeights(weights);

                    double eta = .01;//initially 0.000001;  // learning rate - controls the maginitude of the increase in the change in weights. found by trial and error.
                    double alpha = 0.001;//initially 0.000000001;// momentum - to discourage oscillation. found by trial and error.
                    double maxEpochs = 1000;////initially 10000000;
                   nn.Train(X, Target_values, maxEpochs, eta, alpha); // back-propagation online training
                }
            }//try

            catch (Exception ex)
            {
                MessageBox.Show("Fatal :" + ex.Message);

            }
            if (inpbx.incompleteInput == false)
            {

            bestWeights = nn.GetWeights();
            using (FileStream fs_wt = new FileStream("WeightsNBiases.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw_wt = new StreamWriter(fs_wt))
            {


                for (int i_wt = 0; i_wt < bestWeights.Length; i_wt++)
                {
                    sw_wt.Write((bestWeights[i_wt].ToString("F") + 2) + " ");
                }

            }


            return bestWeights;
            }
            else
            {
                return null;
            }

        }//ANNsetup



    } // class onlineTraining

    class NeuralNetwork
    {
        double[,] x;
        double[,] target_values;
        private int numInput;
        private int numHidden;
        private int numOutput;

        private double[] inputs;
        private double[][] ihWeights; // input-to-hidden
        private double[] ihSums;
        private double[] ihBiases;
        private double[] ihOutputs;

        private double[][] hoWeights;  // hidden-to-output
        private double[] hoSums;
        private double[] hoBiases;
        private double[] outputs;
        private double[] tvalues;

        private double[] oGrads; // output gradients for back-propagation
        private double[] hGrads; // hidden gradients for back-propagation

        private double[][] ihPrevWeightsDelta;  // for momentum with back-propagation
        private double[] ihPrevBiasesDelta;

        private double[][] hoPrevWeightsDelta;
        private double[] hoPrevBiasesDelta;
        private Random rnd;

        public NeuralNetwork(int numInput, int numHidden, int numOutput)
        {
            rnd = new Random(0); // for InitializeWeights() and Shuffle()
            this.numInput = numInput;
            this.numHidden = numHidden;
            this.numOutput = numOutput;

            inputs = new double[numInput];
            tvalues = new double[numOutput];
            ihWeights = Helpers.MakeMatrix(numInput, numHidden);
            ihSums = new double[numHidden];
            ihBiases = new double[numHidden];
            ihOutputs = new double[numHidden];
            hoWeights = Helpers.MakeMatrix(numHidden, numOutput);
            hoSums = new double[numOutput];
            hoBiases = new double[numOutput];
            outputs = new double[numOutput];

            oGrads = new double[numOutput];
            hGrads = new double[numHidden];

            ihPrevWeightsDelta = Helpers.MakeMatrix(numInput, numHidden);
            ihPrevBiasesDelta = new double[numHidden];
            hoPrevWeightsDelta = Helpers.MakeMatrix(numHidden, numOutput);
            hoPrevBiasesDelta = new double[numOutput];
        }


        public void Train(double[,] x, double[,] target_values, double maxEpoch, double eta, double alpha)
        {
            this.x = x;
            this.target_values = target_values;
            double error = 1;
            double epoch = 0;
            int[] sequence = new int[10];
            for (int i = 0; i < sequence.Length; ++i)
                sequence[i] = i;

            while ((epoch < maxEpoch) && (error > 0.00001))
            {
                Shuffle(sequence);
                for (int trainingDataSet_row = 0; trainingDataSet_row < 10; trainingDataSet_row++)
                {

                    int idx = sequence[trainingDataSet_row];
                    System.Buffer.BlockCopy(x, 8 * 11 * idx, inputs, 0, 8 * 11);
                    System.Buffer.BlockCopy(target_values, 8 * 1 * idx, tvalues, 0, 8 * 1);
                    // Console.WriteLine("Training set" + (trainingDataSet_row + 1));
                    // Helpers.ShowVector(inputs, 8, true);
                    double[] yvalues = ComputeOutputs(inputs);
                    //Console.WriteLine("target value" + (trainingDataSet_row + 1));//+"  :"+(Helpers.ShowVector(tvalues, 4, true))+"\t actual output"+(trainingDataSet_row+1)+"   :"+yValues[0]);
                    // Helpers.ShowVector(tvalues, 4, true);
                    error = Error(tvalues, yvalues);
                    if (error < .00001)
                        continue;
                    else
                        UpdateWeights(tvalues, eta, alpha);

                }//each training tuple

                ++epoch;
 //========================
            using (FileStream fs_wt1 = new FileStream("Error_Epoch.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw_epoch_err= new StreamWriter(fs_wt1))
            {            
                 sw_epoch_err.Write("Error:  " + error.ToString() + " " + "Epoch:  " + epoch.ToString());
                 sw_epoch_err.WriteLine();
            }
            using (FileStream fs_wt2 = new FileStream("Error.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw_epoch = new StreamWriter(fs_wt2))
            {
                sw_epoch.Write(error.ToString() + " ");
            }

            using (FileStream fs_wt3 = new FileStream("Epoch.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw_err = new StreamWriter(fs_wt3))
            {
                sw_err.Write(epoch.ToString()+" ");
            } 
//===========================

            }// while ((epoch < maxEpoch) && (error > 0.001))
            int PP = 0;
        } // Train

        public void Shuffle(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; ++i)
            {
                int r = rnd.Next(0, sequence.Length);//lower bound inclusive and upper bound exclusive
                int tmp = sequence[r];
                sequence[r] = sequence[i];
                sequence[i] = tmp;
            }
        }//shuffle



        public double Error(double[] target, double[] output) // sum absolute error. could put into NeuralNetwork class.
        //see if target should be given 1 value or 2..sir told 1 ..then the target.length not needed.
        {
            double sum = 0.0;
            for (int i = 0; i < target.Length; ++i)
                sum += Math.Abs(target[i] - output[i]);
            return sum;
        }



        public void UpdateWeights(double[] tval, double eta, double alpha) // update the weights and biases using back-propagation, with target values, eta (learning rate), alpha (momentum)
        {
            // assumes that SetWeights and ComputeOutputs have been called and so all the internal arrays and matrices have values (other than 0.0)
            if (tval.Length != numOutput)
                throw new Exception("target values not same Length as output in UpdateWeights");
            // 1. compute output gradients
            for (int i = 0; i < oGrads.Length; ++i)//ograds is an array of same number of elements as the number of output nodes
            {

                double derivative = (1 - outputs[i]) * (1 + outputs[i]); // derivative of tanh..at this moment output values are  same asthe output values calculated   just prior to this operation
                oGrads[i] = derivative * (tval[i] - outputs[i]);
            }

            // 2. compute hidden gradients
            for (int i = 0; i < hGrads.Length; ++i)
            {
                double derivative = (1 - ihOutputs[i]) * ihOutputs[i]; // (1 / 1 + exp(-x))'  -- using output value of neuron
                double sum = 0.0;
                for (int j = 0; j < numOutput; ++j) // each hidden delta is the sum of numOutput terms
                    sum += oGrads[j] * hoWeights[i][j]; // each downstream gradient * outgoing weight
                hGrads[i] = derivative * sum;
            }

            // 3. update input to hidden weights (gradients must be computed right-to-left but weights can be updated in any order
            for (int i = 0; i < ihWeights.Length; ++i) // no of rows of matrix ihweigths ..rows =no of inputs...col=no of hidden nodes
            {
                for (int j = 0; j < ihWeights[0].Length; ++j) // no of elements in the particular row...==no of colmns=no of  hidden nodes
                {
                    double delta = eta * hGrads[j] * inputs[i]; // compute the new delta
                    ihWeights[i][j] += delta; // update
                    ihWeights[i][j] += alpha * ihPrevWeightsDelta[i][j]; // add momentum using previous delta. on first pass old value will be 0.0 but that's OK.
                    ihPrevWeightsDelta[i][j] = delta;//this line is from my side..i think this is needed
                }
            }

            // 3b. update input to hidden biases
            for (int i = 0; i < ihBiases.Length; ++i)
            {
                double delta = eta * hGrads[i] * 1.0; // the 1.0 is the constant input for any bias; could leave out
                ihBiases[i] += delta;
                ihBiases[i] += alpha * ihPrevBiasesDelta[i];
                ihPrevBiasesDelta[i] = delta;//this line is from my side..i think this is needed
            }

            // 4. update hidden to output weights
            for (int i = 0; i < hoWeights.Length; ++i)  // 0..3 (4) as there are 4 hidden nodes =no of rows
            {
                for (int j = 0; j < hoWeights[0].Length; ++j) // 0 (1)as there arevonly 1 output node
                {
                    double delta = eta * oGrads[j] * ihOutputs[i];  // see above: ihOutputs are inputs to next layer
                    hoWeights[i][j] += delta;
                    hoWeights[i][j] += alpha * hoPrevWeightsDelta[i][j];
                    hoPrevWeightsDelta[i][j] = delta;
                }
            }

            // 4b. update hidden to output biases
            for (int i = 0; i < hoBiases.Length; ++i)
            {
                double delta = eta * oGrads[i] * 1.0;
                hoBiases[i] += delta;
                hoBiases[i] += alpha * hoPrevBiasesDelta[i];
                hoPrevBiasesDelta[i] = delta;
            }
        } // UpdateWeights

        public void SetWeights(double[] weights)
        {
            // copy weights and biases in weights[] array to i-h weights, i-h biases, h-o weights, h-o biases
            int numWeights = (numInput * numHidden) + (numHidden * numOutput) + numHidden + numOutput;
            if (weights.Length != numWeights)
                throw new Exception("The weights array length: " + weights.Length + " does not match the total number of weights and biases: " + numWeights);

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

        public double[] GetWeights()
        {
            int numWeights = (numInput * numHidden) + (numHidden * numOutput) + numHidden + numOutput;
            double[] result = new double[numWeights];
            int k = 0;
            for (int i = 0; i < ihWeights.Length; ++i)
                for (int j = 0; j < ihWeights[0].Length; ++j)
                    result[k++] = ihWeights[i][j];
            for (int i = 0; i < ihBiases.Length; ++i)
                result[k++] = ihBiases[i];
            for (int i = 0; i < hoWeights.Length; ++i)
                for (int j = 0; j < hoWeights[0].Length; ++j)
                    result[k++] = hoWeights[i][j];
            for (int i = 0; i < hoBiases.Length; ++i)
                result[k++] = hoBiases[i];
            return result;
        }
        //MODIFICATION ..WHILE DIPLAYING THE WEIGHTHS DISPLAY WHICH WEIGHTS ARE WHAT
        public double[] ComputeOutputs(double[] xvals)
        {
            if (xvals.Length != numInput)
                throw new Exception("Inputs array length " + inputs.Length + " does not match NN numInput value " + numInput);

            for (int i = 0; i < numHidden; ++i)
                ihSums[i] = 0.0;
            for (int i = 0; i < numOutput; ++i)
                hoSums[i] = 0.0;

            for (int i = 0; i < xvals.Length; ++i) // copy x-values to inputs
                this.inputs[i] = xvals[i];

            for (int j = 0; j < numHidden; ++j)  // compute input-to-hidden weighted sums
                for (int i = 0; i < numInput; ++i)
                    ihSums[j] += this.inputs[i] * ihWeights[i][j];

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
        } // ComputeOutputs


        private static double StepFunction(double x) // an activation function that isn't compatible with back-propagation bcause it isn't differentiable
        {
            if (x > 0.0) return 1.0;
            else return 0.0;
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
    } // class NeuralNetwork

    // ===========================================================================

    public class Helpers
    {
        public static double[][] MakeMatrix(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }



    } // class Helpers

}



