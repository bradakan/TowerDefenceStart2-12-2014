using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewEnemy : MonoBehaviour {

    public GameObject turret;
    public Transform endPoint;
    public float health;
    public float speed;
    private bool isSlowed = false;
    private bool isStunned = false;
    NavMeshAgent agent;
    GameObject[] towers;
    // Use this for initialization
    void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("End").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(endPoint.position);
        agent.speed = speed;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Debug.Log("life--");
            destroyMe();
        }
        if (other.tag == "Bullet")
        {
            
            NewTurret.waitingforTarget = false;
            if(other.GetComponent<BulletController>().stun == true && isStunned == false)
            {
                stunMe();
            }
            if(other.GetComponent<BulletController>().slow > 0 && isSlowed == false)
            {
                slowMe(other.GetComponent<BulletController>().slow);
            }
            takeDamage(other.GetComponent<BulletController>().damage);
            other.GetComponent<BulletController>().destroyThis();
            //Destroy(this.gameObject);
        }
    }
    public void takeDamage(float damage) 
    {
        
        health -= damage;
        if (health < 0)
        {
            destroyMe();
        }
    }

    public void slowMe(float slow) 
    {
        float newSpeed = (100 - slow)/100;
        agent.speed *= newSpeed;
        isSlowed = true;
        Invoke("setSpeedToNormal",5);
    }

    private void setSpeedToNormal() 
    {
        isSlowed = false;
        agent.speed = speed;
    }
    private void stunMe() 
    {
        agent.speed = 0;
        rigidbody.velocity = new Vector3(0, 0, 0);
        isStunned = true;
        Invoke("setStunToNormal", 5);
    }
    private void setStunToNormal()
    {
        isStunned = false;
        agent.speed = speed;
    }

    private void destroyMe()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject tower in towers)
        {
            tower.GetComponent<NewTurret>().listTargets.Remove(this.transform);
        }
        Destroy(this.gameObject);
    }
}
