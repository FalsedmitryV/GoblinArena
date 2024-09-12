using System.Collections;
using UnityEngine;

public class TurtleShell : Enemy
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject _target;
    private GameObject _target2;
    [SerializeField] private float _dist;

    TurtleShell()
    {
        healthMax = 120;
        health = healthMax;
        damage = 10;
        cofOfUnit = 0.2f;
    }

    private void Awake()
    {
        FindEnemyRespawner();
        GameObject waveManager = GameObject.Find("WaveManager");
        LevelUp(waveManager.GetComponent<WaveManager>().GetCurrentLvl());
        health = healthMax;
    }

    void Update()
    {
        _target2 = _target.GetComponent<EnemyMove>().GetTarget();
        _dist = Vector3.Distance(gameObject.transform.position, _target2.transform.position);

        if (_dist < 3) anim.SetBool("IsAttack", true);
        else anim.SetBool("IsAttack", false);

        if (health < 0) StartCoroutine(DieDelay());
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

        EnemyGeneratot.GetComponent<EnemyGenerator>().RespawnEnemy();
        Destroy(target);
        Debug.Log("Turtle die " + healthMax + " " + damage);
    }

    private IEnumerator DieDelay()
    {
        anim.SetBool("IsDie", true);
        _target.GetComponent<EnemyMove>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(3.0f);

        Die(_target);
    }
}
