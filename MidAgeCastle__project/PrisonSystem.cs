using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class PrisonSystem
    {
        public List<Human> prisoners;
        public List<Human> guardians;

        public PrisonSystem()
        {
            prisoners = new List<Human>();
            guardians = new List<Human>();
        }
        public void addNewPrisoner(Human prisoner)
        {
            prisoners.Add(prisoner);
        }
        public void hireNewGuardian(Human guardian)
        {
            guardians.Add(guardian);
        }
        public void torturePrisoner(int i)
        {
            prisoners[i].harm();
            if (!prisoners[i].isHumanAlive())
            {
                endPrisoner(i);
            }
        }
        public void endPrisoner(int i)
        {
            prisoners.RemoveAt(i);
        }
        public void checkForDead()
        {
            for (int i = 0; i < prisoners.Count; i++)
            {
                if (!prisoners[i].isHumanAlive() || !prisoners[i].isHumanInPrison())
                {
                    endPrisoner(i);
                }
            }
        }

        public void exist()
        {
            Thread checkThread = new Thread(new ThreadStart(checkForDead));
            checkThread.IsBackground = true;
            checkThread.Start();
        }
    }
}
