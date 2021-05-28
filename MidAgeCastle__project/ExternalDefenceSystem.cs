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
        public bool takeAttack(List<DirectedAttack> attackVectors)
        {
            WorldDirection gatePos = gateDefSys.getPosition();
            List<DirectedAttack> gateDirectedAttacks = new List<DirectedAttack>();
            int i = 0;
            while(i < attackVectors.Count)
            {
                if (attackVectors[i].direction == gatePos)
                {
                    gateDirectedAttacks.Add(attackVectors[i]);
                    attackVectors.RemoveAt(i);
                }
                else i++;
            }
            bool result = false;
            foreach (DirectedAttack gateAttack in gateDirectedAttacks)
            {
                result = result || gateDefSys.takeDamage(gateAttack);
            }
            if (result)
            {
                return true;
            }
            result = result || wallDefSys.takeDamage(attackVectors);
            return result;

        }
        public Dictionary<WorldDirection, bool> displayFallenDefenses()
        {
            Dictionary<WorldDirection, bool> result = wallDefSys.displayFallenDefenses();
            if (gateDefSys.isDestroyed()) result.Add(gateDefSys.getPosition(), true);
            return result;
        }
    }
}
