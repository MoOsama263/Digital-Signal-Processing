using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DSPAlgorithms.DataStructures;
using DSPAlgorithms.Algorithms;

namespace DSPComponentsUnitTest
{
     [TestClass]
    public class accumulator_testcases
    {

         Signal inputSignal, expectedOutputSignal, actualOutputSignal;
         
         [TestMethod]
         public void Accumulator_test1()
         {
             accumulator a = new accumulator();
             inputSignal = new Signal(new List<float>() { 1, 2, 3, 4 }, false);
             a.InputSignal = inputSignal;

             a.Run();
             actualOutputSignal = a.OutputSignal;

             expectedOutputSignal = new Signal(new List<float>() { 1, 3, 6, 10 }, false);

             Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(actualOutputSignal.Samples, expectedOutputSignal.Samples));

         }
    }
}
