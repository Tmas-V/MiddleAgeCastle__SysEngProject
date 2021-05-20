using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class WaterDistributionSystem
    {
        public int default_well_count = 1;
        public int well_count;
        public Well[] wells;
        public int total_water;
        public Well donjonWell;

        public WaterDistributionSystem()
        {
            well_count = default_well_count;
            wells = new Well[default_well_count];
            wells[0] = new Well();
            total_water = 0;
            donjonWell = new Well(Well.default_water_gain * 2, Well.default_MAX_water * 2);
        }
        public WaterDistributionSystem(int _well_count, int _water_gain, int _MAX_water)
        {
            well_count = _well_count;
            wells = new Well[well_count];
            for (int i = 0; i<well_count; i++)
            {
                wells[i] = new Well(_water_gain, _MAX_water);
            }
            donjonWell = new Well(_water_gain * 2, _MAX_water * 2);
        }
        public int getWater(int amount)
        {
            int i = 0;
            while((i < well_count) && wells[i].isEmpty() && !wells[i].isFree())
            {
                i++;
            }
            if (i < well_count)
            {
                return wells[i].collectWater(amount);
            }
            if (!donjonWell.isEmpty() && donjonWell.isFree())
            {
                return donjonWell.collectWater(amount);
            }
            return 0;
        }
        public void existInCastle()
        {
            for (int i = 0; i < well_count; i++)
            {
                Thread newThread = new Thread(new ThreadStart(wells[i].exist));
                newThread.IsBackground = true;
                newThread.Start();
                
            }
            Thread _newThread = new Thread(new ThreadStart(donjonWell.exist));
            _newThread.IsBackground = true;
            _newThread.Start();
        }
    }
}
