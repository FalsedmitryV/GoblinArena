using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPPlayer : Unit
{
    public HPPlayer()
    {
        healthMax = 100;
        damage = 5;
        cofOfUnit = 0.25f;
    }  

    private void Awake()
    {
        if (bar.type == Image.Type.Filled && bar.fillMethod == Image.FillMethod.Horizontal)
        {
            isCorrectlyConfig = true;
            health = healthMax;
        }
        else
        {
            Debug.Log("{GameLog} => [ProgressBarController] - (<color=red>Error</color>) -> Components Parameters Are Incorrectly Configured \n " +
                      "Required Type: Filled \n" +
                      "Required FillMethod: Horizontal");
        }
    }

    private void LateUpdate()
    {
        if (!isCorrectlyConfig) return;
        bar.fillAmount = (float) health / healthMax;
    }

     private void OnCollisionStay(Collision collision)
     {
         if (collision.gameObject.tag == "enemy")
         {
            health -= collision.gameObject.GetComponent<Enemy>().GetDamage();
         }
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "loot")
        {
            other.gameObject.GetComponent<EXP>().EXPGetting();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "heal")
        {
            other.gameObject.GetComponent<Medkit>().HPGetting();
            Destroy(other.gameObject);
        }
    }
}
