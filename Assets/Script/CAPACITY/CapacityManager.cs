using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CapacityManager : MonoBehaviour
{
    EntityManager entityManager;
    public static bool SpellIsCasting;
    public static bool GrabCasted;

    [Header(" Capacity managerment")]
    [SerializeField] public List<CapacitySTAT> Cap = new List<CapacitySTAT>();
    [SerializeField] public List<GameObject> patern = new List<GameObject>();
    [SerializeField] public Transform cameraTransform;

    [Header(" Charge")]
    [SerializeField] private GameObject exitCharge;
    [SerializeField] private List<GameObject> entitySprites = new List<GameObject>();

    [Header("Grab")]
    [SerializeField] private GameObject grabbingTransform;

    private Vector3 cameraForwardX;
    private Quaternion cameraRotationY;
    private float time = 0f;
    private void Awake()
    {
        entityManager = GetComponent<EntityManager>();
        foreach (GameObject objet in entitySprites) { objet.SetActive(false); }
    }
    private void FixedUpdate()
    {
        cameraForwardX = Camera.main.transform.forward;
        cameraForwardX.y = 0;
        cameraRotationY.y = 0;
    }

    void TakeDamage(Entity entity, int damage){
        entityManager.AsTakeDamageHandler(entity, damage);
    }

    public IEnumerator ForwardSlap()
    {
        //----------Phase 1-----------//
        SpellIsCasting = true;
        int sus = 0;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[0].spellCast);
        //----------Phase 2-----------//

        List<Entity> entitiesAlreadyDamaged = new List<Entity>();
        if (patern[sus].GetComponent<Patern>().Entity.Count > 0)
        {
            for (int j = 0; j < patern[sus].GetComponent<Patern>().Entity.Count; j++)
            {
                Entity currentEntity = patern[sus].GetComponent<Patern>().Entity[j].GetComponent<Entity>();

                if (!entitiesAlreadyDamaged.Contains(currentEntity))
                {
                    int damageAmount = Cap[0].amount;
                    TakeDamage(currentEntity, damageAmount);
                    entitiesAlreadyDamaged.Add(currentEntity);
                }
            }
        }

        yield return new WaitForSecondsRealtime(Cap[0].spellduring);
        //----------Phase 3-----------//

        patern[sus].gameObject.SetActive(false);
        SpellIsCasting = false;
        yield return null;
    }

    public IEnumerator LeftSlap()
    {
        //----------Phase 1-----------//
        SpellIsCasting = true;
        int sus = 1;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[0].spellCast);
        //----------Phase 2-----------//

        List<Entity> entitiesAlreadyDamaged = new List<Entity>();
        if (patern[1].GetComponent<Patern>().Entity.Count > 0)
        {
            for (int i = 0; i < patern[sus].GetComponent<Patern>().Entity.Count; i++)
            {
                Entity currentEntity = patern[sus].GetComponent<Patern>().Entity[i].GetComponent<Entity>();

                if (!entitiesAlreadyDamaged.Contains(currentEntity))
                {
                    int damageAmount = Cap[0].amount;
                    TakeDamage(currentEntity, damageAmount);
                    entitiesAlreadyDamaged.Add(currentEntity);
                }
            }
        }
        yield return new WaitForSecondsRealtime(Cap[0].spellduring);
        //----------Phase 3-----------//
        entitiesAlreadyDamaged.Clear();
        patern[sus].GetComponent<Patern>().Entity.Clear();
        patern[sus].gameObject.SetActive(false);
        SpellIsCasting = false;
        yield return null;
    }

    public IEnumerator RightSlap()
    {
        //----------Phase 1-----------//
        SpellIsCasting = true;
        int sus = 2;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[0].spellCast);
        //----------Phase 2-----------//

        List<Entity> entitiesAlreadyDamaged = new List<Entity>();
        if (patern[sus].GetComponent<Patern>().Entity.Count > 0)
        {
            for (int i = 0; i < patern[sus].GetComponent<Patern>().Entity.Count; i++)
            {
                Entity currentEntity = patern[sus].GetComponent<Patern>().Entity[i].GetComponent<Entity>();

                if (!entitiesAlreadyDamaged.Contains(currentEntity))
                {
                    int damageAmount = Cap[0].amount;
                    TakeDamage(currentEntity, damageAmount);
                    entitiesAlreadyDamaged.Add(currentEntity);
                }
            }
        }
        yield return new WaitForSecondsRealtime(Cap[0].spellduring);
        //----------Phase 3-----------//
        entitiesAlreadyDamaged.Clear();
        patern[sus].GetComponent<Patern>().Entity.Clear();
        patern[sus].gameObject.SetActive(false);
        SpellIsCasting = false;
        yield return null;
    }

    public IEnumerator BalayageSlap()
    {
        SpellIsCasting = true;
        for (int i = 0; i < 4; i++)
        {
            //----------Phase 1-----------//
            int sus = 3;
            patern[sus].gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(Cap[0].spellCast);
            //----------Phase 2-----------//
            List<Entity> entitiesAlreadyDamaged = new List<Entity>();
            if (patern[sus].GetComponent<Patern>().Entity.Count > 0)
            {
                for (int j = 0; j < patern[sus].GetComponent<Patern>().Entity.Count; j++)
                {
                    Entity currentEntity = patern[sus].GetComponent<Patern>().Entity[j].GetComponent<Entity>();

                    if (!entitiesAlreadyDamaged.Contains(currentEntity))
                    {
                        int damageAmount = Cap[0].amount;
                        TakeDamage(currentEntity, damageAmount);
                        entitiesAlreadyDamaged.Add(currentEntity);
                    }
                }
            }
            yield return new WaitForSecondsRealtime(Cap[0].spellduring);
            //----------Phase 3-----------//
            entitiesAlreadyDamaged.Clear();
            patern[sus].GetComponent<Patern>().Entity.Clear();
            patern[sus].gameObject.SetActive(false);
        }
        SpellIsCasting = false;
        yield return null;
    }

    public IEnumerator Dashing()
    {
        SpellIsCasting = true;
        ComboController.Attackmode = true;
        List<GameObject> entityGored = new List<GameObject>();
        //----------Phase 1-----------//
        int sus = 4;
        patern[sus].gameObject.SetActive(true);

        float Dist = 3.0f;
        while (time < Cap[2].spellCast)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -cameraForwardX, out hit, Dist))
            {
                if (hit.collider.CompareTag("Obstacle"))
                {
                    yield return null;
                }
            }
            else PlayerManager.instance.transform.Translate(-cameraForwardX.normalized * 5 * Time.deltaTime);
            float t = time / Cap[1].spellCast;

            time += Time.deltaTime;
            yield return null;
        }
        time = 0f;
        //----------Phase 2-----------//
        while (time < Cap[2].spellduring)
        {
            List<GameObject> entityGoreded = new List<GameObject>();
            entityGored = entityGoreded;
            if (patern[sus].GetComponent<Patern>().Entity.Count > 0)
            {
                for (int i = 0; i < patern[sus].GetComponent<Patern>().Entity.Count; i++)
                {
                    entityGoreded.Add(patern[sus].GetComponent<Patern>().Entity[i]);
                    patern[sus].GetComponent<Patern>().Entity[i].gameObject.SetActive(false);

                    if (entityGoreded[i].name == "ENTITY(Guerrier)") entitySprites[0].SetActive(true);
                    else if (entityGoreded[i].name == "ENTITY(Barbare)") entitySprites[1].SetActive(true);
                    else if (entityGoreded[i].name == "ENTITY(Mage)") entitySprites[2].SetActive(true);
                    else if (entityGoreded[i].name == "ENTITY(Prêtre)") entitySprites[3].SetActive(true);
                }
            }
            RaycastHit hit;

            if (Physics.Raycast(transform.position, cameraForwardX, out hit, Dist))
            {
                if (hit.collider.CompareTag("Obstacle"))
                {
                    List<Entity> entitiesAlreadyDamaged = new List<Entity>();
                    if (patern[sus].GetComponent<Patern>().Entity.Count > 0)
                    {
                        for (int j = 0; j < patern[sus].GetComponent<Patern>().Entity.Count; j++)
                        {
                            Entity currentEntity = patern[sus].GetComponent<Patern>().Entity[j].GetComponent<Entity>();

                            if (!entitiesAlreadyDamaged.Contains(currentEntity))
                            {
                                int damageAmount = Cap[0].amount;
                                TakeDamage(currentEntity, damageAmount);
                                entitiesAlreadyDamaged.Add(currentEntity);
                            }
                        }
                    }
                    for (int i = 0; i < entityGored.Count; i++)
                    {
                        entityGoreded[i].gameObject.SetActive(true);
                        entityGoreded[i].gameObject.transform.position = exitCharge.transform.position;
                    }
                    foreach (GameObject objet in entitySprites) { objet.SetActive(false); }
                    patern[sus].GetComponent<Patern>().Entity.Clear();
                    entityGoreded.Clear();
                    SpellIsCasting = false;
                    ComboController.Attackmode = false;
                    yield break;
                }
            }
            PlayerManager.instance.transform.Translate(cameraForwardX.normalized * Time.deltaTime * (PlayerManager.instance._stat.speed * 5));
            float t = time / Cap[1].spellduring;

            time += Time.deltaTime;
            yield return null;
        }
        time = 0f;
        for (int i = 0; i < entityGored.Count; i++)
        {
            entityGored[i].gameObject.SetActive(true);
            
            entityGored[i].gameObject.transform.position = exitCharge.transform.position;
        }
        foreach (GameObject objet in entitySprites) { objet.SetActive(false); }
        patern[sus].GetComponent<Patern>().Entity.Clear();
        entityGored.Clear();

        //----------Phase 3-----------//
        patern[sus].gameObject.SetActive(false);
        SpellIsCasting = false;
        ComboController.Attackmode = false;
        yield return null;
    }

    public IEnumerator Graping()
    { 
        //----------Phase 1-----------//
        int sus = 5;
        SpellIsCasting = true;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[2].spellCast);
        //----------Phase 2-----------//
        if (patern[sus].GetComponent<Patern>().Entity.Count > 0)
        {
            GrabCasted = true;
            for (int j = 0; j < patern[sus].GetComponent<Patern>().Entity.Count; j++)
            {
                patern[sus].GetComponent<Patern>().Entity[j].GetComponent<NavMeshAgent>().enabled = false;
                patern[sus].GetComponent<Patern>().Entity[j].gameObject.transform.position = grabbingTransform.transform.position;
                int damageAmount = Cap[0].amount;
                TakeDamage(patern[sus].GetComponent<Patern>().Entity[j].GetComponent<Entity>(), damageAmount);
                patern[sus].GetComponent<Patern>().Entity[j].GetComponent<NavMeshAgent>().enabled = true;
            }
        }
        patern[sus].GetComponent<Patern>().Entity.Clear();
        patern[sus].gameObject.SetActive(false);
        GrabCasted = false;
        SpellIsCasting = false;
        yield return null;
    }

    public IEnumerator BrazilZoning()
    {
        //----------Phase 1-----------//
        int sus = 6;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[3].spellCast);
        //----------Phase 2-----------//
        for (float i = 0; i < 60; i += 0.1f)
        {
            List<Entity> entitiesAlreadyDamaged = new List<Entity>();
            if (patern[sus].GetComponent<Patern>().Entity.Count > 0)
            {
                for (int j = 0; j < patern[sus].GetComponent<Patern>().Entity.Count; j++)
                {
                    Entity currentEntity = patern[sus].GetComponent<Patern>().Entity[j].GetComponent<Entity>();

                    if (!entitiesAlreadyDamaged.Contains(currentEntity))
                    {
                        int damageAmount = Cap[3].amount;
                        TakeDamage(currentEntity, damageAmount);
                        entitiesAlreadyDamaged.Add(currentEntity);
                    }
                }
            }
            yield return new WaitForSecondsRealtime(Cap[3].spellduring);
            patern[sus].GetComponent<Patern>().Entity.Clear();
        }
        patern[sus].gameObject.SetActive(false);
        yield return null;
    }

    public IEnumerator Healing()
    {
        //----------Phase 1-----------//
        int sus = 7;
        patern[sus].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(Cap[4].spellCast);
        //----------Phase 2-----------//
        for (float i = 0; i < PlayerManager.instance._stat.health + 500 || i <= PlayerManager.instance._stat.maxHealth; i += 0.1f){
            HealthRegeneration();
            yield return new WaitForSecondsRealtime(Cap[0].spellduring);
        }
        patern[sus].gameObject.SetActive(false);
        yield return null;
    }

    void HealthRegeneration()
    {
        if (PlayerManager.instance._stat.health <= PlayerManager.instance._stat.maxHealth){
            PlayerManager.instance._stat.health += 1;
        }
    }
}
