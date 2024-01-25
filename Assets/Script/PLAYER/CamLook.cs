using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamLook : MonoBehaviour{
    private float limitRotationY = 40;

    private void OnEnable(){
        PlayerManager.OnPlayerLook += Looking;
    }
    private void OnDisable(){
        PlayerManager.OnPlayerLook -= Looking;
    }

    void Start(){

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Looking(Vector2 look, float turnSpeed){
        look.y = Mathf.Clamp(look.y, -limitRotationY, limitRotationY);
        Quaternion newRotation = Quaternion.Euler(-look.y, look.x, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, newRotation, 0.5f);
    }
}
