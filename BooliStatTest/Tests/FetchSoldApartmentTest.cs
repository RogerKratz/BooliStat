using System;
using System.Linq;
using BooliStat.Code;
using BooliStatTest.FakeAndHelpers;
using NUnit.Framework;
using SharpTestsEx;

namespace BooliStatTest.Tests
{
    public class FetchSoldApartmentTest
    {
        [Test]
        public void ShouldReturn()
        {
            var sold = SoldFactory.Create(1);
            var resultFetcher = new FakeResultFetcher(1, sold);
            var target = new FetchSoldApartments(resultFetcher);

            var result = target.Execute().Single();

            result.Date.Should().Be.EqualTo(DateTime.Parse(sold.soldDate));
            result.Price.Should().Be.EqualTo(sold.soldPrice);
            result.Area.Should().Be.EqualTo(sold.livingArea);
        }

        [Test]
        public void ShouldAddNewLinesWhenMoreItemsThanLimit()
        {
            var sold1 = SoldFactory.Create(1);
            var sold2 = SoldFactory.Create(2);
            var resultFetcher = new FakeResultFetcher(1, sold1, sold2);
            var target = new FetchSoldApartments(resultFetcher);

            var result = target.Execute();

            result.First().Date.Should().Be.EqualTo(DateTime.Parse(sold1.soldDate));
            result.Last().Price.Should().Be.EqualTo(sold2.soldPrice);
        }
        
        [Test]
        public void ShouldAddNewLinesWhenMoreThanTwoRequests()
        {
            var sold1 = SoldFactory.Create(1);
            var sold2 = SoldFactory.Create(2);
            var sold3 = SoldFactory.Create(3);
            var sold4 = SoldFactory.Create(4);
            var sold5 = SoldFactory.Create(5);
            var sold6 = SoldFactory.Create(6);
            var resultFetcher = new FakeResultFetcher(2, sold1, sold2, sold3, sold4, sold5, sold6);
            var target = new FetchSoldApartments(resultFetcher);

            var result = target.Execute();
            result.Count().Should().Be.EqualTo(6);
            result.First().Date.Should().Be.EqualTo(DateTime.Parse(sold1.soldDate));
            result.Last().Price.Should().Be.EqualTo(sold6.soldPrice);
        }
    }
}