using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class Feudal : Human
    {

        public Feudal() : base()
        {
            role = HumanRole.feudal;
        }
        public Feudal(string _name) : base(_name)
        {
            role = HumanRole.feudal;
        }

        public bool takeBath()
        {
            if (Castle.getInstance() == null) return false;
            bool result = false;
            if (Castle.getInstance().comfyLivingSys.waitForBath())
            {
                result = true;
                Castle.getInstance().comfyLivingSys.useBath();
                sanitate();
            }
            else result = false;
            return result;
        }
        public bool useFireplace()
        {
            if (Castle.getInstance() == null) return false;
            bool result = false;
            if (Castle.getInstance().comfyLivingSys.waitForFireplace())
            {
                result = true;
                Castle.getInstance().comfyLivingSys.useFireplace();
                sanitate();
            }
            else result = false;
            return result;
        }
        public void sleep()
        {
            if (Castle.getInstance() == null) return;
            Castle.getInstance().livingSys.sleep();
            sanitate();
        }
        public bool throwRandomToPrison()
        {
            if (Castle.getInstance() == null) return false;
            if (Castle.getInstance().livingSys.people.Count == 0) return false;
            Random rnd = new Random();
            int index = rnd.Next(Castle.getInstance().livingSys.people.Count);
            Castle.getInstance().livingSys.people[index].goToPrison();
            Castle.getInstance().livingSys.deleteHuman(index);
            return true;
        }
        public override void live()
        {
            while (isAlive)
            {
                Thread.Sleep(20000);
                starve();
                thirsty();
                harm();
            }
        }
    }
}
