using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTester : MonoBehaviour {

	public GameObject objSwitchTrack;

	[SerializeField] private float trackLeftX = -1.7f;
	[SerializeField] private float trackRightX = 1.7f;
	[SerializeField] private bool leaningLeft = true;
    public Train objTrain;

	// Use this for initialization
	void Start() {
        if (!leaningLeft)
        {
            objSwitchTrack.transform.position = new Vector3(trackRightX, transform.position.y, transform.position.z);
        }
    }

	// Update is called once per frame
	void Update() {

	}

	public void ClickAction() {
		SwitchDirection ();
	}

	public void SwitchDirection() {
		if (leaningLeft) {
			RightTrigger ();
		} else {
			LeftTrigger ();
		}
	}

	public void LeftTrigger()
	{
		objSwitchTrack.transform.position = new Vector3(trackLeftX, transform.position.y, transform.position.z);
		leaningLeft = true;
        objTrain.leftPath = true;
    }

	public void RightTrigger()
	{
		objSwitchTrack.transform.position = new Vector3(trackRightX, transform.position.y, transform.position.z);
		leaningLeft = false;
        objTrain.leftPath = false;
	}


}
