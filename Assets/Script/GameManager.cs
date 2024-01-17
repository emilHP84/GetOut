using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static event Action OnDeath;
    public static event Action Onpause;
    public static event Action OngameOver;

    private void Awake()
    {
        instance = this;
    }

    public static void IsDead(){
        OngameOver?.Invoke();
        Debug.Log("test");
    }
}
