using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class Well // MAke semaphore based access to water, in exist it accumulates over time
    {
        public static int default_MAX_water = 500;
        public static int default_water_gain = 50;
        private DepletableObject water;
        private bool isAvailable;

        public void looseWell()
        {
            isAvailable = false;
        }
        public void accumulateWater()
        {
            water.gain();
        }
        public int collectWater(int amount)
        {
            return water.drain(amount);
        }
        public Well()
        {
            water = new DepletableObject(default_MAX_water, default_MAX_water / 2, default_water_gain, 0);
            isAvailable = true;
        }
        public Well(int _water_gain, int _MAX_water)
        {
            water = new DepletableObject(_MAX_water, _MAX_water / 2, _water_gain, 0);
            isAvailable = true;
        }

        public bool isEmpty()
        {
            if (showWaterAmount() > 0) return false;
            return true;
        }
        public bool isFree()
        {
            return isAvailable;
        }
        public int showWaterAmount()
        {
            return water.showValue();
        }

        public void exist()
        {
            while (isAvailable)
            {
                accumulateWater();
                Thread.Sleep(5000);
            }
        }
    }
}
