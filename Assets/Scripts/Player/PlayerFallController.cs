using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallController : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y <= -0.5f)
        {
            AudioSource.PlayClipAtPoint(GameManager.gameManager.fallSound, GameManager.gameManager.player.transform.position);
            GameManager.gameManager.CurrentGameState = GameManager.GameState.GameOver;
        }
    }
}
