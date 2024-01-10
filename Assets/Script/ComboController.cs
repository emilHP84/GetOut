using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class ComboController : MonoBehaviour
{
    public static bool ComboControllerActivated;
    public List<string> Combo = new List<string>();
    public GameObject CanvasCombo;
    public TextMeshProUGUI text;


    private void Awake(){
        
    }
    void Start() { 
        CanvasCombo.SetActive(false);
    }

    void Update(){
        if (CanvasCombo.activeSelf == true) StartCombo();
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (CanvasCombo.activeSelf == true) ClosePannel();
            else OpenPannel();
        }
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
    void CloseCombo(){
        CapacityDetector();
        ClearCombo();
    }


    void CapacityDetector(){
        if (Combo.Contains(null)) {
            CapacityManager capacity = new Heal();
            if(capacity is Heal){
                Heal heal = (Heal)capacity;
                heal.Healing();
            }
        }

        if (Combo.Contains("Z") || Combo.Contains("Q") || Combo.Contains("D") || Combo.Contains("Q" + "D")) {
            CapacityManager capacity = new Slap();
            if (capacity is Slap){
                Slap slap = (Slap)capacity;
                if (Combo.Contains("Z")){
                    slap.ForwardSlap();
                }
                if (Combo.Contains("Q")){
                    slap.LeftSlap();
                }
                if (Combo.Contains("D")){
                    slap.RightSlap();
                }
                if (Combo.Contains("Q" + "D")){
                    slap.BalayageSlap();
                }
            }
        }
        
        if (Combo.Contains("S")) {
            CapacityManager capacity = new Dash();
            if (capacity is Dash){
                Dash dash = (Dash)capacity;
                dash.Dashing();
            }
        }
        
        if (Combo.Contains("Z" + "S")) {
            CapacityManager capacity = new Grab();
            if (capacity is Grab){
                Grab grab = (Grab)capacity;
                grab.Graping();
            }
        }

        if (Combo.Contains("Z" + "Q" + "S" + "D")) {
            CapacityManager capacity = new BrazilZone();
            if (capacity is BrazilZone){
                BrazilZone brazilZone = (BrazilZone)capacity;
                brazilZone.BrazilZoning();
            }
        }
    }

    
}
