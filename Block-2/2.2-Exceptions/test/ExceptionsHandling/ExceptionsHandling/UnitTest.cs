using NUnit.Framework;
using System;
using ExceptionsHandling;

namespace ExceptionsHandlingTests
{
    public class Tests
    {
        [Test]
        public void DivideByZeroExceptionSuccessTest()
        {
            var divide = new DivideByZero();
            Assert.AreEqual(5, divide._DivideByZero(10, 2));
        }

        [Test]
        public void DivideByZeroExceptionFailTest()
        {
            var divide = new DivideByZero();
            Assert.AreEqual(-1, divide._DivideByZero(10, 0));
        }

        [Test]
        public void IndexOutOfRangeSuccessTest()
        {
            var argument = new IndexOutOfRange();
            Assert.AreEqual(2, argument._IndexOutOfRange(3, 2));
        }

        [Test]
        public void IndexOutOfRangeFailTest()
        {
            var argument = new IndexOutOfRange();
            Assert.AreEqual(-1, argument._IndexOutOfRange(3, 3));
        }

        [Test]
        public void FormatTestSuccessTest()
        {
            var format = new Format();
            Assert.AreEqual(200, format._Format("200"));
        }

        [Test]
        public void FormatTestFailTest()
        {
            var format = new Format();
            Assert.AreEqual(-1, format._Format("Hello"));
        }

        [Test]
        public void IndexOutsideTheBoundsSuccessTest()
        {
            var index = new IndexOutsideTheBounds();
            Assert.AreEqual(0, index._IndexOutsideTheBounds(3, 3));
        }

        [Test]
        public void IndexOutsideTheBoundsFailTest()
        {
            var index = new IndexOutsideTheBounds();
            Assert.AreEqual(-1, index._IndexOutsideTheBounds(3, 4));
        }

        [Test]
        public void UnableCastSuccessTest()
        {
            var cast = new UnableCast();
            Assert.AreEqual(0, cast._UnableCast(false));
        }

        [Test]
        public void UnableCastFailTest()
        {
            var cast = new UnableCast();
            Assert.AreEqual(-1, cast._UnableCast(true));
        }

        [Test]
        public void ValueNullTest()
        {
            var nullExc = new ValueNull();
            Assert.AreEqual(-1, nullExc._ValueNull(null, " "));
        }

        [Test]
        public void OverflowExceptionSuccessTest()
        {
            var overflow = new Overflow();
            Assert.AreEqual(3000, overflow._Overflow(1000, 2000));
        }

        [Test]
        public void OverflowExceptionFailTest()
        {
            var overflow = new Overflow();
            Assert.AreEqual(-1, overflow._Overflow(2147483647, 10));
        }
    }
}