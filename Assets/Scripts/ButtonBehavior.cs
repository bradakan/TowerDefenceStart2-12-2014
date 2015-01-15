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
    public bool buildTower = false;
    public GameObject target;
    public GUIStyle style;
    public Score score;

    void Awake() 
    {
        singleton = this;
    }
    void Start() 
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        changeSetActive();
    }
    void OnGUI()
    {
        if (buildTower == true)
        {
            if (GUI.Button(new Rect(10, 280, 60, 30), "Rapid,: 100",style))
            {
                Debug.Log("build rapid tower");
                if(score.money >= 100)
                {
                    score.money -= 100;
                    target.GetComponent<BuildTower>().spawnTower("rapid");
                    changeSetActive();
                }
                
            }
            if (GUI.Button(new Rect(10, 320, 60, 30), "Slow: 200", style))
            {
                Debug.Log("build slow tower");
                target.GetComponent<BuildTower>().spawnTower("slow");
                changeSetActive();
            }
            if (GUI.Button(new Rect(10, 360, 60, 30), "Sniper: 300", style))
            {
                Debug.Log("build Sniper tower");
                target.GetComponent<BuildTower>().spawnTower("sniper");
                changeSetActive();
            }
            if (GUI.Button(new Rect(10, 400, 60, 30), "Cancel", style))
            {
                changeSetActive();
            }
        }
        if(isUpgrade == true)
        {
            if (GUI.Button(new Rect(10, 320, 60, 30), "Upgrade", style))
            {
                Debug.Log("upgrade function goes here");
            }
            if (GUI.Button(new Rect(10, 360, 60, 30), "Sell", style))
            {
                Destroy(target.gameObject);
                Debug.Log("geld terug krijgen goes on this line");
            }
            if (GUI.Button(new Rect(10, 400, 60, 30), "Cancel", style))
            {
                changeSetActive();
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
