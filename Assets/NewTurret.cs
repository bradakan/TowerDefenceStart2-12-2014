using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewTurret : MonoBehaviour {

    private Transform target;
    public Transform bulletSpawnpoint;
    public Transform Bullet;
    private float cooldown;
    private float cooldownTime = 1;
    public static bool waitingforTarget = true;
    public List<Transform> listTargets = new List<Transform>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(waitingforTarget == false)
        {
            setNewTarget();
        }
        if (listTargets.Count > 0 && cooldown < Time.time && target != null)
        {
            cooldown = Time.time + cooldownTime;
            transform.LookAt(target);
            Instantiate(Bullet, bulletSpawnpoint.position, this.transform.rotation);

        }
        else if (listTargets.Count > 0 && target != null)
        {
            transform.LookAt(target);
        }
	}

    public void setNewTarget() 
    {
        for (int i = 0; i < listTargets.Count; i++)
        {
            if (target != null)
            {
                if (Vector3.Distance(listTargets[i].position, transform.position) < Vector3.Distance(target.position, transform.position))
                {
                    target = listTargets[i];
                    Debug.Log("set new target");
                }
            }
            else if (listTargets.Count > 0)
            {
                target = listTargets[0];
            }
            else 
            {
                waitingforTarget = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Bullet")
        {
            listTargets.Add(other.transform);
            waitingforTarget = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Bullet")
        {
            listTargets.Remove(other.transform);
        }
        if(other == target)
        {
            setNewTarget();
            listTargets.Remove(other.transform);
        }
    }
}
