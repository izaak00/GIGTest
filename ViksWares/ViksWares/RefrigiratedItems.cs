using csharp;
using System;
using System.Collections.Generic;
using System.Text;
using ViksWares.Constants;

namespace ViksWares
{
    public class RefrigiratedItems : Item
    {
        public override void UpdateValue()
        {
            if (Value > LimitsConstants.MinItemValue)
            {
                if (SellBy >= 0)
                {
                    Value = Math.Max(LimitsConstants.MinItemValue, Value - 2);
                }
                else
                {
                    Value = Math.Max(LimitsConstants.MinItemValue, Value - 4);
                }
            }
        }
    }
}
