using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


    public float score;
    public float money;
	// Use this for initialization
	void Start () 
    {
	    
	}


    void OnGUI() 
    {
        GUI.Box(new Rect(20, Screen.height - 40, 150, 30), "Score: " + score);

        GUI.Box(new Rect(450, Screen.height - 40, 150, 30), "Money: " + money);
    }
}
