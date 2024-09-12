using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    [SerializeField] private int countEXP = 10;

    public GameObject WaveManager;

    private void Awake()
    {
        WaveManager = GameObject.Find("WaveManager");
    }

    public void EXPGetting()
    {
        WaveManager.GetComponent<WaveManager>().SetCurrentEXP(countEXP);
        Destroy(gameObject);
    }

}
