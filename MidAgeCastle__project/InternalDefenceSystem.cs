using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class InternalDefenceSystem
    {
        public DonjonTower donjonTower;
        public WallDefenceSystem wallDefSys;
        public GateDefenceSystem gateDefSys;

        public InternalDefenceSystem()
        {
            donjonTower = new DonjonTower();
            wallDefSys = new WallDefenceSystem();
            gateDefSys = new GateDefenceSystem();
        }
        public InternalDefenceSystem(CastleForm form, WorldDirection direct)
        {
            wallDefSys = new WallDefenceSystem(form);
            gateDefSys = new GateDefenceSystem(form, direct);
            donjonTower = new DonjonTower();
        }
        public void dealDamage(DirectedAttack attack)
        {

        }
        public void exist()
        {
            Thread newThread = new Thread(new ThreadStart(donjonTower.exist));
            newThread.IsBackground = true;
            newThread.Start();
        }
        public void siege()
        {

        }
    }
}
