using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy1;
    public Transform fastEnemy;
    public float delay = 4;
    public float startDelay = 10;
	// Use this for initialization
	void Start () 
    {
        Invoke("createEnemy", startDelay);
	}

    void createEnemy() 
    {
        int temp = Random.Range(0,2);
        if (temp == 0)
        {
            Instantiate(enemy1, transform.position, transform.rotation);
        }
        else 
        {
            Instantiate(fastEnemy, transform.position, transform.rotation);
        }
        
        Invoke("createEnemy", delay);
    }

}
