using DSPAlgorithms.Algorithms;
using DSPAlgorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DSPComponentsUnitTest
{
    [TestClass]
    public class Task2TestCases
    {
        [TestMethod]
        public void Task2TestCaseECG()
        {
            Task2 T2_Obj = new Task2();
            T2_Obj.SignalPath = "TestingSignals/ecg400.ds";
            T2_Obj.miniF = 150;
            T2_Obj.maxF = 250;
            T2_Obj.Fs = 1000;

            var signal = UnitTestUtitlities.LoadSignal(T2_Obj.SignalPath);
            T2_Obj.Run();
            Signal Res = T2_Obj.OutputFreqDomainSignal;
            var expectedOutput = UnitTestUtitlities.LoadSignal("F:/4th_YEAR_SC/Second Term/DSP/Task _ Package/fcisdsp-dsp.toolbox-78ddd969882b/fcisdsp-dsp.toolbox-78ddd969882b/DSPToolbox/DSPComponentsUnitTest/TestingSignals//DFT_Res.ds");

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.FrequenciesAmplitudes, Res.FrequenciesAmplitudes)
                && UnitTestUtitlities.SignalsPhaseShiftsAreEqual(expectedOutput.FrequenciesPhaseShifts, Res.FrequenciesPhaseShifts));
        }
    }
}
