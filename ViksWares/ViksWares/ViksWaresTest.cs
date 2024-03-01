using NUnit.Framework;
using System;
using System.Collections.Generic;
using ViksWares;
using ViksWares.Constants;

namespace csharp
{
    [TestFixture]
    public class ViksWaresTest
    {
        private ViksWares app;
        private IList<Item> Items;

        [SetUp]
        // Setup is run before each test
        // To initialise any necessary variables
        public void Setup()
        {
            // Initialize common objects or setup common test environment
            Items = new List<Item>(); 
        }

        [Test]
        public void AddItem()
        {
            Items.Add(new RegularItems{Name= ItemsConstants.BookResolutions, SellBy = 5, Value = 10});
            app = new ViksWares(Items);
            app.Update();
            Assert.AreEqual(ItemsConstants.BookResolutions, Items[0].Name);
        }

        [Test]
        public void Parmigiano_Update()
        {
            Items.Add(new SpecialItem { Name = ItemsConstants.Parmigiano, SellBy = 10, Value = 20 });
            app = new ViksWares(Items);

            // Act
            app.Update();

            // Assert
            Assert.AreEqual(9, Items[0].SellBy);
            Assert.AreEqual(21, Items[0].Value);
        }

        [Test]
        public void ConcertTickets_Update()
        {
            // Arrange
            Items.Add(new SpecialItem { Name = ItemsConstants.ConcertTickets, SellBy = 15, Value = 30 });
            app = new ViksWares(Items);

            // Act
            app.Update();

            // Assert
            Assert.AreEqual(14, Items[0].SellBy);
            Assert.AreEqual(31, Items[0].Value);
        }

        [Test]
        public void Milk_Update()
        {
            Items.Add(new RefrigiratedItems { Name = ItemsConstants.Milk, SellBy = 3, Value = 10 });
            app = new ViksWares(Items);

            // Act
            app.Update();

            // Assert
            Assert.AreEqual(2, Items[0].SellBy);
            Assert.AreEqual(8, Items[0].Value);
        }

        [Test]
        public void Regular_Item_Price_Degredation()
        {
            Items.Add(new RegularItems { Name = ItemsConstants.ShoeLaces, SellBy = 5, Value = 20 });
            app = new ViksWares(Items);

            int LastValue;
            int Difference;

            for (int i = 0; i < 10; i++)
            {
                LastValue = Items[0].Value;

                app.Update();

                Difference = Math.Abs(LastValue - Items[0].Value); // to keep a positive value for the difference

                if (Items[0].SellBy >= 0) {
                    Assert.AreEqual(1, Difference);
                    Assert.GreaterOrEqual(Items[0].Value, 0);
                }  
                else
                {
                    Assert.AreEqual(2, Difference);
                    Assert.GreaterOrEqual(Items[0].Value, 0);
                }
            }
        }

        [Test]
        public void Refrigirated_Items_ValueNeverBelowZero()
        {
            // Arrange
            Items.Add(new RefrigiratedItems { Name = ItemsConstants.Milk, SellBy = 5, Value = 10 });
            app = new ViksWares(Items);

            // Act
            for (int i = 0; i < 5; i++)
            {
                app.Update();

                Assert.GreaterOrEqual(Items[0].Value, 0, $"Value of {ItemsConstants.Milk} should never be below 0.");
            }
        }

        [Test]
        public void Refrigirated_Items_DegradeTwiceAsMuch_Value()
        {
            // Arrange
            Items.Add(new RefrigiratedItems { Name = ItemsConstants.Milk, SellBy = 5, Value = 10 });
            app = new ViksWares(Items);

            int LastValue;
            int Difference;
            // Act
            for (int i = 0; i < 5; i++)
            {
                LastValue = Items[0].Value;
                app.Update();

                Difference = LastValue - Items[0].Value;
                Assert.IsTrue(Difference == 2 || Difference == 0);
                Assert.IsFalse(Difference > 2);
            }
        }

        [Test]
        public void PriceDifference_ConcertTickets_ValueThresholdOne()
        {
            Items.Add(new SpecialItem { Name = ItemsConstants.ConcertTickets, SellBy = 11, Value = 40 });
            app = new ViksWares(Items);

            int LastValue = Items[0].Value;

            app.Update();

            int Difference = Items[0].Value - LastValue;
            Assert.IsTrue(Difference == 1);
            Assert.IsFalse(Difference > 1);
        }

        [Test]
        public void PriceDifference_ConcertTickets_ValueThresholdTwo()
        {
            Items.Add(new SpecialItem { Name = ItemsConstants.ConcertTickets, SellBy = 6, Value = 40 });
            app = new ViksWares(Items);

            int LastValue = Items[0].Value;

            app.Update();

            int Difference = Items[0].Value - LastValue;
            Assert.IsTrue(Difference == 2);
            Assert.IsFalse(Difference > 2);
        }

        [Test]
        public void PriceDifference_ConcertTickets_ValueThresholdThree()
        {
            Items.Add(new SpecialItem { Name = ItemsConstants.ConcertTickets, SellBy = 3, Value = 40 });
            app = new ViksWares(Items);

            int LastValue = Items[0].Value;

            app.Update();

            int Difference = Items[0].Value - LastValue;
            Assert.IsTrue(Difference == 3);
            Assert.IsFalse(Difference > 3);
        }

        [Test]
        public void ConcertTickets_Value_Negative_Sellby()
        {
            Items.Add(new SpecialItem { Name = ItemsConstants.ConcertTickets, SellBy = 3, Value = 40 });
            app = new ViksWares(Items);

            for (int i = 0; i < 5; i++)
            {
                app.Update();
                Assert.GreaterOrEqual(Items[0].Value, 0, $"Value of {ItemsConstants.ConcertTickets} should never be below 0.");
            }
        }

        [TearDown]
        // Tear Down is run after each 
        // Test is run to clean the memory
        public void TearDown()
        {
            Items = null;
        }
    }
}