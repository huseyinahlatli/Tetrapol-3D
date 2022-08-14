using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class TrapsMovement : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MovementY());
    }

    private IEnumerator MovementY()
    {
        while (true)
        {
            transform.DOMoveY(0f, 0.5f);
            yield return new WaitForSeconds(1f);
            transform.DOMoveY(-1f, 2f);
            yield return new WaitForSeconds(2f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameManager.gameManager.CurrentGameState = GameManager.GameState.GameOver;
        
        AudioSource.PlayClipAtPoint(GameManager.gameManager.crashSound, GameManager.gameManager.player.transform.position);
    }
}
