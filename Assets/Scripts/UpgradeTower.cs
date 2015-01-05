using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeTower : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        Debug.Log("test onclick");
        Destroy(transform.parent.gameObject);
    }

    void OnMouseOver()
    {
        Debug.Log("test onmouseover");
    }
}
