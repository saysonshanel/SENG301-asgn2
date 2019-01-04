using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Frontend2.Hardware;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class T0UnitTests
    {

        int[] coinKinds, coinCounts;
        int selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity;
        VendingMachineLogic vendingMachine;

        [TestMethod]
        /*
         * CREATE(5, 10, 25, 100; 3; 10; 10; 10)
            EXTRACT([0])
            CHECK_DELIVERY(0)
            UNLOAD([0])
`           CHECK_TEARDOWN(0; 0)
         * */
        public void TestMethod1()
        {
            coinKinds = new int[] { 5, 10, 25, 100 };
            selectionButtonCount = 3;
            coinRackCapacity = 10;
            popCanRackCapacity = 10;
            receptacleCapacity = 10;

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);

            vendingMachine = new VendingMachineLogic(vm);


            Assert.AreEqual(expected, actual);
        }
    }
}
