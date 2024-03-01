using csharp;
using System;
using System.Collections.Generic;
using System.Text;
using ViksWares.Constants;

namespace ViksWares
{
    public class SpecialItem : Item
    {
        public override void UpdateValue()
        {         
            switch (Name)
            {
                case ItemsConstants.Parmigiano:
                    UpdateParmigianoValue();
                    break;
                case ItemsConstants.ConcertTickets:
                    UpdateConcertTicketsValue();
                    break;
            }          
        }

        private void UpdateParmigianoValue()
        {
            if (Value <= LimitsConstants.MaxItemValue)
            {
                Value = SellBy >= 0 ? Math.Min(LimitsConstants.MaxItemValue, Value + 1) : Math.Min(LimitsConstants.MaxItemValue, Value + 2);
            }
        }

        private void UpdateConcertTicketsValue()
        {
            if (Value <= LimitsConstants.MaxItemValue)
            {
                if (SellBy >= LimitsConstants.TicketsValueIncreaseThreshold)
                {
                    Value = Math.Min(LimitsConstants.MaxItemValue, Value + 1);
                }
                else if (SellBy >= LimitsConstants.TicketsValueIncreaseThreshold2 && SellBy <= LimitsConstants.TicketsValueIncreaseThreshold)
                {
                    Value = Math.Min(LimitsConstants.MaxItemValue, Value + 2);
                }
                else if (SellBy >= 0 && SellBy < LimitsConstants.TicketsValueIncreaseThreshold2)
                {
                    Value = Math.Min(LimitsConstants.MaxItemValue, Value + 3);
                }
                else
                {
                    Value = 0;
                }
            }
        }
    }
}
