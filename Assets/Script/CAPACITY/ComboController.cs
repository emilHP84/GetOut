using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class ComboController : MonoBehaviour
{
    public CapacityManager capacityManager;
    public static bool ComboControllerActivated;
    public static bool Attackmode;
    public List<string> Combo = new List<string>();
    public GameObject CanvasCombo;
    public TextMeshProUGUI text;


    void Start() { 
        CanvasCombo.SetActive(false);
    }

    void Update(){
        if (CapacityManager.SpellIsCasting == false)
        {
            if (CanvasCombo.activeSelf == true) StartCombo();
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                if (CanvasCombo.activeSelf == true) ClosePannel();
                else OpenPannel();
            }
        }
        else return;
    }

    void OpenPannel(){
        CanvasCombo.SetActive(true);
        ComboControllerActivated = true;
    }
    void ClosePannel(){
        CloseCombo();
        CanvasCombo.SetActive(false);
        ComboControllerActivated = false;
    }

    void StartCombo(){
        if (Input.GetKeyDown(KeyCode.W)){
            if (Combo.Contains("Z")){
                Combo.Insert(0,"...");
                Combo.Remove("Z");
            }
            else{
                Combo.Add("Z");
                Combo.Remove("...");
            }
        }
        if (Input.GetKeyDown(KeyCode.A)){
            if (Combo.Contains("Q")){
                Combo.Insert(0,"...");
                Combo.Remove("Q");
            }
            else{
                Combo.Add("Q");
                Combo.Remove("...");
            }
        }
        if (Input.GetKeyDown(KeyCode.S)){
            if (Combo.Contains("S")){
                Combo.Insert(0, "...");
                Combo.Remove("S");
            }
            else{
                Combo.Add("S");
                Combo.Remove("...");
            }
        }
        if (Input.GetKeyDown(KeyCode.D)){
            if (Combo.Contains("D")){
                Combo.Insert(0, "...");
                Combo.Remove("D");
            }
            else{
                Combo.Add("D");
                Combo.Remove("...");
            }
        }
        UpdateText();
    }
    void ClearCombo(){
        Combo.Clear();
        for (int i = 0; i < 4; i++){
            Combo.Add("...");
        }
    }
    void UpdateText(){
        for (int i = 0; i < 4; i++)
        {
            text.text = Combo[0] + " " + Combo[1] + " " + Combo[2] + " " + Combo[3];
        }
    }
    void CapacityDetector()
    {
        if (Combo.Contains(null))
        {
            StartCoroutine(capacityManager.Healing());
        }

        if (Combo[0].Contains("...") && Combo[1].Contains("...") && Combo[2].Contains("...") && Combo[3].Contains("Z")){
            StartCoroutine(capacityManager.ForwardSlap());
            ClearCombo();
            return;
        }
        if (Combo[0].Contains("...") && Combo[1].Contains("...") && Combo[2].Contains("...") && Combo[3].Contains("Q")){
            StartCoroutine(capacityManager.LeftSlap());
            ClearCombo();
            return;
        }
        if (Combo[0].Contains("...") && Combo[1].Contains("...") && Combo[2].Contains("...") && Combo[3].Contains("D")){
            StartCoroutine(capacityManager.RightSlap());
            ClearCombo();
            return;
        }
        if (Combo[0].Contains("...") && Combo[1].Contains("...") && Combo[2].Contains("Q") && Combo[3].Contains("D")){
            StartCoroutine(capacityManager.BalayageSlap());
            ClearCombo();
            return;
        }
        if (Combo[0].Contains("...") && Combo[1].Contains("...") && Combo[2].Contains("...") && Combo[3].Contains("S")){
            StartCoroutine(capacityManager.Dashing());
            ClearCombo();
            return;
        }

        if (Combo[0].Contains("...") && Combo[1].Contains("...") && Combo[2].Contains("Z") && Combo[3].Contains("S")){
            StartCoroutine(capacityManager.Graping());
            ClearCombo();
            return;
        }

        if (Combo[0].Contains("Z") && Combo[1].Contains("Q") && Combo[2].Contains("S") && Combo[3].Contains("D")){
            StartCoroutine(capacityManager.BrazilZoning());
            ClearCombo();
            return;
        }
    }
    void CloseCombo(){
        CapacityDetector();
    }
    

    
}
