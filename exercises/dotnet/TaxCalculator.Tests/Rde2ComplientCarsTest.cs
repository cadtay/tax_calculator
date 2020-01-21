using System;
using NUnit.Framework;

namespace TaxCalculator.Tests
{
    class Rde2ComplientCarsTest
    {
        private static readonly DateTime FirstOfJanuary2019 = new DateTime(2019, 1, 1);
        private TaxCalculator _taxCalculator;

        [SetUp]
        public void BeforeEach()
        {
            _taxCalculator = new DefaultTaxCalculator(false);
        }

    }
}
