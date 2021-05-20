using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class Gate : DefenceUnit
    {
        private static int default_defense = 300;
        private bool isGateOpen;
        public Gate() : base()
        {
            isGateOpen = false;
        }
        public Gate(int _MAX_defense, WorldDirection worldDirect, BuildMaterial buildMaterial, bool isOpen) : base(_MAX_defense, worldDirect, buildMaterial)
        {
            isGateOpen = isOpen;
        }
        public Gate(WorldDirection worldDirect, BuildMaterial buildMaterial, bool isOpen) : base(worldDirect, buildMaterial)
        {
            isGateOpen = isOpen;
        }
        public void openGate()
        {
            isGateOpen = true;
        }
        public void closeGate()
        {
            isGateOpen = false;
        }
    }
}
