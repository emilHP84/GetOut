using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerManager : MonoBehaviour{
    public static PlayerManager instance;
    public STAT _stat;


    private void Awake(){
        instance = this;
        _stat.health = _stat.maxHealth;
        ComboController.Attackmode = false;
    }
    
    private void Update(){
        OnPlayerHealHandler(_stat.health, _stat.maxHealth);
    }



    public delegate void PlayerHealHandler(int health, int maxHealth);
    public static event PlayerHealHandler OnCheckHealth;
    public void OnPlayerHealHandler(int health, int maxHealth){
        OnCheckHealth?.Invoke(health,maxHealth);
    }



    public delegate void PlayerMoveHandler(Vector3 move,float speed);
    public static event PlayerMoveHandler OnPlayerMove;
    public void OnPlayerMoveHandler(Vector3 move,float speed){
        if (ComboController.Attackmode == false){
            speed = _stat.speed;
            if (ComboController.ComboControllerActivated == false) OnPlayerMove?.Invoke(move, speed);
        }
    }



    public delegate void PlayerLookHandler(Vector2 mouse, float turnSpeed);
    public static event PlayerLookHandler OnPlayerLook;
    public void OnPlayerLookHandler(Vector3 mouse, float turnSpeed){
        turnSpeed = _stat.turnSpeed;
        OnPlayerLook?.Invoke(mouse, turnSpeed);
    }



    public delegate void TakeDamageHandler(int damage);
    public static event TakeDamageHandler AsTakeDamage;
    public static void AsTakeDamageHandler(int damage)
    {
        // dégât subie
        AsTakeDamage?.Invoke(damage);
    }
}