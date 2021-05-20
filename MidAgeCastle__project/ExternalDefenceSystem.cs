using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class ExternalDefenceSystem
    {
        public WallDefenceSystem wallDefSys;
        public GateDefenceSystem gateDefSys;
        public bool isDefenceDown;

        public ExternalDefenceSystem()
        {
            wallDefSys = new WallDefenceSystem();
            gateDefSys = new GateDefenceSystem();
            isDefenceDown = false;
        }
        public ExternalDefenceSystem(CastleForm form, WorldDirection direct)
        {
            wallDefSys = new WallDefenceSystem(form);
            gateDefSys = new GateDefenceSystem(form, direct);
            isDefenceDown = false;
        }
        public void dealDamage(DirectedAttack attack)
        {

        }
        public void counterAttack()
        {

        }
    }
}
