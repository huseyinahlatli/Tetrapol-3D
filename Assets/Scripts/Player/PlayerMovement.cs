using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton Class: PlayerMovement
    public static PlayerMovement Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    public new Rigidbody rigidbody;
    private float _horizontal;
    private float _vertical;
    private float _speed;
    [SerializeField] public float moveSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        
        _speed = (moveSpeed * Time.deltaTime);
        transform.Translate(_horizontal * _speed, 0, _vertical * _speed, Space.World);

        PlayerTurn();
    }

    private void PlayerTurn()
    {
        if (Input.GetKeyDown(KeyCode.W))
            transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.A))
            transform.eulerAngles = new Vector3(0, -90, 0);
        if (Input.GetKeyDown(KeyCode.S))
            transform.eulerAngles = new Vector3(0, 180, 0);
        if (Input.GetKeyDown(KeyCode.D))
            transform.eulerAngles = new Vector3(0, 90, 0);
    }
}
