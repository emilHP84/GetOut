using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
    CharacterController _characterController;
    Camera _camera;
    public float gravity = 9.81f;
    public Vector3 myMove;

    private void OnEnable(){
        PlayerManager.OnPlayerMove += Moving;
    }
    private void OnDisable(){
        PlayerManager.OnPlayerMove -= Moving;
    }

    void Awake(){
        _characterController = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
    }

    
    void Moving(Vector3 move, float speed){
        myMove = Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * move * (speed * Time.deltaTime);
        _characterController.Move(myMove);
    }
}
