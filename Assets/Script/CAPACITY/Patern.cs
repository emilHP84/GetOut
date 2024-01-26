using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern : MonoBehaviour{
    public List<GameObject> Entity = new List<GameObject>();

    
    private void OnDisable(){
        Entity.Clear();
    }

    public void Update() {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        
    }



    public void OnTriggerEnter(Collider other){
        if (other.tag == "Entity"){
            Entity.Add(other.gameObject);
        }
    }
    
    public void OnTriggerExit(Collider other){
        Entity.Remove(other.gameObject);
    }
}
