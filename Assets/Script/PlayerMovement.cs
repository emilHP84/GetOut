using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
    CharacterController _characterController;
    Camera _camera;
    public float gravity = 9.81f;

    void Awake(){
        _characterController = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
    }

    
    void Update(){
        float horizotalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        Vector3 move = Vector3.zero;

        if (ComboController.ComboControllerActivated == false){
            if (horizotalMove != 0 || verticalMove != 0){
                move += Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * new Vector3(horizotalMove * PlayerManager.instance._stat.speed * Time.deltaTime, 0, verticalMove * PlayerManager.instance._stat.speed * Time.deltaTime); ;
            }
        }
        _characterController.Move(move);


    }
}
