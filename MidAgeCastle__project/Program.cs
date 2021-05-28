using System;
using System.Threading;

namespace MidAgeCastle__project
{
    public enum HumanRole
    {
        feudal,
        servant,
        guardian,
        prisoner,
        resident
    }
    public enum WorldDirection
    {
        north,
        north_east,
        east,
        south_east,
        south,
        south_west,
        west,
        north_west,
        central
    }
    public struct DirectedAttack
    {
        public int damage;
        public WorldDirection direction;

        public void decreaseDamage(int dmg)
        {
            if (dmg > damage) damage = 0;
            else damage -= dmg;
        }
    }
    public enum BuildMaterial
    {
        wood,
        stone,
        brick
    }
    public enum CastleForm
    {
        rectangle,
        pentagon,
        hexagon,
        heptagon,
        octagon
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.Write("Choose name for your castle: ");
            name = Console.ReadLine();
            CastleForm extForm, intForm;
            WorldDirection extDir, intDir;
            int form = 0, dir = 0, res_count = -1, serv_count = -1, war_count = -1;
            while ((form < 1) || (form > 1))
            {
                Console.WriteLine("Choose form of external defense system: ");
                Console.WriteLine("(1) Rectangle ");
                Console.WriteLine("(2) Pentagon ");
                Console.WriteLine("(3) Hexagon ");
                Console.WriteLine("(4) Heptagon ");
                Console.WriteLine("(5) Octagon ");
                Console.WriteLine("(1 - 1): ");
                string tmp = Console.ReadLine();
                if (int.TryParse(tmp, out _)) form = Convert.ToInt32(tmp);
                Console.WriteLine();
                if ((form <= 1) && (form >= 1))
                {
                    break;
                }
                else Console.WriteLine("Invalid input. Try again...");
            }
            extForm = (CastleForm)(form - 1);
            form = 0;
            while ((dir < 1) || (dir > 8))
            {
                Console.WriteLine("Choose relative to donjon tower position of external gate entrance: ");
                Console.WriteLine("(1) North ");
                Console.WriteLine("(2) North east ");
                Console.WriteLine("(3) East ");
                Console.WriteLine("(4) South east ");
                Console.WriteLine("(5) South ");
                Console.WriteLine("(6) South west ");
                Console.WriteLine("(7) West ");
                Console.WriteLine("(8) North west ");
                Console.WriteLine("(1 - 8): ");
                string tmp = Console.ReadLine();
                if (int.TryParse(tmp, out _)) dir = Convert.ToInt32(tmp);
                Console.WriteLine();
                if ((dir <= 8) && (dir >= 1))
                {
                    break;
                }
                else Console.WriteLine("Invalid input. Try again...");
            }
            extDir = (WorldDirection)(dir - 1);
            dir = 0;
            while ((form < 1) || (form > 1))
            {
                Console.WriteLine("Choose form of internal defense system: ");
                Console.WriteLine("(1) Rectangle ");
                Console.WriteLine("(2) Pentagon ");
                Console.WriteLine("(3) Hexagon ");
                Console.WriteLine("(4) Heptagon ");
                Console.WriteLine("(5) Octagon ");
                Console.WriteLine("(1 - 1): ");
                string tmp = Console.ReadLine();
                if (int.TryParse(tmp, out _)) form = Convert.ToInt32(tmp);
                Console.WriteLine();
                if ((form <= 1) && (form >= 1))
                {
                    break;
                }
                else Console.WriteLine("Invalid input. Try again...");
            }
            intForm = (CastleForm)(form - 1);
            form = 0;
            while ((dir < 1) || (dir > 8))
            {
                Console.WriteLine("Choose relative to donjon tower position of internal gate entrance: ");
                Console.WriteLine("(1) North ");
                Console.WriteLine("(2) North east ");
                Console.WriteLine("(3) East ");
                Console.WriteLine("(4) South east ");
                Console.WriteLine("(5) South ");
                Console.WriteLine("(6) South west ");
                Console.WriteLine("(7) West ");
                Console.WriteLine("(8) North west ");
                Console.WriteLine("(1 - 8): ");
                string tmp = Console.ReadLine();
                if (int.TryParse(tmp, out _)) dir = Convert.ToInt32(tmp);
                Console.WriteLine();
                if ((dir <= 8) && (dir >= 1))
                {
                    break;
                }
                else Console.WriteLine("Invalid input. Try again...");
            }
            intDir = (WorldDirection)(dir - 1);
            dir = 0;
            while ((res_count < 0) || (res_count > 8))
            {
                Console.WriteLine("Choose count of residents in the castle: ");
                Console.WriteLine("(0 - 8): ");
                string tmp = Console.ReadLine();
                if (int.TryParse(tmp, out _)) res_count = Convert.ToInt32(tmp);
                Console.WriteLine();
                if ((res_count <= 8) && (res_count >= 0))
                {
                    break;
                }
                else Console.WriteLine("Invalid input. Try again...");
            }
            while ((serv_count < 0) || (serv_count > 8))
            {
                Console.WriteLine("Choose count of servants in the castle: ");
                Console.WriteLine("(0 - 8): ");
                string tmp = Console.ReadLine();
                if (int.TryParse(tmp, out _)) serv_count = Convert.ToInt32(tmp);
                Console.WriteLine();
                if ((serv_count <= 8) && (serv_count >= 0))
                {
                    break;
                }
                else Console.WriteLine("Invalid input. Try again...");
            }
            while ((war_count < 0) || (war_count > 8))
            {
                Console.WriteLine("Choose count of guardians in the castle: ");
                Console.WriteLine("(0 - 8): ");
                string tmp = Console.ReadLine();
                if (int.TryParse(tmp, out _)) war_count = Convert.ToInt32(tmp);
                Console.WriteLine();
                if ((war_count <= 8) && (war_count >= 0))
                {
                    break;
                }
                else Console.WriteLine("Invalid input. Try again...");
            }

