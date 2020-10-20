using System;
namespace GearBox
{
    public class Gear
    {
        public int UpperRPM { get; private set; }
        public int LowerRPM { get; private set; }

        public Gear(int lowerLimit, int upperLimit)
        {
            LowerRPM = lowerLimit;
            UpperRPM = upperLimit;
        }
    }
}
