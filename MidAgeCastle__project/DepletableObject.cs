using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class DepletableObject
    {
        private int value;
        private int MAX_value;
        private int value_gain;
        private int value_drain;
        private object sync;
        private bool isOneTimed;

        public DepletableObject()
        {
            value = 0;
            MAX_value = -1;
            value_gain = 0;
            value_drain = 0;
            sync = new object();
            isOneTimed = false;
        }
        public DepletableObject(int MAX, int start_value, int gain, int drain, bool type = false)
        {
            MAX_value = MAX;
            if (start_value > MAX) value = MAX;
            else value = start_value;
            value_gain = gain;
            value_drain = drain;
            sync = new object();
            isOneTimed = type;
        }
        public int showValue()
        {
            lock (sync)
            {
                return value;
            }
        }
        public void gain()
        {
            lock (sync)
            {
                if (MAX_value > 0)
                {
                    if (value + value_gain > MAX_value)
                    {
                        value = MAX_value;
                    }
                    else value += value_gain;
                }
                else value += value_gain;
            }
        }
        public void gain(int amount)
        {
            lock (sync)
            {
                if (MAX_value > 0)
                {
                    if (value + amount > MAX_value)
                    {
                        value = MAX_value;
                    }
                    else value += amount;
                }
                else value += amount;
            }
        }
        public int drain()
        {
            if (isOneTimed && (value == 0)) return 0;
            int result = 0;
            lock (sync)
            {
                if (value > value_drain)
                {
                    value -= value_drain;
                    result = value_drain;
                }
                else
                {
                    result = value;
                    value = 0;
                }
                return value;
            }
        }
        public int drain(int amount)
        {
            if (isOneTimed && (value == 0)) return 0;
            int result = 0;
            lock (sync)
            {
                if (value > amount)
                {
                    value -= amount;
                    result = amount;
                }
                else
                {
                    result = value;
                    value = 0;
                }
                return value;
            }
        }
        public void anil()
        {
            value = 0;
            MAX_value = 0;
            value_gain = 0;
            value_drain = 0;
            isOneTimed = true;
        }

    }
}
