using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class TimeDelay:Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public float InputSamplingPeriod { get; set; }
        public float OutputTimeDelay { get; set; }

        public override void Run()
        {
            DirectCorrelation C = new DirectCorrelation();
            List<float> S = new List<float>();

            C.InputSignal1 = InputSignal1;
            C.InputSignal2 = InputSignal2;
            C.Run();
            for (int i = 0; i < C.OutputNonNormalizedCorrelation.Count; i++)
            {
                S.Add(Math.Abs(C.OutputNonNormalizedCorrelation[i]));
            }
            OutputTimeDelay = InputSamplingPeriod * C.OutputNonNormalizedCorrelation.IndexOf(S.Max());

            ////////////////////////////
            List<float> R = new List<float>();
            List<float> D = new List<float>();
            List<float> list = new List<float>();


            int N = InputSignal1.Samples.Count;
            float sum1 = 0, sum2 = 0;
            float MAX = 0;
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
            if (InputSignal1.Periodic == true)
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
                            sum += (InputSignal1.Samples[n] * InputSignal2.Samples[(n + j) - N]);
                        }

                    }
                    sum /= N;
                    R.Add(sum);
                    D.Add((R[j] / Mul));
                    if (R[j] > MAX)
                    {
                        MAX = j;
                    }
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
                    D.Add((R[j] / Mul));
                    if (R[j] > MAX)
                    {
                        MAX = j;
                    }
                }
            }

            OutputTimeDelay = MAX * InputSamplingPeriod;
        }
    }
}
