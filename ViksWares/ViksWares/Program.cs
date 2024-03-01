using System;
using System.Collections.Generic;
using ViksWares;
using ViksWares.Constants;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ItemsConstants.Welcome);

            IList<Item> Items = new List<Item>{
                new RegularItems {Name = ItemsConstants.ShoeLaces, SellBy = 10, Value = 20},
                new SpecialItem {Name = ItemsConstants.Parmigiano, SellBy = 2, Value = 0},
                new RegularItems {Name = ItemsConstants.BookResolutions, SellBy = 5, Value = 7},
                new RegularItems {Name = ItemsConstants.SaffronPowder, SellBy = 0, Value = 80},
                new RegularItems {Name = ItemsConstants.SaffronPowder, SellBy = -1, Value = 80},
                new SpecialItem
                {
                    Name = ItemsConstants.ConcertTickets,
                    SellBy = 15,
                    Value = 20
                },
                new SpecialItem
                {
                    Name = ItemsConstants.ConcertTickets,
                    SellBy = 10,
                    Value = 49
                },
                new SpecialItem
                {
                    Name = ItemsConstants.ConcertTickets,
                    SellBy = 5,
                    Value = 49
                },

                new RefrigiratedItems{ Name = ItemsConstants.Milk, SellBy = 3, Value = 6},
            };

            var app = new ViksWares(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                //app.UpdateValue();
                app.Update();
            }

            Console.ReadKey();
        }
    }
}