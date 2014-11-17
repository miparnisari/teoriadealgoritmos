﻿using System;
using NUnit.Framework;
using TP2;

namespace TP2.Test
{
    [TestFixture]
    public class InventoryManagerTest
    {
        [Test]
        public void ShouldBuildCorrectMatrix()
        {
            // setup
            var data = new InventoryData
            {
                Demands = new[] {10, 12, 9},
                HoldingCost = 4,
                MaxStock = 20,
                NumberOfPeriods = 3,
                OrderCost = 2
            };
            var manager = new InventoryManager();

            // act
            var actualCosts = manager.CalculateResults(data);

            // assert
            const int infinity = int.MaxValue;
            var expectedCosts = new[,]
            {
                {2, 44, 136},
                {infinity, 4, 14},
                {infinity, infinity, 6},
                {2, 4, 6}
            };

            Assert.AreEqual(expectedCosts, actualCosts);
        }
    }
}

