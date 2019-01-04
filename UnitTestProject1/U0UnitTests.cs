using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Frontend2.Hardware;
using System.Collections.Generic;

/// <summary>
/// Unit Test for U08-bad-button-number-3
/// </summary>

namespace UnitTestProject1
{

    [TestClass]
    public class U0UnitTests
    {
        int[] coinKinds, coinCounts;
        int selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity;
        VendingMachineLogic expected;

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        /// test for U08-bad-button-number-3
        public void TestMethod1()
        {
            coinKinds = new int[] { 5, 10, 25, 100 };
            selectionButtonCount = 3;
            coinRackCapacity = 0;
            popCanRackCapacity = 0;
            receptacleCapacity = 0;

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);
            vm.SelectionButtons.SetValue(4, 0);
            expected = new VendingMachineLogic(vm);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        /// test for U07-bad-button-number-2
        public void TestMethod2()
        {
            coinKinds = new int[] { 5, 10, 25, 100 };
            selectionButtonCount = 3;
            coinRackCapacity = 0;
            popCanRackCapacity = 0;
            receptacleCapacity = 0;

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);
            vm.SelectionButtons.SetValue(-1, 0);
            expected = new VendingMachineLogic(vm);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        /// test for U06-bad-button-number
        public void TestMethod3()
        {

            coinKinds = new int[] { 5, 10, 25, 100 };
            selectionButtonCount = 3;
            coinRackCapacity = 0;
            popCanRackCapacity = 0;
            receptacleCapacity = 0;

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);
            vm.SelectionButtons.SetValue(3, 0);
            expected = new VendingMachineLogic(vm);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        /// test for U05-bad-coin-kind
        public void TestMethod4()
        {
            coinKinds = new int[] { 0 };
            selectionButtonCount = 1;
            coinRackCapacity = 10;
            popCanRackCapacity = 10;
            receptacleCapacity = 10;

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);
            expected = new VendingMachineLogic(vm);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        /// test for U04-bad-non-unique-denomination
        public void TestMethod5()
        {
            coinKinds = new int[] { 1, 1 };
            selectionButtonCount = 1;
            coinRackCapacity = 10;
            popCanRackCapacity = 10;
            receptacleCapacity = 10;

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);

            expected = new VendingMachineLogic(vm);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        /// test for U03-bad-names-list
        public void TestMethod6()
        {
            coinKinds = new int[] { 5, 10, 25, 100 };
            selectionButtonCount = 3;
            coinRackCapacity = 10;
            popCanRackCapacity = 10;
            receptacleCapacity = 10;

            List<string> name = new List<string>() { "Coke", "water" };
            List<int> cost = new List<int>() { 250, 250 };

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);
            vm.Configure(name, cost);

            expected = new VendingMachineLogic(vm);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        /// test for U02-bad-script2
        public void TestMethod7()
        {

            coinKinds = new int[] { 5, 10, 25, 100 };
            selectionButtonCount = 3;
            coinRackCapacity = 10;
            popCanRackCapacity = 10;
            receptacleCapacity = 10;

            List<string> name = new List<string>() { "Coke", "water", "stuff" };
            List<int> cost = new List<int>() { 250, 250, 0};
            int[] coin = new int[] { 5, 1 };

            VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);
            vm.Configure(name, cost);
            vm.LoadCoins(coin);

        }
        /*    [TestMethod]
            public void TestMethod1()
            {
                coinKinds = new int[] { 5, 10, 25, 100 };
                selectionButtonCount = 3;
                coinRackCapacity = 10;
                popCanRackCapacity = 10;
                receptacleCapacity = 10;

                popCanNames = new List<string>() { "Coke", "water", "stuff" };
                popCanCosts = new List<int>() { 250, 250, 205 };

                coinCounts = new int[] { 5, 1 };

                VendingMachine vm = new VendingMachine(coinKinds, selectionButtonCount, coinRackCapacity, popCanRackCapacity, receptacleCapacity);

                vm.Configure(popCanNames, popCanCosts);
                vm.LoadCoins(coinCounts);

                //instance of vendingmachinelogic to drive the vending machine
                VendingMachineLogic vendingMachine;

                vendingMachine = new VendingMachineLogic(vm);

            */
    }

    
    }
