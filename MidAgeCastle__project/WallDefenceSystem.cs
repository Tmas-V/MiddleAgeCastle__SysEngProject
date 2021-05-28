using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class WallDefenceSystem
    {
        private Moat moat;
        private int wall_count;
        private Wall[] walls;
        private int tower_count;
        private Tower[] towers;

        public WallDefenceSystem()
        {
            wall_count = 0;
            walls = null;
            tower_count = 0;
            towers = null;
            moat = new Moat();
        }
        public WallDefenceSystem(CastleForm form)
        {
            if (form == CastleForm.rectangle)
            {
                wall_count = 4;
                walls = new Wall[4];
                walls[0] = new Wall(100, WorldDirection.north, BuildMaterial.stone, 30);
                walls[1] = new Wall(100, WorldDirection.east, BuildMaterial.stone, 30);
                walls[2] = new Wall(100, WorldDirection.west, BuildMaterial.stone, 30);
                walls[3] = new Wall(100, WorldDirection.south, BuildMaterial.stone, 30);
                tower_count = 4;
                towers = new Tower[4];
                towers[0] = new Tower(100, WorldDirection.north_east, BuildMaterial.stone, 50);
                towers[1] = new Tower(100, WorldDirection.north_west, BuildMaterial.stone, 50);
                towers[2] = new Tower(100, WorldDirection.south_east, BuildMaterial.stone, 50);
                towers[3] = new Tower(100, WorldDirection.south_west, BuildMaterial.stone, 50);
            }
            else
            {
                wall_count = 0;
                walls = null;
                tower_count = 0;
                towers = null;
            }
            moat = new Moat();
        }
        public bool takeDamage(List<DirectedAttack> attack)
        {
            foreach(DirectedAttack atk in attack)
            {
                atk.decreaseDamage(moat.getDefenseDmg());
                foreach(Tower tower in towers)
                {
                    tower.dealDamage(atk);
                }
                foreach (Wall wall in walls)
                {
                    wall.dealDamage(atk);
                }
            }
            return isDestroyed();
        }
        public Dictionary<WorldDirection,bool> displayFallenDefenses()
        {
            Dictionary<WorldDirection, bool> result = new Dictionary<WorldDirection, bool>();
            foreach(Wall wall in walls)
            {
                if (!wall.isDestroyed())
                {
                    result.Add(wall.getPosition(), true);
                }
            }
            foreach (Tower tower in towers)
            {
                if (!tower.isDestroyed())
                {
                    result.Add(tower.getPosition(), true);
                }
            }
            return result;
        }
        public bool isDestroyed()
        {
            bool result = false;
            foreach(Wall wall in walls)
            {
                result = result || wall.isDestroyed();
            }
            return result;
        }
    }
}
