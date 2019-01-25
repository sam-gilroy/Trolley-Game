using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPerson : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		Debug.Log (col.tag);
		if (col.CompareTag("Person")) {
			Destroy (col.gameObject);
		}
	}
}
