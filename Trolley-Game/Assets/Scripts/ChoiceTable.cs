using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Trolley {
    public class ChoiceTable {
        List<Choice> choices;

        public ChoiceTable()
        {
            choices = new List<Choice>();
        }

        public void NewChoice_Random()
        {
            Choice choice = new Choice();
            choices.Add(choice);

            // Default Humans
            int r;
            r = Random.Range(1, Choice.MAX_HUMANS);
            for (int i = 0; i < r % Choice.MAX_HUMANS; i++)
            {
                Human human = new Human();
                human.Randomize();
                choice.AddHuman_Default(human);
            }

            // Switch humans
            r = Random.Range(0, Choice.MAX_HUMANS);
            for (int i = 0; i < r % Choice.MAX_HUMANS; i++)
            {
                Human human = new Human();
                human.Randomize();
                choice.AddHuman_Switch(human);
            }
        }

        public void PrintChoiceTable()
        {
            Debug.Log("CHOICE TABLE: ");
            foreach (Choice choice in choices)
            {
                choice.PrintChoice();
            }
            Debug.Log("END: ");
        }
    }
}
