using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slap : CapacityManager
{
    public IEnumerator ForwardSlap(){
        yield return new WaitForSecondsRealtime(spellCast);
        if (Patern.Entity.Count > 0)
        {
            
        }
        yield return new WaitForSecondsRealtime(spellduring);
        yield return null;
    }
    public IEnumerator LeftSlap()
    {
        yield return null;
    }
    public IEnumerator RightSlap()
    {
        yield return null;
    }
    public IEnumerator BalayageSlap()
    {
        yield return null;
    }
}
