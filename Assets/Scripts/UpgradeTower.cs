using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeTower : MonoBehaviour {

    private GameObject uiButtons;
    private ButtonBehavior UI;
	// Use this for initialization
	void Start () 
    {
        uiButtons = GameObject.FindGameObjectWithTag("Buttons");
        UI = uiButtons.GetComponent<ButtonBehavior>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        UI.changeSetActive();
        UI.target = transform.parent.gameObject;
        UI.button1 = "upgrade";
        UI.button2 = "sell";
        UI.button3 = "cancel";
        UI.isUpgrade = true;
        UI.buildTower = false;
    }

    
}
