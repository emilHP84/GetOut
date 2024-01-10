using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerManager : MonoBehaviour{
    public STAT _stat;

    private void Awake(){
        _stat.health = _stat.maxHealth;
    }

    private void Start()
    {
        
    }



    public delegate void PlayerHealHandler(int health, int maxHealth);
    public static event PlayerHealHandler OnCheckHealth;
    public void OnPlayerHealHandler(int health, int maxHealth){
        health = _stat.health;
        maxHealth = _stat.maxHealth;
    }



    public delegate void PlayerMoveHandler(Vector3 move,float speed);
    public static event PlayerMoveHandler OnPlayerMove;
    public void OnPlayerMoveHandler(Vector3 move,float speed){
        speed = _stat.speed;
        if(ComboController.ComboControllerActivated == false) OnPlayerMove?.Invoke(move, speed);
    }



    public delegate void PlayerLookHandler(Vector2 mouse, float turnSpeed);
    public static event PlayerLookHandler OnPlayerLook;
    public void OnPlayerLookHandler(Vector3 mouse, float turnSpeed){
        turnSpeed = _stat.turnSpeed;
        OnPlayerLook?.Invoke(mouse, turnSpeed);
    }
}