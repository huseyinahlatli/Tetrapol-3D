using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMove : MonoBehaviour
{
    [SerializeField] private float forceSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            PlayerMovement.Instance.rigidbody.AddForce(Vector3.up * forceSpeed);

        AudioSource.PlayClipAtPoint(GameManager.gameManager.jumpSound, GameManager.gameManager.player.transform.position);
    }
}
