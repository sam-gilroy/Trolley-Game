using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trolley
{
    public class Choice
    {
        public const int MAX_HUMANS = 5;
        public List<Human> defaultHumans { get; private set; }
        public List<Human> switchHumans { get; private set; }

        public Choice()
        {
            defaultHumans = new List<Human>();
            switchHumans = new List<Human>();
        }

        public void AddHuman_Default(Human human)
        {
            defaultHumans.Add(human);
        }

        public void AddHuman_Switch(Human human)
        {
            switchHumans.Add(human);
        }

        public void PrintChoice()
        {
            Debug.Log("----CHOICE: DEFAULT");
            foreach (Human human in defaultHumans)
            {
                human.PrintHuman();
            }
            Debug.Log("----CHOICE: SWITCH");
            foreach (Human human in switchHumans)
            {
                human.PrintHuman();
            }
            Debug.Log("----END CHOICE: ");
        }
    }
}
