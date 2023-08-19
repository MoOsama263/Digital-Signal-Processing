using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Shifter : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int ShiftingValue { get; set; }
        public Signal OutputShiftedSignal { get; set; }

        public override void Run()
        {
            // throw new NotImplementedException();
            OutputShiftedSignal = new Signal(new List<float>(), new List<int>(), false);
            if (InputSignal.Periodic)
            {
                ShiftingValue = -1 * ShiftingValue;
                OutputShiftedSignal.Periodic = true;
            }
            for (int i = 0; i < InputSignal.SamplesIndices.Count; i++)
            {
                OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);
                OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] - ShiftingValue);
            }
        }
    }
}
