using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    [Header ("Camera Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float mouseSensitivity;
    
    [Space]
    private float _mouseHorizontal;
    private float _mouseVertical;
    private Transform _cameraTransform;
    private void Start()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.position + offset,
            lerpSpeed * Time.deltaTime
        );

        if (Input.GetMouseButton(1))
        {
            _mouseHorizontal += Input.GetAxis("Mouse X") * mouseSensitivity;
            _mouseVertical += Input.GetAxis("Mouse Y") * mouseSensitivity;
            transform.eulerAngles = new Vector3(-1 * _mouseVertical, _mouseHorizontal, 0);
            target.transform.eulerAngles = new Vector3(0, _mouseHorizontal, 0);
            _cameraTransform.Rotate(new Vector3(35, 0, 0));
        }

        if (Input.GetMouseButtonUp(1))
        {
            _cameraTransform.DORotate(new Vector3(35, 0, 0), 1f);
            _mouseHorizontal = 0;
            _mouseVertical = 0;
        }
    }
}
