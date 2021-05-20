using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class DefenceUnit
    {
        protected static int default_defense = 100;
        protected int MAX_defense;
        protected int defense;
        protected WorldDirection position;
        protected BuildMaterial material;
        protected int guard_count;
        protected Guardian[] warriors;
        public DefenceUnit()
        {
            MAX_defense = default_defense;
            defense = default_defense;
            guard_count = 0;
            warriors = null;
        }
        public DefenceUnit( WorldDirection worldDirect, BuildMaterial buildMaterial)
        {
            MAX_defense = default_defense;
            defense = default_defense;
            position = worldDirect;
            material = buildMaterial;
            guard_count = 0;
            warriors = null;
        }
        public DefenceUnit(int _MAX_defense, WorldDirection worldDirect, BuildMaterial buildMaterial)
        {
            MAX_defense = _MAX_defense;
            defense = _MAX_defense;
            position = worldDirect;
            material = buildMaterial;
            guard_count = 0;
            warriors = null;
        }
        public virtual void dealDamage(int damage)
        {
            if (damage <= 0) return;
            if (damage < defense) defense -= damage;
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
    }
}
