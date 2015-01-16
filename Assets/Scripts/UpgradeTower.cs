using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeTower : MonoBehaviour {

    private ButtonBehavior UI;

    void Awake() 
    {
        UI = GameObject.FindGameObjectWithTag("Buttons").GetComponent<ButtonBehavior>();
    
    }
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        
        UI.changeSetActive();
        UI.target = transform.parent.gameObject;
        UI.isUpgrade = true;
        UI.buildTower = false;
        Debug.Log("test onclick");
    }

    
}
