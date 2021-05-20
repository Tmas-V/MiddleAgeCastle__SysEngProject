using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class Servant : Human
    {
        public Servant() : base()
        {
            role = HumanRole.servant;
        }
        public Servant(string _name) : base(_name)
        {
            role = HumanRole.servant;
        }
        public void serveFireplace()
        {
            if (Castle.getInstance() == null) return;
            if (Castle.getInstance().comfyLivingSys.isFireplaceNeeded())
            {
                Castle.getInstance().comfyLivingSys.prepareFireplace();
            }
        }
        public void serveBath()
        {
            if (Castle.getInstance() == null) return;
            if (Castle.getInstance().comfyLivingSys.isBathNeeded())
            {
                Castle.getInstance().comfyLivingSys.prepareBath();
            }
        }
        public override void live()
        {
            while (isHumanAlive())
            {
                Thread.Sleep(1000);
                starve();
                eat();
                thirsty();
                drink();
                harm();
                if (!isInPrison)
                {
                    sanitate();
                    serveBath();
                    serveFireplace();
                }
            }
        }
    }
}