            Castle thisCastle = Castle.getInstance(name, extForm, extDir, intForm, intDir, res_count, serv_count, war_count);

            Console.Write("Choose name for your feudal: ");
            name = Console.ReadLine();
            Feudal thisFeudal = new Feudal(name);
            Thread feudalDrainThread = new Thread(new ThreadStart(thisFeudal.live));
            feudalDrainThread.IsBackground = true;
            feudalDrainThread.Start();

            thisCastle.exist();
            bool wannaExit = false;
            int tmp_int = 0;
            string tmp_str = "";

            while (thisFeudal.isHumanAlive() && !wannaExit)
            {
                if (!Castle.getInstance().isUnderFeudal)
                {
                    while ((tmp_int < 1) || (tmp_int > 4))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Choose what to do:");
                        Console.WriteLine("1)Move into the castle ");
                        Console.WriteLine("2)Wait ");
                        Console.WriteLine("3)Show my attitude ");
                        Console.WriteLine("* 4)Finish your feudal life");
                        Console.WriteLine("(1 - 4): ");
                        tmp_str = Console.ReadLine();
                        
                        if (int.TryParse(tmp_str, out _)) tmp_int = Convert.ToInt32(tmp_str);
                        Console.WriteLine();
                        if ((tmp_int <= 4) && (tmp_int >= 1))
                        {
                            break;
                        }
                        else Console.WriteLine("Invalid input. Try again...");
                    }
                    if (tmp_int == 4)
                    {
                        Console.WriteLine("#### You have ruled well. From now your castle is on its own.");
                        wannaExit = true;
                    }
                    if (tmp_int == 3)
                    {
                        Console.WriteLine(thisFeudal.getHumanInfo());
                    }
                    else if (tmp_int == 2)
                    {
                        Console.WriteLine("#### You are waiting for something... For one day(1 sec).");
                        Thread.Sleep(1000);
                    }
                    else if (tmp_int == 1)
                    {
                        Castle.getInstance().moveInto(thisFeudal);
                        Console.WriteLine("#### You finally moved into your new castle.");

                    }
                }// Feudal hadn't moved in yet
                else  
                {
                    while ((tmp_int < 1) || (tmp_int > 15))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Choose what to do:");
                        Console.WriteLine("1)Show castle info");
                        Console.WriteLine("2)Show your feudal info");
                        Console.WriteLine("3)Have a dinner ");
                        Console.WriteLine("4)Have a drink ");
                        Console.WriteLine("5)Relax at the bath ");
                        Console.WriteLine("6)Take a nap ");
                        Console.WriteLine("7)Rest in front of the fireplace ");
                        Console.WriteLine("** 8)Move out from the castle ");
                        Console.WriteLine("* 9)Finish your feudal life");
                        Console.WriteLine("* 10)Throw a man to the prison");
                        Console.WriteLine("* 11)Command to fill tar traps");
                        Console.WriteLine("* 12)Open entrance gates");
                        Console.WriteLine("* 13)Open entrance bridge");
                        Console.WriteLine("* 14)Close entrance gates");
                        Console.WriteLine("* 15)Close entrance bridge");
                        Console.WriteLine("(1 - 15): ");
                        tmp_str = Console.ReadLine();

                        if (int.TryParse(tmp_str, out _)) tmp_int = Convert.ToInt32(tmp_str);
                        Console.WriteLine();
                        if ((tmp_int <= 15) && (tmp_int >= 1))
                        {
                            break;
                        }
                        else Console.WriteLine("Invalid input. Try again...");
                    }
                    if (tmp_int == 15)
                    {
                        Castle.getInstance().externalDefSys.gateDefSys.closeBridge();
                        Console.WriteLine("#### Bridge was raised up");
                    }
                    if (tmp_int == 14)
                    {
                        Castle.getInstance().externalDefSys.gateDefSys.closeEntrance();
                        Console.WriteLine("#### Entrance gate was closed");
                    }
                    if (tmp_int == 13)
                    {
                        Castle.getInstance().externalDefSys.gateDefSys.openBridge();
                        Console.WriteLine("#### Bridge went down");
                    }
                    if (tmp_int == 12)
                    {
                        Castle.getInstance().externalDefSys.gateDefSys.openEntrance();
                        Console.WriteLine("#### Entrance gate was opened");
                    }
                    if (tmp_int == 11)
                    {
                        Castle.getInstance().externalDefSys.gateDefSys.fillTarTraps();
                        Console.WriteLine("#### Tar traps above the entrance were filled up");
                    }
                    if (tmp_int == 10)
                    {
                        if (thisFeudal.throwRandomToPrison())
                            Console.WriteLine("#### Now one of your peasants is rotting in prison");
                        else
                            Console.WriteLine("#### You have no alive peasants to put in the prison");
                    }
                    if (tmp_int == 9)
                    {
                        Console.WriteLine("#### You have ruled well. From now your castle is on its own.");
                        wannaExit = true;
                    }
                    if (tmp_int == 8)
                    {
                        Castle.getInstance().moveOut();
                        Console.WriteLine("#### You leave the castle for some time");
                        Castle.getInstance().externalDefSys.gateDefSys.closeBridge();
                        Console.WriteLine("#### Bridge went raised up");
                        Castle.getInstance().externalDefSys.gateDefSys.closeEntrance();
                        Console.WriteLine("#### Entrance gate was closed");
                    }
                    if (tmp_int == 7)
                    {
                        if (thisFeudal.useFireplace())
                        {
                            Console.WriteLine("#### You took your time by the fireplace");
                        }
                        else
                        {
                            Console.WriteLine("#### No servant have prepared the fireplace for you");
                        }
                    }
                    if (tmp_int == 6)
                    {
                        thisFeudal.sleep();
                    }
                    if (tmp_int == 5)
                    {
                        if (thisFeudal.takeBath())
                        {
                            Console.WriteLine("#### You take the BATH with pleasure");
                        }
                        else
                        {
                            Console.WriteLine("#### No servant have prepared the bath for you");
                        }
                    }
                    if (tmp_int == 4)
                    {
                        thisFeudal.drink();
                    }
                    if (tmp_int == 3)
                    {
                        thisFeudal.eat();
                    }
                    if (tmp_int == 2)
                    {
                        Console.WriteLine(thisFeudal.getHumanInfo());
                    }
                    if (tmp_int == 1)
                    {
                        Console.WriteLine(Castle.getInstance().getFullInfo());
                    }
                } // Feudal is in the castle
                tmp_int = 0;
            }

            if (!thisFeudal.isHumanAlive())
            {
                Console.WriteLine();
                Console.WriteLine(thisFeudal.getHumanInfo());
                Console.WriteLine("Your life has ended so early...");
            }
            return;
        }
    }
}
