using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }

        public override void Run()
        {
            OutputNonNormalizedCorrelation = new List<float>();
            OutputNormalizedCorrelation = new List<float>();
            List<float> R = new List<float>();
            List<float> list = new List<float>();
            int N = InputSignal1.Samples.Count;
            float sum1 = 0, sum2 = 0;

            if (InputSignal2 == null)
            {
                if (InputSignal1.Periodic == true)
                {
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        list.Add(InputSignal1.Samples[i]);
                    }
                    InputSignal2 = new Signal(list, true);
                }
                else
                {
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        list.Add(InputSignal1.Samples[i]);
                    }
                    InputSignal2 = new Signal(list, false);
                }
            }

            for (int i = 0; i < InputSignal1.Samples.Count; i++)
            {
                sum1 += (InputSignal1.Samples[i]) * (InputSignal1.Samples[i]);
                sum2 += (InputSignal2.Samples[i]) * (InputSignal2.Samples[i]);
            }
            float SUM = sum1 * sum2;
            SUM = (float)Math.Pow(SUM, .5);
            float Mul = SUM / N;
            if (InputSignal2.Periodic == true)
            {
                for (int j = 0; j < InputSignal2.Samples.Count; j++)
                {
                    float sum = 0;
                    for (int n = 0; n < InputSignal2.Samples.Count; n++)
                    {
                        if ((n + j) < InputSignal2.Samples.Count)
                        {
                            sum += (InputSignal1.Samples[n] * InputSignal2.Samples[n + j]);
                        }
                        else
                        {
                            sum += (InputSignal1.Samples[n] * InputSignal2.Samples[n + j - N]);
                        }
                    }
                    sum /= N;
                    R.Add(sum);
                    float D = R[j];
                    float P = R[j] / Mul;
                    OutputNormalizedCorrelation.Add(P);
                    OutputNonNormalizedCorrelation.Add(D);
                }
            }
            else
            {
                for (int j = 0; j < InputSignal2.Samples.Count; j++)
                {
                    float sum = 0;
                    for (int n = 0; n < InputSignal2.Samples.Count; n++)
                    {
                        if ((n + j) < InputSignal2.Samples.Count)
                        {
                            sum += (InputSignal1.Samples[n] * InputSignal2.Samples[n + j]);
                        }
                        else
                        {
                            sum += 0;
                        }
                    }
                    sum /= N;
                    R.Add(sum);
                    float D = R[j];
                    float P = R[j] / Mul;
                    OutputNormalizedCorrelation.Add(P);
                    OutputNonNormalizedCorrelation.Add(D);
                }
            }
        }
    }
}