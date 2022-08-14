using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] private float maxValueX;
    [SerializeField] private float minValueX;
    [SerializeField] private float duration;
    
    private void Start()
    {
        StartCoroutine(SpiderMove());
    }

    private IEnumerator SpiderMove()
    {
        while (true)
        {
            transform.DOMoveX(maxValueX, duration);
            yield return new WaitForSeconds(duration);
            transform.DORotate(new Vector3(0, 90, 0), 1f, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(1f);
            transform.DOMoveX(minValueX, duration);
            yield return new WaitForSeconds(duration);
            transform.DORotate(new Vector3(0, -90, 0), 1f, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameManager.gameManager.CurrentGameState = GameManager.GameState.GameOver;
        
        AudioSource.PlayClipAtPoint(GameManager.gameManager.crashSound, GameManager.gameManager.player.transform.position);
    }
}
