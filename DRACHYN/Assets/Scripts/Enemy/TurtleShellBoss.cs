using System.Collections;
using UnityEngine;

public class TurtleShellBoss : Enemy
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject _target;
    private GameObject _target2;
    [SerializeField] private float _dist;

    TurtleShellBoss()
    {
        healthMax = 200;
        health = healthMax;
        damage = 20;
        cofOfUnit = 0.2f;
    }

    private void Awake()
    {
        health = healthMax;
    }

    void Update()
    {
        _target2 = _target.GetComponent<EnemyMove>().GetTarget();
        _dist = Vector3.Distance(gameObject.transform.position, _target2.transform.position);

        if (health <= 0) StartCoroutine(DieDelay());
    }

    protected void Die(GameObject target)
    {
        foreach (GameObject lootItem in loot)
        {
            if (lootItem.name == "medickit")
            {
                int chance = Random.Range(0, 100);
                if (!(chance + 30 >= 70)) continue;
            }
            Random.Range(-2.0f, 2.0f);

            float randomÂeviationX = Random.Range(-2.0f, 2.0f); ;
            float randomÂeviationZ = Random.Range(-2.0f, 2.0f); ;

            Instantiate(lootItem, new Vector3(transform.position.x + randomÂeviationX, 1.55f, transform.position.z + randomÂeviationX), Quaternion.identity);
        }

        Destroy(target);
        Debug.Log("Boss die3");
    }

    private IEnumerator DieDelay()
    {
        Debug.Log("Boss die1 ");
        _target.GetComponent<EnemyMove>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(3.0f);
        Debug.Log("Boss die2 ");
        Die(_target);
    }
}
