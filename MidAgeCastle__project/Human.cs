using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class Human
    {
        private string name;
        protected static int MAX_hunger = 100;
        protected static int MAX_thirst = 100;
        protected static int MAX_health = 100;
        protected static int hunger_gain = MAX_hunger / 10;
        protected static int hunger_drain = MAX_hunger / 10;
        protected static int thirst_gain = MAX_thirst / 10;
        protected static int thirst_drain = MAX_thirst / 10;
        protected static int health_gain = MAX_health / 10;
        protected static int health_drain = MAX_health / 10;

        private object isAliveSync;

        private DepletableObject hunger;
        private DepletableObject thirst;
        private DepletableObject health;

        protected HumanRole role;
        protected bool isInPrison;
        protected bool isAlive;

        public Human()
        {
            List<string> rnd_names = new List<string>(new string[] { "John", "Jack", "Emily", "Janet" });
            Random rnd = new Random();
            name = rnd_names[rnd.Next(rnd_names.Count)];
            hunger = new DepletableObject(MAX_hunger, MAX_hunger, hunger_gain, hunger_drain, true);
            thirst = new DepletableObject(MAX_thirst, MAX_thirst, thirst_gain, thirst_drain, true);
            health = new DepletableObject(MAX_health, MAX_health, health_gain, health_drain, true);
            role = HumanRole.resident;
            isInPrison = false;
            isAlive = true;
            isAliveSync = new object();
    }
    public Human(string _name)
        {
            name = _name;
            hunger = new DepletableObject(MAX_hunger, MAX_hunger, hunger_gain, hunger_drain, true);
            thirst = new DepletableObject(MAX_thirst, MAX_thirst, thirst_gain, thirst_drain, true);
            health = new DepletableObject(MAX_health, MAX_health, health_gain, health_drain, true);
            role = HumanRole.resident;
            isInPrison = false;
            isAlive = true;
            isAliveSync = new object();
        }

        public string getName()
        {
            return name;
        }
        public void setName(string _name)
        {
            name = _name;
        }
        public HumanRole getRole()
        {
            return role;
        }
        public void setRole(HumanRole _role)
        {
            role = _role;
        }
        public bool isHumanAlive()
        {
            lock (isAliveSync)
            {
                return isAlive;
            }
        }
        public bool isHumanInPrison()
        {
            return isInPrison;
        }
        public virtual void eat()
        {
            if (Castle.getInstance() == null) return;
            int food = Castle.getInstance().internalDefSys.donjonTower.getFood(hunger_gain);
            hunger.gain(food);
        }
        public void starve()
        {
            hunger.drain();
            if (hunger.showValue() == 0)
            {
                lock (isAliveSync)
                {
                    isAlive = false;
                }
            }
        }
        public virtual void drink()
        {
            if (Castle.getInstance() == null) return;
            int water = Castle.getInstance().waterDistribSys.getWater(thirst_gain);
            thirst.gain(water);
        }
        public void thirsty()
        {
            thirst.drain();
            if (thirst.showValue() == 0)
            {
                lock (isAliveSync)
                {
                    isAlive = false;
                }
            }
        }
        public virtual void sanitate()
        {
            health.gain();
        }
        public void harm()
        {
            health.drain();
            if (health.showValue() == 0)
            {
                lock (isAliveSync)
                {
                    isAlive = false;
                }
            }
        }

        public void goToPrison()
        {
            if (Castle.getInstance() == null) return;
            isInPrison = true;
            Castle.getInstance().prisonSys.addNewPrisoner(this);
        }


        public virtual void live()
        {
            while (isAlive)
            {
                Thread.Sleep(4000);
                starve();
                eat();
                thirsty();
                drink();
                harm();
                if (!isHumanInPrison()) sanitate();
            }
            hunger.anil();
            thirst.anil();
            health.anil();
        }
        
        public string getHumanInfo()
        {
            string result = "";
            result += "----------------------------------\n";
            result += "Human: " + name + "(";
            bool tmp = isHumanAlive();
            if (tmp) result += "alive";
            else result += "dead";
            result += ")\n";
            result += "Role: ";
            switch (role)
            {
                case HumanRole.resident: result += "resident"; break;
                case HumanRole.guardian: result += "guardian"; break;
                case HumanRole.servant: result += "servant"; break;
                case HumanRole.prisoner: result += "prisoner"; break;
                case HumanRole.feudal: result += "feudal"; break;
            }
            if (isHumanInPrison()) result += " (in prison)";
            else result += " (free)";
            result += "\n";
            result += "(0)Hunger: " + hunger.showValue().ToString() + "\n";
            result += "(0)Thirst: " + thirst.showValue().ToString() + "\n";
            result += "(0)Health: " + health.showValue().ToString() + "\n";
            result += "----------------------------------\n";
            return result;
        }

    }
}
