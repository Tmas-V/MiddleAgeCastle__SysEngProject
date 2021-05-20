using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class Guardian : Human
    {
        public Guardian() : base()
        {
            role = HumanRole.guardian;
        }
        public Guardian(string _name) : base(_name)
        {
            role = HumanRole.guardian;
        }
        public void torturePrisoner()
        {
            if (Castle.getInstance() == null) return;
            if (Castle.getInstance().prisonSys.prisoners.Count == 0) return;
            Random rnd = new Random();
            int index = rnd.Next(Castle.getInstance().prisonSys.prisoners.Count);
            Castle.getInstance().prisonSys.torturePrisoner(index);
            //Console.WriteLine("\n\n#### You hear unbearable screams of death from prison tower...\n");
        }
        public override void live()
        {
            int timer = 3;
            while (isAlive)
            {
                Thread.Sleep(2000);
                timer--;
                starve();
                eat();
                thirsty();
                drink();
                harm();
                if (!isInPrison)
                {
                    sanitate();
                    if (timer == 0)
                    {
                        torturePrisoner();
                        timer = 3;
                    }
                }
            }
        }
    }
}
