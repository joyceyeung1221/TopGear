using System;

namespace GearBox
{
    public class GearBox
    {
        private int gear = 0;
        private int e = 0;

        public void doit(int rpm)
        {
            if (gear < 0)
            {
                // do nothing!
                e = rpm;
            }
            else
            {
                if (gear > 0)
                {
                    if (rpm > 2000)
                    {
                        gear++;
                    }
                    else if (rpm < 500)
                    {
                        gear--;
                    }
                }
            }

            if (gear > 6)
            {
                gear--;
            }
            else if (gear < 1)
            {
                gear++;
            }

            e = rpm;
        }
    }
}
