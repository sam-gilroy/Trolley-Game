using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Trolley
{

    public struct Human
    {
        public const int numGenders = 3;
        public const int numAges = 4;
        public const int numGirths = 2;
        public const int numCrimes = 2;

        public enum GENDER
        {
            MALE = 0,
            FEMALE,
            PREGNANT_FEMALE
        }

        public enum AGE
        {
            BABY = 0,
            YOUTH,
            ADULT,
            SENIOR
        }

        public enum GIRTH
        {
            SKINNY = 0,
            FAT
        }

        public enum CRIME
        {
            NONE = 0,
            CRIMINAL
        }

        public GENDER gender { get; private set; }
        public AGE age { get; private set; }
        public GIRTH girth { get; private set; }
        public CRIME crime { get; private set; }

        public Human(GENDER gender = GENDER.MALE, AGE age = AGE.BABY, GIRTH girth = GIRTH.SKINNY, CRIME crime = CRIME.NONE)
        {
            this.gender = gender;
            this.age = age;
            this.girth = girth;
            this.crime = crime;
        }

        public void SetGender(GENDER gender)
        {
            this.gender = gender;
        }

        public void SetAge(AGE age)
        {
            this.age = age;
        }

        public void SetGirth(GIRTH girth)
        {
            this.girth = girth;
        }

        public void SetCrime(CRIME crime)
        {
            this.crime = crime;
        }

        public void Randomize()
        {
            float r;
            r = Random.value * 100;

            gender = (GENDER)(r % numGenders);
            age =       (AGE)(r % numAges);
            crime =   (CRIME)(r % numCrimes);
            girth =   (GIRTH)(r % numGirths);
        }

        public void PrintHuman()
        {
            string output="";

            output += "--------| GENDER: " + gender.ToString() + " | ";
            output += "AGE: " + age.ToString() + " | ";
            output += "CRIME: " + crime.ToString() + " | ";
            output += "GIRTH: " + girth.ToString() + " | ";

            Debug.Log(output);
        }
    }
}
