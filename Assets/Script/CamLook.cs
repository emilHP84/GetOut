using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamLook : MonoBehaviour
{
    Vector2 Mouse;
    private float limitRotationY = 40;
    
    void Start(){

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update(){
        Mouse.x += Input.GetAxis("Mouse X");
        Mouse.y += Input.GetAxis("Mouse Y");
        Mouse.y = Mathf.Clamp(Mouse.y, -limitRotationY, limitRotationY);
        transform.localRotation = Quaternion.Euler(-Mouse.y + PlayerManager.instance._stat.turnSpeed * Time.deltaTime, Mouse.x + PlayerManager.instance._stat.turnSpeed * Time.deltaTime, 0) ;
    }
}
