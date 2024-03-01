using csharp;
using System;
using System.Collections.Generic;
using System.Text;
using ViksWares.Constants;

namespace ViksWares
{
    public class RegularItems : Item
    {
        public override void UpdateValue()
        {
            if (Value > 0 && Name != ItemsConstants.SaffronPowder) // "Saffron Powder" has a Value of 80 and is never altered.
            {
                Value = SellBy >= 0 ? Math.Max(0, Value - 1) : Math.Max(0, Value - 2);
            }
        }
    }
}
