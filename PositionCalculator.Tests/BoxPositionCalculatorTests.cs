using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using PositionCalculator.Calculators;
using PositionCalculator.Data;

namespace PositionCalculator.Tests
{
    [TestFixture]
    public class BoxPositionCalculatorTests
    {
        Data.IDataReader _dataReader;


        [Test]
        public void TestBoxPositionCalculator()
        {
            _dataReader = DataFactory.GetDataFactory("TestData");
            DataSet dsData = _dataReader.LoadData();
            var result = BoxPositionCalculator.Calculate(dsData);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Keys.First(), Is.EqualTo("Arya"));
            Assert.That(result["Arya"].Symbol[0].Symbol, Is.EqualTo("Rel"));
            Assert.That(result["Arya"].Symbol[0].Quantity, Is.EqualTo(20));

            Assert.That(result.Keys.Last(), Is.EqualTo("Misha"));
            Assert.That(result["Misha"].Symbol[0].Symbol, Is.EqualTo("PNB"));
            Assert.That(result["Misha"].Symbol[0].Quantity, Is.EqualTo(10));

        }
    }
}
