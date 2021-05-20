using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MidAgeCastle__project
{
    class JustLivingSystem
    {
        public List<Human> people;
        public int residents_amount;
        public int servants_amount;
        public int warriors_amount;

        public JustLivingSystem()
        {
            residents_amount = 0;
            servants_amount = 0;
            warriors_amount = 0;
            people = new List<Human>();
        }
        public JustLivingSystem(int res_amount, int serv_amount, int war_amount)
        {
            residents_amount = res_amount;
            servants_amount = serv_amount;
            warriors_amount = war_amount;
            people = new List<Human>();
            for(int i = 0; i < residents_amount; i++)
            {
                people.Add(new Human());
            }
            for (int i = 0; i < servants_amount; i++)
            {
                people.Add(new Servant());
            }
            for (int i = 0; i < warriors_amount; i++)
            {
                people.Add(new Guardian());
            }
        }
        public void newResidentHome()
        {
            people.Insert(residents_amount - 1,new Human());
            residents_amount++;
            startNewLiving(HumanRole.resident);
        }
        public void newServantHome()
        {
            people.Insert(servants_amount - 1, new Human());
            servants_amount++;
            startNewLiving(HumanRole.servant);
        }
        public void newWarriorHome()
        {
            people.Insert(warriors_amount - 1, new Human());
            warriors_amount++;
            startNewLiving(HumanRole.guardian);
        }
        private void startNewLiving(HumanRole role)
        {
            if (role == HumanRole.feudal) return;
            int index = 0;
            switch (role)
            {
                case HumanRole.resident: index = residents_amount; break;
                case HumanRole.servant: index = residents_amount + servants_amount; break;
                case HumanRole.guardian: index = residents_amount + servants_amount + warriors_amount; break;
            }
            index--;
            if (index < 0) return;
            people[index].live();
        }

        public void deleteHuman(int i)
        {
            people.RemoveAt(i);
        }
        public void deleteHuman(HumanRole role, int i)
        {
            if (role == HumanRole.feudal) return;
            int index = 0;
            switch (role)
            {
                case HumanRole.resident: index = residents_amount; residents_amount--; break;
                case HumanRole.servant: index = residents_amount + servants_amount; servants_amount--; break;
                case HumanRole.guardian: index = residents_amount + servants_amount + warriors_amount; warriors_amount--; break;
            }
            index--;
            if (index < 0) return;
            people.RemoveAt(index);
        }
        public void checkForDead()
        {
            for (int i = 0; i< people.Count; i++)
            {
                if (!people[i].isHumanAlive() || people[i].isHumanInPrison())
                {
                    people.RemoveAt(i);
                    if (i < residents_amount) residents_amount--;
                    else if (i < residents_amount + servants_amount) servants_amount--;
                    else if (i < residents_amount + servants_amount + warriors_amount) warriors_amount--;
                }
            }
        }


        public void sleep()
        {
            Thread.Sleep(300);
        }

        public void liveInCastle()
        {
            foreach(Human human in people)
            {
                Thread newThread = new Thread(new ThreadStart(human.live));
                newThread.IsBackground = true;
                newThread.Start();
            }
            Thread checkThread = new Thread(new ThreadStart(checkForDead));
            checkThread.IsBackground = true;
            checkThread.Start();
        }
    }
}
