using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;

    private int score = 0;

    public int Score { 
        get { return score; } 
        set { 
            score = value; 
            scoreText.text = score.ToString(); 
            scoreEvent.RaiseEvent(score);
        }   
    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnGameStart);
    }

    void Start()
    {
        health.value = 100;
        score = 0;
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    public void AddHealth(float health)
    {
        this.health.value += health;
    }

    private void OnGameStart()
    {
        characterController.enabled = true;
    }

    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset();
    }

    public void Damage(float damage) 
    {
        health.value -= damage;
        if (health.value <= 0)
        {
            playerDeadEvent.RaiseEvent();
        }
        
    }

    //public void TakeDamage(float damage)
    //{
    //    health.value -= damage;
    //    if(health.value <= 0)
    //    {
    //        characterController.enabled = false;
    //        health.value = 0;
    //        GameManager.Instance.state = GameManager.State.GAME_OVER;
    //    }
    //}
}
