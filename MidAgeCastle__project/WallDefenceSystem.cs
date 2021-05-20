using System;
using System.Collections.Generic;
using System.Text;

namespace MidAgeCastle__project
{
    class WallDefenceSystem
    {
        public int wall_count;
        public Wall[] walls;
        public int tower_count;
        public Tower[] towers;
        public bool isDefenceDown;

        public WallDefenceSystem()
        {
            wall_count = 0;
            walls = null;
            tower_count = 0;
            towers = null;
            isDefenceDown = false;
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
            isDefenceDown = false;
        }
        public void dealDamage(DirectedAttack attack)
        {

        }
        public void counterAttack(WorldDirection direction)
        {

        }
    }
}
