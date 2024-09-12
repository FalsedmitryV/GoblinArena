using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lookspeed;
    [SerializeField] private GameObject target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private string _targetName;
    Vector3 targetV;

    public GameObject GetTarget()
    {
        return target;
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find(_targetName);
    }

    void Update()
    {
        agent.speed = speed;
        targetV = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        agent.SetDestination(targetV);
        Quaternion targetRotation = Quaternion.LookRotation(targetV - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookspeed * Time.deltaTime);

    }
}
