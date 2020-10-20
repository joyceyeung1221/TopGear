using System;
using System.Collections.Generic;
using Xunit;

namespace GearBox.Tests
{
    public class GearBoxTest
    {

        [Fact]
        public void ShouldGearShiftedUp_WhenRPMisHigherThan2000()
        {
            var gearBox = new GearBox(0);
            gearBox.ShiftGear(2001);
            var result = gearBox.GetCurrentGear();
            Assert.Equal(1,result);
        }

        [Fact]
        public void ShouldGearShiftedDown_WhenRPMistLowerThan500()
        {
            var gearBox = new GearBox(2);
            gearBox.ShiftGear(499);
            var result = gearBox.GetCurrentGear();
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(1450, 4)]
        [InlineData(1000, 2)]
        [InlineData(0, 0)]
        public void ShouldShiftGearsAccodingToGearRPM_WhenListsOfGearsArePresented(int rpm, int expected)
        {
            var gear1 = new Gear(500, 800); 
            var gear2 = new Gear(801, 1100); 
            var gear3 = new Gear(1101, 1400); 
            var gear4 = new Gear(1401, 1700); 
            var gear5 = new Gear(1701, 2000); 
            var gear6 = new Gear(2001, 8000);

            var gears = new Dictionary<int, Gear>()
            {
                {1,gear1 },
                {2,gear2 },
                {3,gear3 },
                {4,gear4 },
                {5,gear5 },
                {6,gear6 }
            };

            var gearBox = new GearBox(0, gears);
            gearBox.ShiftGear(rpm);
            var result = gearBox.GetCurrentGear();

            Assert.Equal(expected, result);
        }

    }
}
