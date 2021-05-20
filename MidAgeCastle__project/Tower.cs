using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class Tower : DefenceUnit
    {
        private static int default_defense = 150;
        public int attackDmg;
        public Tower() : base()
        {
            attackDmg = 0;
        }
        public Tower(int _MAX_defense, WorldDirection worldDirect, BuildMaterial buildMaterial, int attackdmg) : base(_MAX_defense, worldDirect, buildMaterial)
        {
            attackDmg = attackdmg;
        }
        public Tower(WorldDirection worldDirect, BuildMaterial buildMaterial, int attackdmg) : base(worldDirect, buildMaterial)
        {
            attackDmg = attackdmg;
        }
        public void counterAttack()
        {

        }
    }
}
