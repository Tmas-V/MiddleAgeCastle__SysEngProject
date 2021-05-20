using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class GateDefenceSystem
    {
        public Moat moat;
        public Gate gate;
        public bool isBridgeDown;
        public bool isTarTrapSet;
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
        public void dealDamage(DirectedAttack attack)
        {

        }
        public void closeBridge()
        {
            isBridgeDown = false;
        }
        public void openBridge()
        {
            isBridgeDown = true;
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
    }
}
