using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class CapacityManager : MonoBehaviour{
    public static bool SpellIsCasting;
    public static int damageCap;
    [SerializeField] public List<CapacitySTAT> Cap = new List<CapacitySTAT>();
    [SerializeField] public List<GameObject> patern = new List<GameObject>();
    [SerializeField] public Transform cameraTransform;

    private Vector3 cameraForwardX;
    private float time = 0f;

    private void FixedUpdate(){
        cameraForwardX = Camera.main.transform.forward;
        cameraForwardX.y = 0;
    }

    public IEnumerator ForwardSlap(){
        //----------Phase 1-----------//
        SpellIsCasting = true;
        int sus = 0;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[0].spellCast);
        //----------Phase 2-----------//
        if (patern[sus].GetComponent<Patern>().Entity.Count > 0){
            for(int i = 0; i < patern[sus].GetComponent<Patern>().Entity.Count; i++){
                damageCap = Cap[0].amount;
                EntityManager.AsTakeDamageHandler(damageCap);
            }
        }
        yield return new WaitForSecondsRealtime(Cap[0].spellduring);
        //----------Phase 3-----------//
        patern[sus].gameObject.SetActive(false);
        SpellIsCasting = false;
        yield return null;
    }



    public IEnumerator LeftSlap(){
        //----------Phase 1-----------//
        SpellIsCasting = true;
        int sus = 1;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[0].spellCast);
        //----------Phase 2-----------//
        if (patern[1].GetComponent<Patern>().Entity.Count > 0){
            for (int i = 0; i < patern[sus].GetComponent<Patern>().Entity.Count; i++){
                damageCap = Cap[0].amount;
                EntityManager.AsTakeDamageHandler(damageCap);
            }
        }
        yield return new WaitForSecondsRealtime(Cap[0].spellduring);
        //----------Phase 3-----------//
        patern[sus].gameObject.SetActive(false);
        SpellIsCasting = false;
        yield return null;
    }



    public IEnumerator RightSlap(){
        //----------Phase 1-----------//
        SpellIsCasting = true;
        int sus = 2;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[0].spellCast);
        //----------Phase 2-----------//
        if (patern[sus].GetComponent<Patern>().Entity.Count > 0){
            for (int i = 0; i < patern[sus].GetComponent<Patern>().Entity.Count; i++){
                damageCap = Cap[0].amount;
                EntityManager.AsTakeDamageHandler(damageCap);
            }
        }
        yield return new WaitForSecondsRealtime(Cap[0].spellduring);
        //----------Phase 3-----------//
        patern[sus].gameObject.SetActive(false);
        SpellIsCasting = false;
        yield return null;
    }



    public IEnumerator BalayageSlap(){
        SpellIsCasting = true;
        for (int i = 0; i < 4; i++)
        {
            //----------Phase 1-----------//
            int sus = 3;
            patern[sus].gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(Cap[0].spellCast);
            //----------Phase 2-----------//
            if (patern[sus].GetComponent<Patern>().Entity.Count > 0){
                for (int j = 0; j < patern[sus].GetComponent<Patern>().Entity.Count; j++)
                {
                    damageCap = Cap[0].amount;
                    EntityManager.AsTakeDamageHandler(damageCap);
                }
            }
            yield return new WaitForSecondsRealtime(Cap[0].spellduring);
            //----------Phase 3-----------//
            patern[sus].gameObject.SetActive(false);
        }
        SpellIsCasting = false;
        yield return null;
    }



    public IEnumerator Dashing(){
        SpellIsCasting = true;
        //----------Phase 1-----------//
        float Dist = 3.0f;
        while (time < Cap[1].spellCast){
            RaycastHit hit;
            if (Physics.Raycast(transform.position,-transform.forward, out hit, Dist)){
                if (hit.collider.CompareTag("Obstacle")){
                    break;
                }
            }
            transform.Translate(-cameraForwardX.normalized * 5 * Time.deltaTime);
            float t = time / Cap[1].spellCast;
            
            time += Time.deltaTime;
            yield return null;
        }
        time = 0f;

        while (time < Cap[1].spellduring){
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.forward, out hit, Dist)){
                if (hit.collider.CompareTag("Obstacle")){
                    break;
                }
            }
            transform.Translate(cameraForwardX.normalized * Time.deltaTime * (PlayerManager.instance._stat.speed * 10));
            float t = time / Cap[1].spellduring;

            time += Time.deltaTime;
            yield return null;
        }
        time = 0f;
        
        SpellIsCasting = false;
        yield return null;
    }

    

    public IEnumerator Graping(){
        return null;
    }

    public IEnumerator BrazilZoning(){
        return null;
    }

    public IEnumerator Healing()
    {
        return null;
    }
}
