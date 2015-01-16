using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Texture start;
    public GUIStyle style;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 250, 100, 40), start, style))
        {
            Application.LoadLevel(1);
        }
    }
}
