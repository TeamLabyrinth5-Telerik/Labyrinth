namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Models;

    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void TestConstructorIfReturnValidRowLenth()
        {
            var grid = new Grid();
            var expect = grid.TotalRows;
            var actual = 7;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestConstructorIfReturnValidColLenth()
        {
            var grid = new Grid();
            var expect = grid.TotalCols;
            var actual = 7;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestSetCellMethodIfSetCurrectlyValue()
        {
            var grid = new Grid();
            grid.SetCell(3, 3, 'X');
            var expect = 'X';
            var actual = grid.Field[3, 3];
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestGetCellMethodIfGetCurrectlyValue()
        {
            var grid = new Grid();
            grid.SetCell(3, 3, 'X');
            var expect = 'X';
            var actual = grid.GetCell(3, 3);
            Assert.AreEqual(expect, actual);
        }
    }
}