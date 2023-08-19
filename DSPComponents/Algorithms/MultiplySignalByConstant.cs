using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class MultiplySignalByConstant : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputConstant { get; set; }
        public Signal OutputMultipliedSignal { get; set; }

        public override void Run()
        {
            //throw new NotImplementedException();
            List<float> OUTPUT = new List<float>();
            int i;

            for (i = 0; i < InputSignal.Samples.Count; i++)
            {
                float res = InputSignal.Samples[i] * InputConstant;
                OUTPUT.Add(res);
            }
            OutputMultipliedSignal = new Signal(OUTPUT, true);
        }
    }
}
