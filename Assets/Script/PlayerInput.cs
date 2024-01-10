using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    PlayerManager playerManager;

    float horizotalMove;
    float verticalMove;
    float MouseX;
    float MouseY;

    private void Awake(){
        playerManager = GetComponent<PlayerManager>();
    }
    void Update(){
        horizotalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        playerManager.OnPlayerMoveHandler(new Vector3(horizotalMove,0,verticalMove), playerManager._stat.speed);

        MouseX += Input.GetAxis("Mouse X");
        MouseY += Input.GetAxis("Mouse Y");
        playerManager.OnPlayerLookHandler(new Vector2(MouseX, MouseY), playerManager._stat.turnSpeed);
    }

}
