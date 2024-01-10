using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public static PlayerManager instance;
    public STAT _stat;

    private void Awake()
    {
        instance = this;
    }
}
