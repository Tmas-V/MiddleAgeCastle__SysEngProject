using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class DonjonTower : Tower
    {
        public static int default_defense = 600;
        public static int default_food_cap = 1000;
        private static int food_gain = 100;
        private DepletableObject food;
        
        
        private bool isUnderAttack;
        private object isUnderAttackObject;


        public DonjonTower()
        {
            food = new DepletableObject(default_food_cap, default_food_cap, food_gain, 0);
            isUnderAttack = false;
            isUnderAttackObject = new object();
        }
        public DonjonTower(int food_cap, int water_cap)
        {
            food = new DepletableObject(default_food_cap, default_food_cap, food_gain, 0);
            isUnderAttack = false;
            isUnderAttackObject = new object();
        }

        public int getFood(int amount)
        {
            return food.drain(amount);
        }
        public int showFoodAmount()
        {
            return food.showValue();
        }
        public void setUnderAttack()
        {
            lock (isUnderAttackObject)
            {
                isUnderAttack = true;
            }
        }
        public void setInPeace()
        {
            lock (isUnderAttackObject)
            {
                isUnderAttack = false;
            }
        }

        public void exist()
        {
            while (!isDestroyed())
            {
                lock (isUnderAttackObject)
                {
                    if (!isUnderAttack)
                        food.gain();
                }
                Thread.Sleep(4000);
            }
        }
    }
}
