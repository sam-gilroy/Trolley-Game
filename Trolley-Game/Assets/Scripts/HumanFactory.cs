using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// IDK IF WE ACTUALLY NEED THIS XD XD XD XD 
namespace Trolley {
    using GENDER = Human.GENDER;
    using AGE = Human.AGE;
    using GIRTH = Human.GIRTH;
    using CRIME = Human.CRIME;

    public class HumanFactory
    {
        Stack<Human> recycledHumans;

        private static HumanFactory instance;

        public static HumanFactory Instance()
        {
            if (instance == null)
            {
                instance = new HumanFactory();
                instance.recycledHumans = new Stack<Human>();
            }

            return instance;
        }

        public Human CreateHuman(GENDER gender = GENDER.MALE, AGE age = AGE.BABY, GIRTH girth = GIRTH.SKINNY, CRIME crime = CRIME.NONE)
        {
            if (recycledHumans.Count == 0)
                return new Human(gender, age, girth, crime);
            else
                return recycledHumans.Pop();
        }

        public void ReturnHuman(Human human)
        {
            recycledHumans.Push(human);
        }
    }
}