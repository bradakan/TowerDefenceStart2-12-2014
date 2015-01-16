using UnityEngine;
using System.Collections;

public class BuildTower : MonoBehaviour {

    public Transform towerSpawnPoint;
    public Transform sniperTower;
    public Transform rapidFireTower;
    public Transform slowTower;
    private ButtonBehavior UI;

    void Awake()
    {
        UI = GameObject.FindGameObjectWithTag("Buttons").GetComponent<ButtonBehavior>();

    }

    void OnMouseDown()
    {
        UI.changeSetActive();
        UI.target = this.gameObject;
        UI.isUpgrade = false;
        UI.buildTower = true;
    }

    public void spawnTower(string whatTower)
    {
        if(whatTower == "sniper")
        {
            Instantiate(sniperTower, towerSpawnPoint.position, Quaternion.identity);
        }
        if (whatTower == "rapid")
        {
            Instantiate(rapidFireTower, towerSpawnPoint.position, Quaternion.identity);
        }
        if (whatTower == "slow")
        {
            Instantiate(slowTower, towerSpawnPoint.position, Quaternion.identity);
        }


        
    }

}
