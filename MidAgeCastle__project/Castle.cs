using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class Castle
    {
        protected string name;
        public ExternalDefenceSystem externalDefSys;
        public InternalDefenceSystem internalDefSys;
        public WaterDistributionSystem waterDistribSys;
        public JustLivingSystem livingSys;
        public ComfyLivingSystem comfyLivingSys;
        public PrisonSystem prisonSys;
        private Feudal currentFeudal;

        public bool isUnderAttack;
        public bool isUnderSiege;
        public bool isUnderFeudal;

        private static Castle instance = null;
        private static object syncRoot = new Object();

        private Castle()
        {
            name = "Unnamed";
            externalDefSys = new ExternalDefenceSystem();
            internalDefSys = new InternalDefenceSystem();
            waterDistribSys = new WaterDistributionSystem();
            livingSys = new JustLivingSystem();
            comfyLivingSys = new ComfyLivingSystem();
            prisonSys = new PrisonSystem();
            isUnderAttack = false;
            isUnderSiege = false;
            isUnderFeudal = false;
            currentFeudal = null;
        }
        private Castle(string _name, CastleForm extForm, WorldDirection extPos, CastleForm intForm, WorldDirection intPos, int res_count, int serv_count, int war_count)
        {
            name = _name;
            externalDefSys = new ExternalDefenceSystem(extForm, extPos);
            internalDefSys = new InternalDefenceSystem(intForm, intPos);
            waterDistribSys = new WaterDistributionSystem();
            livingSys = new JustLivingSystem(res_count, serv_count, war_count);
            comfyLivingSys = new ComfyLivingSystem();
            prisonSys = new PrisonSystem();
            isUnderAttack = false;
            isUnderSiege = false;
            isUnderFeudal = false;
            currentFeudal = null;
        }
        public static Castle getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Castle();
                    }
                }
            }
            return instance;
        }
        public static Castle getInstance(string _name, CastleForm extForm, WorldDirection extPos, CastleForm intForm, WorldDirection intPos, int res_count, int serv_count, int war_count)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Castle(_name, extForm, extPos, intForm, intPos, res_count, serv_count, war_count);
                    }
                }
            }
            return instance;
        }
        public Feudal getCurrentFeudal()
        {
            return currentFeudal;
        }
        public void moveInto(Feudal feudal)
        {
            Console.WriteLine("#### Castle entrance bridge raises up...");
            externalDefSys.gateDefSys.openBridge();
            Console.WriteLine("#### Castle entrance gates open...");
            externalDefSys.gateDefSys.openEntrance();
            isUnderFeudal = true;
            currentFeudal = feudal;
        }
        public void moveOut()
        {
            Console.WriteLine("#### Castle entrance bridge raises up...");
            externalDefSys.gateDefSys.openBridge();
            Console.WriteLine("#### Castle entrance gates open...");
            externalDefSys.gateDefSys.openEntrance();
            isUnderFeudal = false;
            currentFeudal = null;
        }
        public Dictionary<WorldDirection, bool> defendAgainstAttack(List<DirectedAttack> attackVectors, int suggestedSiegeDurationMs)
        {
            isUnderAttack = true;
            internalDefSys.donjonTower.setUnderAttack();
            bool attackResult = externalDefSys.takeAttack(attackVectors);
            Dictionary<WorldDirection, bool> exposedDirections = externalDefSys.displayFallenDefenses();
            if (attackResult)
            {
                isUnderSiege = true;
                waterDistribSys.disableWells();
                Thread.Sleep(suggestedSiegeDurationMs);
            }
            return exposedDirections;
        }
        public void exist()
        {
            waterDistribSys.existInCastle();//Awake all wells in castle
            livingSys.liveInCastle(); // Awake all humans in castle
            internalDefSys.exist(); // Awake donjon tower gaining food
            prisonSys.exist(); // Awake just for check of dead prisoners
        }

        public string getFullInfo()
        {
            string result = "";
            result += "++++++++++++++++++++++++++++++++++++++\n";
            result += "Castle name: " + name + "\n";
            bool bridge = externalDefSys.gateDefSys.isBridgeDowned();
            bool gate = externalDefSys.gateDefSys.isGateOpened();
            if (bridge) result += "The bridge is down(open)\n";
            else result += "The bridge is up(closed)\n";
            if (gate) result += "The entrance gate is opened.\n";
            else result += "The entrance gate is closed.\n";
            result += "wells in the castle: \n";
            for (int i = 0; i< waterDistribSys.well_count; i++)
            {
                result += "(" + i.ToString() + ") has " + waterDistribSys.wells[i].showWaterAmount().ToString() + "\n";
            }
            result += "\n";
            result += "Donjon tower well has " + waterDistribSys.donjonWell.showWaterAmount().ToString() + "\n";
            result += "\nYour peasants\n";
            for (int i = 0; i<livingSys.people.Count; i++)
            {
                result += livingSys.people[i].getHumanInfo();
            }
            result += "!!Prisoners!!\n";
            for (int i = 0; i < prisonSys.prisoners.Count; i++)
            {
                result += prisonSys.prisoners[i].getHumanInfo();
            }
            result += "++++++++++++++++++++++++++++++++++++++\n";
            return result;
        }
    }
}
