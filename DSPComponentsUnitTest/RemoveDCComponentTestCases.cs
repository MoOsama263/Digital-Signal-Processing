using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.Algorithms;

namespace DSPComponentsUnitTest
{
      [TestClass]
    public class RemoveDCComponentTestCases
    {
        //input: DC_Component.ds
        //Output: DC_Component_Result.ds
        [TestMethod]
        public void RemoveDCComponentTestMethod1()
        {
            // test case 1 ..
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/DC_Component.ds");

            var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/DC_Component_Result.ds").Samples;

            RemoveDCComponent m = new RemoveDCComponent();
            m.InputSignal = sig1;
            

            m.Run();

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput, m.OutputSignal.Samples));
        }
    }
}
