using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


    public float score;
    public float money;
    public float health = 100;
    public Texture fullHealth;
    public Texture threeFourthHealth;
    public Texture halfHealth;
    public Texture kwarterhealth;
    public Texture bamboo;
	// Use this for initialization
	void Start () 
    {
	    
	}


    void OnGUI() 
    {
        GUI.Box(new Rect(20, Screen.height - 40, 150, 30), "Score: " + score);

        GUI.Box(new Rect(450, Screen.height - 40, 150, 30), "Money: " + money);

        GUI.DrawTexture(new Rect(-30, 10, 700, 50), bamboo, ScaleMode.StretchToFill);

        if (health >= 75)
        {
            GUI.DrawTexture(new Rect(400, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(450, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(500, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(550, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
        }
        if (health < 75 && health > 50)
        {
            GUI.DrawTexture(new Rect(400, 10, 50, 50), kwarterhealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(450, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(500, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(550, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
        }
        if (health <= 50 && health > 25)
        {
            GUI.DrawTexture(new Rect(400, 10, 50, 50), kwarterhealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(450, 10, 50, 50), kwarterhealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(500, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(550, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
        }
        if (health <= 25 && health > 0)
        {
            GUI.DrawTexture(new Rect(400, 10, 50, 50), kwarterhealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(450, 10, 50, 50), kwarterhealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(500, 10, 50, 50), kwarterhealth, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(550, 10, 50, 50), fullHealth, ScaleMode.StretchToFill);
        }
        if(health <= 0)
        {
            Application.LoadLevel(2);
        }
    }
}
