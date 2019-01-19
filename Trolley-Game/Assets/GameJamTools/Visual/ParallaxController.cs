using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {
    [SerializeField] protected List<ParallaxTransform> transforms;

    private void Update()
    {
        foreach (ParallaxTransform pTransform in transforms)
        {
            pTransform.transform.position = transform.position * pTransform.scale;
        }
    }
}
