using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern : MonoBehaviour{
    public static List<GameObject> Entity = new List<GameObject>();

    public void Update() {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }



    public void OnTriggerEnter(Collider other){
        Entity.Add(other.gameObject);
    }
    
    public void OnTriggerExit(Collider other){
        Entity.Remove(other.gameObject);
    }
}
