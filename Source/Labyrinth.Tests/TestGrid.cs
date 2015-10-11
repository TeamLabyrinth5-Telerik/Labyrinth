namespace Labyrinth.Tests
{
    using System;
    using Labyrinth.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void TestConstructorIfReturnValidRowLenthWithSeven()
        {
            var grid = new Grid(7, 7);
            var expect = grid.TotalRows;
            var actual = 7;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestConstructorIfReturnValidColLenthWithSeven()
        {
            var grid = new Grid(7, 7);
            var expect = grid.TotalCols;
            var actual = 7;
            Assert.AreEqual(expect, actual);
        }

        public void TestConstructorIfReturnValidRowLenthWithDefautValue()
        {
            var grid = new Grid();
            var expect = grid.TotalRows;
            var actual = 15;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestConstructorIfReturnValidColLenthWithDefautVAlue()
        {
            var grid = new Grid();
            var expect = grid.TotalCols;
            var actual = 15;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestSetCellMethodIfSetCurrectlyValueWithIntValueParameter()
        {
            var grid = new Grid();
            grid.SetCell(3, 3, 'X');
            var expect = 'X';
            var actual = grid.Field[3, 3];
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestGetCellMethodIfGetCurrectlyValueWithIntValueParameter()
        {
            var grid = new Grid();
            grid.SetCell(3, 3, 'X');
            var expect = 'X';
            var actual = grid.GetCell(3, 3);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestSetCellMethodIfSetCurrectlyValueWithPositionValue()
        {
            var position = new Position(3, 3);
            var grid = new Grid();
            grid.SetCell(position.X, position.Y, 'X');
            var expect = 'X';
            var actual = grid.Field[3, 3];
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestGetCellMethodIfGetCurrectlyValueWithIntPositionValue()
        {
            var position = new Position(3, 3);
            var grid = new Grid();
            grid.SetCell(position.X, position.Y, 'X');
            var expect = 'X';
            var actual = grid.GetCell(3, 3);
            Assert.AreEqual(expect, actual);
        }
    } 
}