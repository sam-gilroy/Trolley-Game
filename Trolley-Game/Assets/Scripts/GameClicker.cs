using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trolley
{

    public class GameClicker : MonoBehaviour
    {
        public LayerMask clickMask;
        private GameObject grabTarget;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        // Checks for clicking
        void CheckForInput()
        {
            if (Input.GetButtonDown("Fire1") && grabTarget == null)
            {
                RaycastHit hit;

                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(r, out hit, 100.0f, clickMask))
                {

                    grabTarget = hit.transform.GetComponent<Lever>();

                    TurnOn_BuildUI();
                }
            }


            if (Input.GetButtonDown("Fire2"))
            {
                ClearButtons();
            }
        }


    }
}

