using System;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTestingWorkshopTwo.Tests
{
    public class OrderBuilderTests
    {
        private OrderBuilder _sut;
        private IOrderItemRepo _fakeOrderItemRepo;

        [SetUp]
        public void Setup()
        {
            _fakeOrderItemRepo = A.Fake<IOrderItemRepo>();
            _sut = new OrderBuilder(_fakeOrderItemRepo);
        }

        [Test]
        public void Init_should_return_OrderBuilder()
        {
            var returnedOrderBuilder = _sut.Init();
            returnedOrderBuilder.Should().Be(_sut);
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
            var result = _sut.Init().Build();

            result.Should().NotBeNull();
        }

        [Test]
        public void ShipTo_should_set_order_contact_name()
        {
            var result = _sut
                .Init()
                .ShipTo("Sara", "123 Awesome Way, Saraville")
                .Build();

            result.ContactName.Should().Be("Sara");
        }

        [Test]
        public void ShipTo_should_set_order_delivery_address()
        {
            var result = _sut
                .Init()
                .ShipTo("Sara", "123 Awesome Way, Saraville")
                .Build();

            result.ShippingAddress.Should().Be("123 Awesome Way, Saraville");
        }

        [Test]
        public void ShipTo_should_return_OrderBuilder()
        {
            var returnedOrderBuilder = _sut.Init().ShipTo("", "");
            returnedOrderBuilder.Should().Be(_sut);
        }
    }
}