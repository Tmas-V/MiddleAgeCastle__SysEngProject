using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class DefenceUnit
    {
        protected static int default_defense = 100;
        protected static int default_dmg_per_guardian = 50;
        protected int MAX_defense;
        protected int defense;
        protected WorldDirection position;
        protected BuildMaterial material;
        protected int guard_count;
        protected Guardian[] warriors;
        protected int dmgPerGuardian;
        public DefenceUnit()
        {
            MAX_defense = default_defense;
            defense = default_defense;
            guard_count = 0;
            warriors = null;
            dmgPerGuardian = default_dmg_per_guardian;
        }
        public DefenceUnit( WorldDirection worldDirect, BuildMaterial buildMaterial)
        {
            MAX_defense = default_defense;
            defense = default_defense;
            position = worldDirect;
            material = buildMaterial;
            guard_count = 0;
            warriors = null;
            dmgPerGuardian = default_dmg_per_guardian;
        }
        public DefenceUnit(int _MAX_defense, WorldDirection worldDirect, BuildMaterial buildMaterial)
        {
            MAX_defense = _MAX_defense;
            defense = _MAX_defense;
            position = worldDirect;
            material = buildMaterial;
            guard_count = 0;
            warriors = null;
            dmgPerGuardian = default_dmg_per_guardian;
        }
        public virtual void dealDamage(DirectedAttack atk)
        {
            if (atk.direction != position) return;
            atk.decreaseDamage(dmgPerGuardian*guard_count);
            if (atk.damage <= 0) return;
            if (atk.damage < defense) defense -= atk.damage;
            else
            {
                defense = 0;
            }
        }
        public virtual bool isDestroyed()
        {
            if (defense > 0) return false;
            return true;
        }
        public WorldDirection getPosition()
        {
            return position;
        }
    }
}
