using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class MovingAverage : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int InputWindowSize { get; set; }
        public Signal OutputAverageSignal { get; set; }
 
        public override void Run()
        {
            //throw new NotImplementedException();
            List<float> OUTPUT = new List<float>();
            List<int> OutIND = new List<int>();

            for (int i = 0; i < InputSignal.Samples.Count - InputWindowSize + 1; i++)
            {
                float Sum = 0;
                for (int j = i; j < i + InputWindowSize; j++)
                {
                    Sum += InputSignal.Samples[j];
                }
                Sum /= (float)InputWindowSize;
                OUTPUT.Add(Sum);
                OutIND.Add(i);
            }
            OutputAverageSignal = new Signal(OUTPUT, OutIND, false);
        }
    }
}
