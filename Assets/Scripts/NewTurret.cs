using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewTurret : MonoBehaviour {

    private Transform target;
    public Transform bulletSpawnpoint;
    public bool isSniper = false;
    public Transform Bullet;
    private float cooldown;
    public float cooldownTime = 1;
    public Transform tempBullet;
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
            if(!isSniper)
            {
                bulletSpawnpoint.transform.LookAt(target);
                tempBullet = (Transform)Instantiate(Bullet, bulletSpawnpoint.position, bulletSpawnpoint.transform.rotation);
                tempBullet.GetComponent<BulletController>().target = target;
            }
            else if (isSniper)
            {
                target.GetComponent<NewEnemy>().takeDamage(5f);
            }

        }
        else if (listTargets.Count > 0 && target != null)
        {
            bulletSpawnpoint.transform.LookAt(target);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet")
        {
            listTargets.Add(other.transform);
            waitingforTarget = false;
        }
    }
    void OnTriggerExit(Collider other)
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
    /*
    void OnMouseDown() 
    {
        Debug.Log("test onclick");
    }

    void OnMouseOver() 
    {
        Debug.Log("test MouseOver");
    }
     */
}
