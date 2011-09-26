using System;
using NUnit.Framework;

namespace NumberToLCD
{
    [TestFixture]
    public class NumberToLcdTests
    {
        private NumberToLcdConverter lcdConverter;

        [SetUp]
        public void Setup()
        {
            lcdConverter = new NumberToLcdConverter();
        }

        [Test]
        public void should_write_1_as_LCD()
        {
            var expectedLCD =
                       @"   " + Environment.NewLine +
                       @"  |" + Environment.NewLine +
                       @"   " + Environment.NewLine +
                       @"  |" + Environment.NewLine +
                       @"   ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(1));
        }

        [Test]
        public void should_write_2_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @" - " + Environment.NewLine +
                      @"|  " + Environment.NewLine +
                      @" - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(2));
        }

        [Test]
        public void should_write_3_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @" - " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @" - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(3));
        }

        [Test]
        public void should_write_4_as_LCD()
        {
            var expectedLCD =
                      @"   " + Environment.NewLine +
                      @"| |" + Environment.NewLine +
                      @" - " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @"   ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(4));
        }

        [Test]
        public void should_write_5_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"|  " + Environment.NewLine +
                      @" - " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @" - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(5));
        }

        [Test]
        public void should_write_6_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"|  " + Environment.NewLine +
                      @" - " + Environment.NewLine +
                      @"| |" + Environment.NewLine +
                      @" - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(6));
        }

        [Test]
        public void should_write_7_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @"   " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @"   ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(7));
        }

        [Test]
        public void should_write_8_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"| |" + Environment.NewLine +
                      @" - " + Environment.NewLine +
                      @"| |" + Environment.NewLine +
                      @" - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(8));
        }

        [Test]
        public void should_write_9_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"| |" + Environment.NewLine +
                      @" - " + Environment.NewLine +
                      @"  |" + Environment.NewLine +
                      @" - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(9));
        }

        [Test]
        public void should_write_0_as_LCD()
        {
            var expectedLCD =
                      @" - " + Environment.NewLine +
                      @"| |" + Environment.NewLine +
                      @"   " + Environment.NewLine +
                      @"| |" + Environment.NewLine +
                      @" - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(0));
        }

        [Test]
        public void should_write_12_as_LCD()
        {
            var expectedLCD =
                      @"    - " + Environment.NewLine +
                      @"  |  |" + Environment.NewLine +
                      @"    - " + Environment.NewLine +
                      @"  ||  " + Environment.NewLine +
                      @"    - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(12));
        }

        [Test]
        public void should_write_345_as_LCD()
        {
            var expectedLCD =
                      @" -     - " + Environment.NewLine +
                      @"  || ||  " + Environment.NewLine +
                      @" -  -  - " + Environment.NewLine +
                      @"  |  |  |" + Environment.NewLine +
                      @" -     - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(345));
        }

        [Test]
        public void should_write_67890_as_LCD()
        {

            
            var expectedLCD =
                    @" -  -  -  -  - " + Environment.NewLine +
                    @"|    || || || |" + Environment.NewLine +
                    @" -     -  -    " + Environment.NewLine +
                    @"| |  || |  || |" + Environment.NewLine +
                    @" -     -  -  - ";

            Assert.AreEqual(expectedLCD,
                lcdConverter.ConvertNumber(67890));
        }
    }
}
