using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DCT : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            //The DCT  transforms a signal from the time domain to the frequency domain
            List<float> y = new List<float>();
            int N = InputSignal.Samples.Count;
            float sum;
            for (int k = 0; k < N; k++)
            {
                sum = 0;
                for (int i = 0; i < N; i++)
                    sum += InputSignal.Samples[i] * ((float)Math.Cos((2 * i - 1) * (2 * k - 1) * Math.PI / (4 * N)));
                sum *= (float)Math.Sqrt(2.0 / N);
                y.Add(sum);  //Adds the DCT coefficient to the list of coefficients
            }
            OutputSignal = new Signal(y, true);  //new Signal object from the list of DCT coefficients and assigns it to the OutputSignal variable
        }
    }
}