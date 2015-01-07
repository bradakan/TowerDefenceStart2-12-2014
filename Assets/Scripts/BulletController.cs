using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float damage;
    public float slow;
    public bool stun;
    public Transform target;
	// Use this for initialization
	void Start () 
    {
        Invoke("destroyThis",20);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(target != null)
        {
            transform.LookAt(target);
        }

        this.transform.Translate(Vector3.forward * Time.deltaTime *40);
	}

    public void destroyThis() 
    {
        Destroy(this.gameObject);
    }
}
