using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeContact : MonoBehaviour {
    public Transform HeadTransform;
    Camera MainCamera;

    public float MaxDotAngle = -0.25f;

    private void Awake()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        float DotFwd = Vector3.Dot(MainCamera.transform.forward, HeadTransform.forward);

        if (DotFwd < MaxDotAngle)
        {
            HeadTransform.LookAt(MainCamera.transform);
        }
    }
}
