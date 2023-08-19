using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Adder : Algorithm
    {
        public List<Signal> InputSignals { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            //throw new NotImplementedException();
            List<float> OUTPUT = new List<float>();
            int i;

            for (i = 0; i < InputSignals[1].Samples.Count; i++)
            {
                float res = InputSignals[1].Samples[i] + InputSignals[0].Samples[i];
                OUTPUT.Add(res);
            }
            OutputSignal = new Signal(OUTPUT, true);
        }
    }
}