using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class QuantizationAndEncoding : Algorithm
    {
        // You will have only one of (InputLevel or InputNumBits), the other property will take a negative value
        // If InputNumBits is given, you need to calculate and set InputLevel value and vice versa
        public int InputLevel { get; set; }
        public int InputNumBits { get; set; }
        public Signal InputSignal { get; set; }
        public Signal OutputQuantizedSignal { get; set; }
        public List<int> OutputIntervalIndices { get; set; }
        public List<string> OutputEncodedSignal { get; set; }
        public List<float> OutputSamplesError { get; set; }

        public override void Run()
        {
            //throw new NotImplementedException();
            OutputIntervalIndices = new List<int>();
            OutputSamplesError = new List<float>();
            OutputEncodedSignal = new List<string>();
            float Max, Min;
            List<float> StartInterval = new List<float>();
            List<float> EndInterval = new List<float>();
            List<float> MidPoint = new List<float>();
            List<float> Output = new List<float>();

            // Level or Bits
            if (InputLevel == 0)
            {
                InputLevel = (int)Math.Pow(2, InputNumBits);
            }
            if (InputNumBits == 0)
            {
                InputNumBits = (int)Math.Log(InputLevel, 2);
            }

            // GET delta

            Max = InputSignal.Samples.Max();
            Min = InputSignal.Samples.Min();
            float Delta = (Max - Min) / InputLevel;

            // Intervals and Midpoints

            float init = Min;
            for (int a = 0; a < InputLevel; a++)
            {
                StartInterval.Add(init);
                init += Delta;
                init = (float)Math.Round(init, 3);
                EndInterval.Add(init);
                float mid = (StartInterval[a] + EndInterval[a]) / 2;
                MidPoint.Add(mid);
            }

            // Midpoint index and Quantized Value
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                for (int j = 0; j < InputLevel; j++)
                {
                    if (InputSignal.Samples[i] >= StartInterval[j] && InputSignal.Samples[i] <= EndInterval[j])
                    {
                        OutputIntervalIndices.Add(j + 1);        //OutputIntervalIndices
                        Output.Add(MidPoint[j]);

                        break;
                    }
                }
            }
            OutputQuantizedSignal = new Signal(Output, true);  //OutputQuantizedSignal 

            // ERROR
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                float Error = OutputQuantizedSignal.Samples[i] - InputSignal.Samples[i];
                OutputSamplesError.Add(Error);                   //OutputSamplesError
            }

            // ENCODE
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                string encode = Convert.ToString(OutputIntervalIndices[i] - 1, 2).PadLeft(InputNumBits, '0');
                OutputEncodedSignal.Add(encode);          //OutputEncodedSignal
            }
        }
    } 


}
