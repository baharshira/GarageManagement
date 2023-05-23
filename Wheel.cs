using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressue { get;  set; }
        public void FillAirInWheels(Wheel i_wheel, float i_AmountToFill)
        {
            if (i_wheel.CurrentAirPressure + i_AmountToFill > i_wheel.MaxAirPressue)
            {
                throw new ValueOutOfRangeException("Amount of air to fill is bigger than possible.", 0, MaxAirPressue);
            }

            i_wheel.CurrentAirPressure = i_wheel.CurrentAirPressure + i_AmountToFill;
        }
    }
}