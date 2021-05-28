using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class GateDefenceSystem
    {
        private Moat moat;
        private Gate gate;
        private bool isBridgeDown;
        private bool isTarTrapSet;
        private static int tarDamage = 200;
        public GateDefenceSystem()
        {
            moat = new Moat();
            gate = new Gate();
            isBridgeDown = false;
            isTarTrapSet = false;
        }
        public GateDefenceSystem(CastleForm form, WorldDirection direct)
        {
            moat = new Moat(form);
            gate = new Gate(direct, BuildMaterial.wood, false);
            isBridgeDown = false;
            isTarTrapSet = false;
        }
        public bool takeDamage(DirectedAttack attack)
        {
            bool result = false;
            if (isBridgeDown)
            {
                if (isTarTrapSet)
                {
                    attack.decreaseDamage(tarDamage);
                    isTarTrapSet = false;
                }
            }
            attack.decreaseDamage(moat.getDefenseDmg());
            result = result || gate.takeDamage(attack);
            return result;
        }
        public void closeBridge()
        {
            isBridgeDown = false;
        }
        public void openBridge()
        {
            isBridgeDown = true;
        }
        public bool isBridgeDowned()
        {
            return isBridgeDown;
        }
        public bool isGateOpened()
        {
            return gate.isGateOpened();
        }
        public void fillTarTraps()
        {
            isTarTrapSet = true;
        }
        public void useTarTraps()
        {
            isTarTrapSet = false;
        }
        public void openEntrance()
        {
            openBridge();
            gate.openGate();
        }
        public void closeEntrance()
        {
            gate.closeGate();
            closeBridge();
        }
        public WorldDirection getPosition()
        {
            return gate.getPosition();
        }
        public bool isDestroyed()
        {
            return gate.isDestroyed();
        }
    }
}
