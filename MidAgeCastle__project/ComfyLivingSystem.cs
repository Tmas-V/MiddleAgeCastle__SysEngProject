using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class ComfyLivingSystem
    {
        public static int default_fireplace_amount = 1;
        public static int default_bath_amount = 1;
        public int fireplace_amount;
        public int bath_amount;

        private bool needBath;
        private bool needFireplace;
        public object bathSync;
        public object fireplaceSync;

        public ComfyLivingSystem()
        {
            fireplace_amount = default_fireplace_amount;
            bath_amount = default_bath_amount;
            needBath = false;
            needFireplace = false;
            bathSync = new object();
            fireplaceSync = new object();
        }
        public bool isBathNeeded()
        {
            lock (bathSync)
            {
                return needBath;
            }
        }
        public bool isFireplaceNeeded()
        {
            lock (fireplaceSync)
            {
                return needFireplace;
            }
        }
        public void prepareBath()
        {
            lock (bathSync)
            {
                needBath = false;
            }
        }
        public void prepareFireplace()
        {
            lock (fireplaceSync)
            {
                needFireplace = false;
            }
        }
        public bool waitForBath()
        {
            if (Castle.getInstance() == null) return false;
            lock (bathSync)
            {
                needBath = true;
            }
            int timeout = 3;
            while (needBath && (timeout > 0))
            {
                timeout--;
                Thread.Sleep(1000);
            }
            if (timeout == 0) return false;
            else
            {
                return true;
            }
        }
        public bool waitForFireplace()
        {
            if (Castle.getInstance() == null) return false;
            lock (bathSync)
            {
                needFireplace = true;
            }
            int timeout = 3;
            while (needFireplace && (timeout > 0))
            {
                timeout--;
                Thread.Sleep(1000);
            }
            if (timeout == 0) return false;
            else
            {
                return true;
            }
        }
        public void useFireplace()
        {
            Thread.Sleep(500);
        }
        public void useBath()
        {
            Thread.Sleep(500);
        }
    }
}
