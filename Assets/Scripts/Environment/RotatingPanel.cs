using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPanel : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 1, 0) * (rotateSpeed * Time.deltaTime));
    }
}
