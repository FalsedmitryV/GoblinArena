using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Unit
{
    public GameObject[] loot;
    [SerializeField] protected GameObject EnemyGeneratot;

    public Enemy()
    {
        healthMax = 100;
        health = healthMax;
        damage = 1;
    }

    private void Awake()
    {
        FindEnemyRespawner();
    }

    void Update()
    {
        Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "arm" && other.gameObject != null)
        {
            health -= other.gameObject.GetComponent<StatsOfDubina>().damage; 
        }
    }

    protected void Die()
    {
        if (health <= 0)
        {
            foreach (GameObject lootItem in loot)
            {
                if (lootItem.name == "medickit")
                {
                    int chance = Random.Range(0, 100);
                    if (!(chance + 10 >= 90)) continue;
                }
                Random.Range(-2.0f, 2.0f);

                float randomÂeviationX = Random.Range(-2.0f, 2.0f); ;
                float randomÂeviationZ = Random.Range(-2.0f, 2.0f); ;

                Instantiate(lootItem, new Vector3(transform.position.x + randomÂeviationX, 1.55f, transform.position.z + randomÂeviationX), Quaternion.identity);
            }

            EnemyGeneratot.GetComponent<EnemyGenerator>().RespawnEnemy();
            Destroy(gameObject);
        }
    }

    protected void FindEnemyRespawner()
    {
        EnemyGeneratot = GameObject.Find("EnemyRespawner");
    }

}
