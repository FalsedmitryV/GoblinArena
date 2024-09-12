using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int countHealing = 10;

    public GameObject Player;

    private void Awake()
    {
        Player = GameObject.Find("GoblinBody");
    }

    public void HPGetting()
    {
        Player.GetComponent<HPPlayer>().SetPlayerHealth(countHealing);
        Destroy(gameObject);
    }

}
