using System;
using System.Collections.Generic;
using ViksWares;
using ViksWares.Constants;

namespace csharp
{
    public class ViksWares
    {
        IList<Item> Items;
        public ViksWares(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void Update()
        {
            foreach (Item item in Items)
            {
                UpdateSellBy(item);
                item.UpdateValue();
            }
        }

        private void UpdateSellBy(Item item)
        {
            if (item.Name != ItemsConstants.SaffronPowder)
            {
                item.SellBy--;
            }
        }
    }
}
