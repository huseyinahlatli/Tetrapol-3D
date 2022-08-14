using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [HideInInspector] public int collectableObject = 0;
    private GameState _currentGameState;
    public AudioClip bridgeWalk;
    public AudioClip collectSound;
    public AudioClip crashSound;
    public AudioClip fallSound;
    public AudioClip jumpSound;
    public AudioClip transportSound;
    public AudioClip winSound;

    #region Singleton Class: GameManager
    public static GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
    }
    #endregion
    
    private void Update()
    {
        if (collectableObject >= 10)
        {
            AudioSource.PlayClipAtPoint(GameManager.gameManager.winSound, GameManager.gameManager.player.transform.position);
            PlayerMovement.Instance.moveSpeed = 0;
            Invoke(nameof(Retry), 3f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }
    
    public enum GameState
    {
        MainGame,
        GameOver
    }

    public GameState CurrentGameState
    {
        get
        {
            return _currentGameState;
        }

        set
        {
            switch (value)
            {
                case GameState.MainGame:
                    break;
                case GameState.GameOver:
                    StartCoroutine(Retry());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
            _currentGameState = value;
        }
    }

    private IEnumerator Retry()
    {
        if(!(player.transform.position.y <= -0.5))
            PlayerMovement.Instance.moveSpeed = 0f;
        
        yield return new WaitForSeconds(0.4f);
        
        RestartGame();
    }

    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
