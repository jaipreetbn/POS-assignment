using NUnit.Framework;
using POS.BLL;
using POS.BOL;

namespace NUnitTestPOS
{
    public class Tests
    {
        PointOfSaleTerminalBs terminal;

        [SetUp]
        public void Setup()
        {
            terminal = new PointOfSaleTerminalBs();
            terminal.SetPricing(new Product { ProductCode = 'A', PerUnit = 1.25m, Volume = 3, VolumePrice = 3 });
            terminal.SetPricing(new Product { ProductCode = 'B', PerUnit = 4.25m, Volume = 0, VolumePrice = 0 });
            terminal.SetPricing(new Product { ProductCode = 'C', PerUnit = 1m, Volume = 6, VolumePrice = 5 });
            terminal.SetPricing(new Product { ProductCode = 'D', PerUnit = 0.75m, Volume = 0, VolumePrice = 0 });
        }

        [Test]
        public void Test_ABCDABA_Should_Result_13_25()
        {
            terminal.ScanProduct('A');
            terminal.ScanProduct('B');
            terminal.ScanProduct('C');
            terminal.ScanProduct('D');
            terminal.ScanProduct('A');
            terminal.ScanProduct('B');
            terminal.ScanProduct('A');
            var result = terminal.CalculateTotal();
            Assert.AreEqual(result, 13.25);
        }


        [Test]
        public void Test_7C_Should_Result_6()
        {
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            var result = terminal.CalculateTotal();
            Assert.AreEqual(result, 6.00);
        }

        [Test]
        public void Test_ABCD_Should_Result_7_25()
        {
            terminal.ScanProduct('A');
            terminal.ScanProduct('B');
            terminal.ScanProduct('C');
            terminal.ScanProduct('D');
            var result = terminal.CalculateTotal();
            Assert.AreEqual(result, 7.25);
        }

        [Test]
        public void Test_13C_Should_Result_11()
        {
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            terminal.ScanProduct('C');
            var result = terminal.CalculateTotal();
            Assert.AreEqual(result, 11.00);
        }


        [Test]
        public void Test_Invalid_Code_Not_Added_To_Cart()
        {
            terminal.ScanProduct('R');
            var result = terminal.CalculateTotal();
            Assert.AreEqual(result, 0);
        }
    }
}
