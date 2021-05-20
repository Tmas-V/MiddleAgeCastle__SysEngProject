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
        
        
        public bool isUnderSiege;
        public DonjonTower()
        {
            food = new DepletableObject(default_food_cap, default_food_cap, food_gain, 0);
            isUnderSiege = false;
        }
        public DonjonTower(int food_cap, int water_cap)
        {
            food = new DepletableObject(default_food_cap, default_food_cap, food_gain, 0);
            isUnderSiege = false;
        }
        public override void dealDamage(int damage)
        {
            if (defense == MAX_defense)
            {
                isUnderSiege = true;
            }
            if (damage < defense)
            {
                defense -= damage;
                return;
            }
            defense = 0;
        }

        public int getFood(int amount)
        {
            return food.drain(amount);
        }
        public int showFoodAmount()
        {
            return food.showValue();
        }

        public void exist()
        {
            while (!isDestroyed())
            {
                food.gain();
                Thread.Sleep(4000);
            }
        }
        public void siege()
        {

        }
    }
}
