using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonBehavior : MonoBehaviour {

    public static ButtonBehavior singleton;
    public string pewpew = "PEWPEW";
    public Texture rapid;
    public Texture sniper;
    public Texture slow;
    public Texture noRapid;
    public Texture noSniper;
    public Texture noSlow;
    public Texture upgrade;
    public Texture noUpgrade;
    public Texture sell;
    public Texture menu;
    public Texture cancel;
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
        GUI.depth = 0;
        if (buildTower == true)
        {
            if (GUI.Button(new Rect(10, 15, 100, 40), rapid, style))
            {
                Debug.Log("build rapid tower");
                if(score.money >= 100)
                {
                    score.money -= 100;
                    target.GetComponent<BuildTower>().spawnTower("rapid");
                    changeSetActive();
                }
                
            }
            if (GUI.Button(new Rect(110, 15, 100, 40), slow, style))
            {
                Debug.Log("build slow tower");
                target.GetComponent<BuildTower>().spawnTower("slow");
                score.money -= 200;
                changeSetActive();
            }
            if (GUI.Button(new Rect(210, 15, 100, 40), sniper, style))
            {
                Debug.Log("build Sniper tower");
                if(score.money >= 300)
                {
                    target.GetComponent<BuildTower>().spawnTower("sniper");
                    score.money -= 300;
                }
                changeSetActive();
            }
            if (GUI.Button(new Rect(310, 15, 110, 40), cancel, style))
            {
                changeSetActive();
            }
        }
        if(isUpgrade == true)
        {

            if (GUI.Button(new Rect(210, 15, 100, 40), sell, style))
            {
                score.money += target.GetComponent<NewTurret>().sellValue;
                Destroy(target.gameObject);
                changeSetActive();
                Debug.Log("geld terug krijgen goes on this line");
            }
            if (GUI.Button(new Rect(310, 15, 110, 40), cancel, style))
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
