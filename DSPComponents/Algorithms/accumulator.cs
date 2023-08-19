using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{


    public class accumulator : Algorithm
    {
        public Signal InputSignal { get; set; }

        public Signal OutputSignal { get; set; }



        public override void Run()
        {
            List<float> OUTPUT = new List<float>();
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                float res = 0;
                for (int j = 0; j <= i; j++)
                {
                    res += InputSignal.Samples[j];
                }
                OUTPUT.Add(res);
            }
            OutputSignal = new Signal(OUTPUT, true);


        }
    }
}
