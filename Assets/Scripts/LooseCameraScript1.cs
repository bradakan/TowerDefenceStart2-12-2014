using UnityEngine;
using System.Collections;

public class LooseCameraScript1 : MonoBehaviour {

    public Texture reStart;
    public Texture menu;
    public GUIStyle style;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 250, 100, 40), reStart, style))
        {
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(10, 300, 100, 40), menu, style))
        {
            Application.LoadLevel(0);
        }
    }

	
}
