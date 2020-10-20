using System;
using System.Collections.Generic;

namespace GearBox
{
    public class GearBox
    {
        private const int UpperRPM = 2000;
        private const int LowerRPM = 500;
        private const int BaseGear = 1;
        private const int MaxGears = 6;
        private int _gear = 0;
        public Dictionary<int, Gear> Gears;

        public GearBox(int gear)
        {
            _gear = gear;
        }


        public GearBox(int gear, Dictionary<int, Gear> gears)
        {
            _gear = gear;
            Gears = gears;
        }




        public void ShiftGear(int rpm)
        {
            if (Gears == null)
            {
                ShiftBasedOnUppderAndLowerRPM(rpm);
                return;
            }
            ShiftGearBasedOnRPMRangeOnEachGear(rpm);

        }

        private void ShiftGearBasedOnRPMRangeOnEachGear(int rpm)
        {
            foreach (var gear in Gears)
            {
                var gearLevel = gear.Value;
                if (rpm < gearLevel.UpperRPM && rpm > gearLevel.LowerRPM)
                {
                    _gear = gear.Key;
                    return;
                }

                _gear = 0;
            }
        }

        private void ShiftBasedOnUppderAndLowerRPM(int rpm)
        {
            if (rpm > UpperRPM && _gear < MaxGears)
            {
                _gear++;
            }
            if (rpm < LowerRPM && _gear > BaseGear)
            {
                _gear--;
            }
        }

        public int GetCurrentGear()
        {
            return _gear;
        }
    }

}
