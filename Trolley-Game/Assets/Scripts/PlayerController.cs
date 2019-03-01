using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public float rayLength;
	public LayerMask targetLayer;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject())
		{
            ClickObj();
		}

	}

    private void ClickObj()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, rayLength, targetLayer))
        {
            Debug.Log(hit.collider.name);
            if (hit.transform.gameObject.layer == 8)
            {
                Debug.Log("Clicked a clickable");
                hit.transform.gameObject.GetComponent<LeverTester>().ClickAction();
            }

        }
    }


}
