using System;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTestingWorkshopTwo.Tests
{
    public class OrderBuilderTests
    {
        private OrderBuilder _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new OrderBuilder();
        }

        [Test]
        public void Build_should_throw_when_not_initialised()
        {
            Action act = () => _sut.Build();
            
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Must initialise before building");
        }
        
        [Test]
        public void Build_should_return_order_when_initialised()
        {
            var result =  _sut.Init().Build();

            result.Should().NotBeNull();
        }

        [Test]
        public void ShipTo_should_set_order_details()
        {
            var result =  _sut
                .Init()
                .ShipTo("Sara", "123 Awesome Way, Saraville")
                .Build();

            result.ContactName.Should().Be("Sara");
            result.ShippingAddress.Should().Be("123 Awesome Way, Saraville");
        }


    }
}