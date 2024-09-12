using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField] protected Image bar;
    protected int health;
    protected int healthMax = 100;
    protected int damage = 5;
    [SerializeField] protected float cofOfUnit = 1;
    [SerializeField] protected bool isCorrectlyConfig = true;

    public Unit()
    {
        health = healthMax;
    }

    private void LateUpdate()
    {
        if (!isCorrectlyConfig) return;
        bar.fillAmount = (float)health / healthMax;
    }

    public void SetPlayerHealth(int health) => this.health = this.health + health;
    public void SetPlayerHealthMax(int healthMax) => this.healthMax = healthMax;
    public int GetDamage()
    {
        return damage;
    }

    public void LevelUp(int currentLvl)
    {
        for (int i = 0; i < currentLvl; i++)
        {
            healthMax = (int)(healthMax + 100 * cofOfUnit);
            damage = (int)(damage + 10 * cofOfUnit);
        }
        Debug.Log(healthMax);
    }
}
