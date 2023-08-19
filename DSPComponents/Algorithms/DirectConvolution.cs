using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            //throw new NotImplementedException();

            List<float> Samples = new List<float>();
            List<int> SamplesIND = new List<int>();

            int length = (InputSignal1.Samples.Count - 1) + (InputSignal2.Samples.Count - 1);
            int minIndex = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];

            float output;

            for (int n = 0; n <= length; n++)
            {
                output = 0;
                for (int k = 0; k <= n; k++)
                {
                    if (k < InputSignal1.Samples.Count)
                    {
                        if ((n - k) < InputSignal2.Samples.Count)
                        {
                            output += InputSignal1.Samples[k] * InputSignal2.Samples[n - k];
                        }
                    }
                }
                Samples.Add(output);
                SamplesIND.Add(minIndex);
                minIndex++;
            }
            OutputConvolvedSignal = new Signal(Samples, false);

            // Setting Indcies
            for (int i = 0; i < SamplesIND.Count; i++)
            {
                OutputConvolvedSignal.SamplesIndices[i] = SamplesIND[i];
            }

            // Removing ZERO's from Samples
            //////////////////////
            for (int i = 0; i < OutputConvolvedSignal.Samples.Count; i++)
            {
                if (OutputConvolvedSignal.Samples[OutputConvolvedSignal.Samples.Count - 1] == 0)
                {
                    OutputConvolvedSignal.Samples.RemoveAt(OutputConvolvedSignal.Samples.Count - 1);
                    OutputConvolvedSignal.SamplesIndices.RemoveAt(OutputConvolvedSignal.SamplesIndices.Count - 1);
                }
            }

            for (int i = 0; i < OutputConvolvedSignal.Samples.Count; i++)
            {
                if (OutputConvolvedSignal.Samples[0] == 0)
                {
                    OutputConvolvedSignal.Samples.RemoveAt(0);
                    OutputConvolvedSignal.SamplesIndices.RemoveAt(0);
                }
            }
        }
    }
}
