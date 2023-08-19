using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }

        public override void Run()
        {
            bool dft = true;
            int j = 0;
            double amplitude = 0;
            double phaseShift = 0;
            List<KeyValuePair<float, float>> Values = new List<KeyValuePair<float, float>>();

            //to check last real and img from each n
            // Signal final_real = new DSPAlgorithms.DataStructures.Signal(new List<float>(),true);
            //bool _periodic, List<float> _SignalFrquencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts
            OutputFreqDomainSignal = new DSPAlgorithms.DataStructures.Signal(true, new List<float> { }, new List<float> { }, new List<float> { });
            List<float> final_real = new List<float>();
            List<float> final_imaginary = new List<float>();
            List<KeyValuePair<float, float>> final = new List<KeyValuePair<float, float>>();
            int samples_length = InputTimeDomainSignal.Samples.Count;
            for (int n = 0; n < samples_length; n++)
            {
                double real_part = 0;
                double imaginary_part = 0;
                for (int k = 0; k < samples_length; k++)
                {
                    if (dft == true)
                    {
                        j = -1;
                    }
                    double angle = 2 * Math.PI * k * n / samples_length;
                    //angle = angle * Math.PI / 180;
                    real_part = Math.Round(Math.Cos(angle), 15);
                    imaginary_part = Math.Round((j) * Math.Sin(angle), 15);
                    final_real.Add((float)real_part);
                    final_imaginary.Add((float)imaginary_part);
                }
                for (int i = 0; i < samples_length; i++)
                {
                    final.Add(new KeyValuePair<float, float>(InputTimeDomainSignal.Samples[i] * final_real[i], InputTimeDomainSignal.Samples[i] * final_imaginary[i]));
                }
                final_imaginary.Clear();
                final_real.Clear();
                double sum_real = 0;

                double sum_img = 0;
                for (int i = 0; i < samples_length; i++)
                {
                    sum_real = sum_real + final[i].Key;
                    sum_img = sum_img + final[i].Value;
                }

                amplitude = Math.Sqrt(Math.Pow(sum_real, 2) + Math.Pow(sum_img, 2));
                double d = sum_img * 1.0f / sum_real * 1.0f;
                phaseShift = Math.Atan2(sum_img, sum_real);

                OutputFreqDomainSignal.FrequenciesAmplitudes.Add((float)amplitude);
                OutputFreqDomainSignal.FrequenciesPhaseShifts.Add((float)phaseShift);
                final.Clear();
                Values.Add(new KeyValuePair<float, float>((float)sum_real, (float)sum_img));

            }

        }
    }
}