using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTester : MonoBehaviour {

   // public GameObject objSwitchTrack;

    [SerializeField] private float trackLeftX = -1.7f;
    [SerializeField] private float trackRightX = 1.7f;
    [SerializeField] private bool leaningLeft = true;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void LeftTrigger()
    {
        if (!leaningLeft)
        {
            gameObject.transform.position.Set(trackLeftX, transform.position.y, transform.position.z);
            leaningLeft = true;
        }
    }

    public void RightTrigger()
    {
        if (leaningLeft)
        {
            gameObject.transform.position.Set(trackRightX, transform.position.y, transform.position.z);
            leaningLeft = false;
        }
    }


}
