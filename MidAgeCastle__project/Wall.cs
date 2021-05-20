using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{

    class Wall : DefenceUnit
    {
        public int attackDmg;
        public Wall() : base()
        {
            attackDmg = 0;
        }
        public Wall(WorldDirection worldDirect, BuildMaterial buildMaterial, int attackdmg) : base(worldDirect, buildMaterial)
        {
            attackDmg = attackdmg;
        }
        public Wall(int _MAX_defense, WorldDirection worldDirect, BuildMaterial buildMaterial, int attackdmg) : base(_MAX_defense, worldDirect, buildMaterial)
        {
            attackDmg = attackdmg;
        }
        public void counterAttack()
        {

        }
    }
}
