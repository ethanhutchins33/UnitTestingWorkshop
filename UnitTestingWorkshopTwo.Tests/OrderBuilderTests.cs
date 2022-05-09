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
        private IDateTimeFacade _fakeDateTimeFacade;

        [SetUp]
        public void Setup()
        {
            _fakeOrderItemRepo = A.Fake<IOrderItemRepo>();
            _fakeDateTimeFacade = A.Fake<IDateTimeFacade>();
            _sut = new OrderBuilder(_fakeOrderItemRepo, _fakeDateTimeFacade);
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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void AddItems_should_call_orderItemsRepo_numItems_number_of_times(int numItems)
        {
            //Act
            _sut.Init()
                .AddItems(numItems);

            //Assert
            A.CallTo(() => _fakeOrderItemRepo.GetRandomItem())
                .MustHaveHappened(numItems, Times.Exactly);
        }

        [Test]
        public void AddItem_should_add_correct_item_from_orderitemsrepo_to_order()
        {
            A.CallTo(() => _fakeOrderItemRepo.GetRandomItem()).Returns("Apple");

            var order = _sut
                .Init()
                .AddItems(1)
                .Build();

            order.ItemLines[0].Item.Should().Be("Apple");
        }

        [Test]
        public void AddItems_should_put_multiple_items_from_orderitemsrepo_into_order()
        {

        }


        [TestCase("2022-5-9", "2022-5-12")]
        [TestCase("2021-5-12", "2021-5-15")]
        [TestCase("2022-6-9", "2022-6-12")]

        public void ShipTo_should_set_estimated_shipping_date_to_three_working_days_from_now(DateTime now, DateTime expected)
        {
            A.CallTo(() => _fakeDateTimeFacade.UtcNow()).Returns(now);

            var order = _sut
                .Init()
                .ShipTo("", "")
                .Build();

            order.EstimatedShippingDate.Should().Be(expected);
        }
    }
}