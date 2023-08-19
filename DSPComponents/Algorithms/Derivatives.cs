using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Derivatives: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal FirstDerivative { get; set; }
        public Signal SecondDerivative { get; set; }

        public override void Run()
        {

            //throw new NotImplementedException();
            //throw new NotImplementedException();
            /* 
               Compute and display y(n) which represents

                    First Derivative of input signal
                          Y(n) = x(n) - x(n - 1)
                                                              */
            List<float> OUTPUT1 = new List<float>();
            List<float> OUTPUT2 = new List<float>();

            for (int i = 1; i < InputSignal.Samples.Count; i++)
            {
                float res = InputSignal.Samples[i] - InputSignal.Samples[i - 1];
                OUTPUT1.Add(res);
            }
            FirstDerivative = new Signal(OUTPUT1, true);


            /////////////////////////////////////////////////////////
            /*
                         Second derivative of input signal
                        Y(n) = x(n + 1) - 2x(n) + x(n - 1) 
            */
            for (int i = 1; i < InputSignal.Samples.Count; i++)
            {
                if (i == InputSignal.Samples.Count - 1)
                {
                    float res = 0;
                    OUTPUT2.Add(res);
                }
                else
                {
                    float res = InputSignal.Samples[i + 1] - (2 * InputSignal.Samples[i]) + InputSignal.Samples[i - 1];
                    OUTPUT2.Add(res);
                }
            }
            SecondDerivative = new Signal(OUTPUT2, true);
        }
    }
}
