using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameScreenUI;
    [SerializeField] GameObject gameoverScreenUI;
    [SerializeField] GameObject gameWinScreenUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;
    [SerializeField] GameObject respawn;
    [SerializeField] GameObject player;

    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;

    public enum State
    {
        TITLE,
        START_GAME,
        START_LEVEL,
        PLAY_GAME,
        PLAYER_DEAD,
        GAME_OVER,
        PLAYER_WIN
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 3;
    public float stateTimer = 0;

    public int Lives { get { return lives; } set { lives = value; livesUI.text = "LIVES " + lives.ToString(); } }
    public float Timer { 
        get { return timer; } 
        set { timer = value; timerUI.text = string.Format("{0:F1}", timer); } 
    }

    void Start()
    {
        //scoreEvent.Subscribe(OnAddPoints);
    }

    private void Update()
    {
        switch(state)
        { 
            case State.TITLE:
                if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
                {
                    break;
                }
                titleUI.SetActive(true);
                gameScreenUI.SetActive(false);
                gameoverScreenUI.SetActive(false);
                gameWinScreenUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                gameScreenUI.SetActive(true);
                Lives = 3;
                Timer = 120;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
                state = State.PLAY_GAME;
                break;
            case State.START_LEVEL:
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
                //Timer = 300;
                health.value = 100;
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    stateTimer = 0;
                    state = State.PLAYER_DEAD;
                }
                if(health.value <= 0)
                {
                    stateTimer = 0;
                    state = State.PLAYER_DEAD;
                }
                //if all coins collected win
                if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
                {
                    state = State.PLAYER_WIN;
                }
                break;

            case State.PLAYER_DEAD:
                Lives--;
                stateTimer = 0;
                if (Lives > 0) state = State.START_LEVEL;
                else state = State.GAME_OVER;
                break;
            case State.GAME_OVER:
                gameoverScreenUI.SetActive(true);
                stateTimer += Time.deltaTime;
                if (stateTimer> 5)
                {
                    if (Lives > 0) state = State.START_LEVEL;
                    else state = State.TITLE;
                }
                break;
            case State.PLAYER_WIN:
                gameScreenUI.SetActive(false);
                gameWinScreenUI.SetActive(true);
                player.SetActive(false);
                stateTimer += Time.deltaTime;
                if (stateTimer > 5)
                {
                    state = State.TITLE;
                }
                break;
            default:
                break;
        }
        
        healthUI.value = health.value / 100.0f;
    }

    public void AddTime(float time)
    {
        timer += time;
    }

    public void OnStartGame()
    {
        state = State.START_GAME;
    }

    public void OnPlayerDead()
    {
        if (state == State.PLAY_GAME)
        {
            state = State.PLAYER_DEAD;
        }
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }
}
