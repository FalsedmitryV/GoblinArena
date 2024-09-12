using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public Image bar;
    [SerializeField] private TMP_Text textCurrentLVL;
    [SerializeField] private TMP_Text textNextLVL;
    [SerializeField] private int currentEXP = 0;
    [SerializeField] private int maxEXP = 100;
    [SerializeField] private int currentLVL = 1;
    [SerializeField] protected bool isCorrectlyConfig = false;
    [SerializeField] private GameObject _enemyGenerator;
    private GameObject[] enemisOnWave;

    private void Awake()
    {
        if (bar.type == Image.Type.Filled && bar.fillMethod == Image.FillMethod.Horizontal)
        {
            isCorrectlyConfig = true;
        }
        else
        {
            Debug.Log("{GameLog} => [ProgressBarController] - (<color=red>Error</color>) -> Components Parameters Are Incorrectly Configured \n " +
                      "Required Type: Filled \n" +
                      "Required FillMethod: Horizontal");
        }

        textCurrentLVL.text = currentLVL.ToString();
        textNextLVL.text = (currentLVL + 1).ToString();

        _enemyGenerator = GameObject.Find("EnemyRespawner");
    }

    private void LateUpdate()
    {
        if (!isCorrectlyConfig) return;
        
        bar.fillAmount = (float) currentEXP / maxEXP;

        if (currentEXP >= maxEXP) LevelUp();

        enemisOnWave = GameObject.FindGameObjectsWithTag("enemyM");
    }

    public void SetPlayerHealth(int currentEXP) => this.currentEXP = currentEXP;
    public void SetPlayerHealthMax(int maxEXP) => this.maxEXP = maxEXP;

    public void SetCurrentEXP(int EXP)
    {
        currentEXP += EXP;
    }

    private void LevelUp()
    {
        currentEXP = maxEXP - currentEXP;
        currentLVL++;

        maxEXP += 50;
        textCurrentLVL.text = currentLVL.ToString();
        textNextLVL.text = (currentLVL + 1).ToString(); 
        
        if(currentLVL % 5 == 0 )
        {
            _enemyGenerator.GetComponent<EnemyGenerator>().SpawnBoss();
        }
    }

    public int GetCurrentLvl()
    {
        return currentLVL;
    }
}
