using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }

        public override void Run()
        {
            bool Idft = true;
            int j = 0;
            List<float> values = new List<float>();
            int samples_length = InputFreqDomainSignal.Frequencies.Count;
            List<float> final_real = new List<float>();
            List<float> final_imaginary = new List<float>();
            List<KeyValuePair<float, float>> final = new List<KeyValuePair<float, float>>();
            List<KeyValuePair<float, float>> real_imaginary = new List<KeyValuePair<float, float>>();
            OutputTimeDomainSignal = new DSPAlgorithms.DataStructures.Signal(new List<float> { }, true);
            for (int i = 0; i < samples_length; i++)
            {
                float real = (float)InputFreqDomainSignal.FrequenciesAmplitudes[i] * (float)Math.Round((float)Math.Cos(InputFreqDomainSignal.FrequenciesPhaseShifts[i]), 10);
                float img = (float)InputFreqDomainSignal.FrequenciesAmplitudes[i] * (float)Math.Round((float)Math.Sin(InputFreqDomainSignal.FrequenciesPhaseShifts[i]), 5);
                real_imaginary.Add(new KeyValuePair<float, float>(real, img));
            }
            for (int n = 0; n < samples_length; n++)
            {
                double real_part = 0;
                double imaginary_part = 0;
                for (int k = 0; k < samples_length; k++)
                {
                    if (Idft == true)
                    {
                        j = 1;
                    }
                    double angle = 2 * Math.PI * k * n / samples_length;
                    //angle = angle * Math.PI / 180;
                    real_part = real_imaginary[k].Key * Math.Round(Math.Cos(angle), 10);
                    imaginary_part = real_imaginary[k].Value * Math.Round((j) * Math.Sin(angle), 5);
                    final_real.Add((float)real_part);
                    final_imaginary.Add((float)imaginary_part);
                }

                for (int i = 0; i < samples_length; i++)
                {
                    float f = 1f / (float)samples_length * 1.0f;
                    final.Add(new KeyValuePair<float, float>(f * final_real[i], f * final_imaginary[i] * -1.0f));
                }
                final_imaginary.Clear();
                final_real.Clear();
                float sum_real = 0;

                float sum_img = 0;
                for (int i = 0; i < samples_length; i++)
                {
                    sum_real = sum_real + final[i].Key;
                    sum_img = (float)Math.Round(sum_img + final[i].Value, 1);
                }
                // float sum = sum_real + sum_img;
                OutputTimeDomainSignal.Samples.Add((float)sum_real + sum_img);
                final.Clear();
                values.Add(sum_real + sum_img);
                // double l = 0;
            }
        }
    }
}