using System;
using System.Collections.Generic;
using System.Linq;
using BooliStat.Code;
using NUnit.Framework;
using SharpTestsEx;

namespace BooliStatTest.Tests
{
    public class CreateMedianPricesTest
    {
        [Test]
        public void ShouldReturnThePricePerKvmIfOnlyOne()
        {
            var target = new CreateMedianPrices();
            var result = target.Execute(DateTime.Today, new[]{new SoldApartment(1000, DateTime.Today, 10)});
            result[DateTime.Today]
                .Should().Be.EqualTo(100);
        }

        [Test]
        public void ShouldReturnAveragePricePerKvmIfMultiple()
        {
            var target = new CreateMedianPrices();
            var soldApartments = new List<SoldApartment>
            {
                new SoldApartment(1000, DateTime.Today, 10),
                new SoldApartment(800, DateTime.Today, 10),
                new SoldApartment(90, DateTime.Today, 1)
            };
            var result = target.Execute(DateTime.Today, soldApartments);
            result[DateTime.Today]
                .Should().Be.EqualTo(90);
        }

        [Test]
        public void SkipApartmentsWithNoKnownArea()
        {
            var target = new CreateMedianPrices();
            var soldApartments = new List<SoldApartment>
            {
                new SoldApartment(1000, DateTime.Today, 10),
                new SoldApartment(800, DateTime.Today, 10),
                new SoldApartment(1, DateTime.Today, 0)
            };

            var result = target.Execute(DateTime.Today, soldApartments);
            result[DateTime.Today]
                .Should().Be.EqualTo(90);
        }

        [Test]
        public void ShouldOnlyReturnValueAfterFromDate()
        {
            var target = new CreateMedianPrices();
            var soldApartments = new List<SoldApartment>
            {
                new SoldApartment(100, DateTime.Today.AddDays(-1), 1),
            };

            var result = target.Execute(DateTime.Today, soldApartments);
            result.Should().Be.Empty();
        }

        [Test]
        public void ShouldSkipDaysWithNoSales()
        {
            var target = new CreateMedianPrices();
            var soldApartments = new List<SoldApartment>
            {
                new SoldApartment(100, DateTime.Today.AddDays(-1), 1)
            };
            var result = target.Execute(DateTime.Today.AddDays(-1), soldApartments);
            
            result.ContainsKey(DateTime.Today)
                .Should().Be.False();
        }
        
        [Test]
        public void ShouldHandleNoDataAtAll()
        {
            var target = new CreateMedianPrices();
            var result = target.Execute(DateTime.Today, Enumerable.Empty<SoldApartment>());

            result.Should().Be.Empty();
        }
    }
}