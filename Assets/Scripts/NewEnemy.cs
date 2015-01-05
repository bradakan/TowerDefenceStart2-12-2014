using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewEnemy : MonoBehaviour {

    public GameObject turret;
    public Transform endPoint;
    public float health;
    NavMeshAgent agent;
    GameObject[] towers;
    // Use this for initialization
    void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("End").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(endPoint.position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {

            NewTurret.waitingforTarget = false;
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
            towers = GameObject.FindGameObjectsWithTag("Tower");
            foreach(GameObject placeholder in towers)
            {
                placeholder.GetComponent<NewTurret>().listTargets.Remove(this.transform);
            }
            Destroy(this.gameObject);
        }
    }
}
