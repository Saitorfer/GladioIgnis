using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public float max_health = 500f;
    public float cur_health = 0;
    public bool alive = true;
    public Canvas game;
    public Text health;
    public float totalDamage;

    void Start()
    {
        cur_health = 100f;
        health.text = "Health: " + cur_health;
    }

    void Update()
    {
    }
    public void TakeDamage(float damage)
    {
        cur_health -= damage;
        health.text = "Health: " + cur_health;
        //valor of damage taken in punctuation
        totalDamage += damage;
        Punctuation.Da = totalDamage;
        Debug.Log(transform.name + " take " + damage + " damage ");

        if (cur_health <= 0)
        {
            cur_health = 0;
            health.text = "Health: " + cur_health;
            alive = false;
            
        }
        
        if (!alive)
        {
            Die();
        }
    }

    public void TakeHeal(float heal)
    {
        Debug.Log(transform.name + " take " + heal + " heal ");
        cur_health += heal;
        health.text = "Health: " + cur_health;

        if (cur_health >= 500)
        {
            cur_health = 500;
            health.text = "Health: " + cur_health;
        }
        
    }
    public void Die()
    {
        Debug.Log(transform.name + "Die");
        SceneManager.LoadScene("FinalPunctuation");
    }
    public void DoDamage()
    {
        TakeDamage(10);
    }

}
