using NUnit.Framework;
using PositionCalculator.Calculators;
using PositionCalculator.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator.Tests
{
    [TestFixture]
    public class NetPositionCalculatorTests
    {  
        Data.IDataReader _dataReader;

        [Test]
        public void TestNetPositionCalculator()
        {
            _dataReader = DataFactory.GetDataFactory("TestData");
            DataSet dsData = _dataReader.LoadData();
            var result = NetPositionCalculator.Calculate(dsData);

            Assert.That(result.Count, Is.EqualTo(3));

            Assert.That(result.Keys.First(), Is.EqualTo("Anuj"));
            Assert.That(result["Anuj"].Symbol[0].Symbol, Is.EqualTo("SCI"));
            Assert.That(result["Anuj"].Symbol[0].Quantity, Is.EqualTo(120));

            Assert.That(result.Keys.Skip(1).Take(1).First(), Is.EqualTo("Arya"));
            Assert.That(result["Arya"].Symbol[0].Symbol, Is.EqualTo("Rel"));
            Assert.That(result["Arya"].Symbol[0].Quantity, Is.EqualTo(30));

            Assert.That(result.Keys.Last(), Is.EqualTo("Misha"));
            Assert.That(result["Misha"].Symbol[0].Symbol, Is.EqualTo("PNB"));
            Assert.That(result["Misha"].Symbol[0].Quantity, Is.EqualTo(-10));

        }
        
    }
}
