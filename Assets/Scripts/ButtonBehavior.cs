using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonBehavior : MonoBehaviour {

    public static ButtonBehavior singleton;
    public string pewpew = "PEWPEW";
    public string button1 = "button1";
    public string button2 = "button2";
    public string button3 = "button3";
    public bool isUpgrade = false;

    void Awake() 
    {
        singleton = this;
    }
    void Start() 
    {
    
    }
    void OnGUI()
    {
        if(isUpgrade == false)
        {
            if (GUI.Button(new Rect(10, 320, 60, 30), button1))
            {
                changeSetActive();
                Invoke("changeSetActive",2);
            }
            if (GUI.Button(new Rect(10, 360, 60, 30), button2))
            {

            }
            if (GUI.Button(new Rect(10, 400, 60, 30), button3))
            {

            }
        }
        if(isUpgrade == true)
        {
            if (GUI.Button(new Rect(10, 320, 60, 30), button1))
            {

            }
            if (GUI.Button(new Rect(10, 360, 60, 30), button2))
            {
                
            }
        }
    }

    public void changeSetActive() 
    {
        if (gameObject.active == true)
        {
            gameObject.SetActive(false);
        }
        else 
        {
            gameObject.SetActive(true);
        }
    }

}
