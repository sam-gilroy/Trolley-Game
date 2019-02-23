using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Trolley
{
    public class TestBehaviour : MonoBehaviour
    {
        ChoiceTable choiceTable;

        // Use this for initialization
        void Start()
        {
            choiceTable = new ChoiceTable();
            choiceTable.NewChoice_Random();
            choiceTable.PrintChoiceTable();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}