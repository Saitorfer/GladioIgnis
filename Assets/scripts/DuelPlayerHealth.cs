using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuelPlayerHealth : MonoBehaviour
{
    public float max_health = 200f;
    public float cur_health = 0;
    public bool alive = true;
    public GameObject healtBar;
    public string winner;
    float seconds;
    float timer = 0.0f;
    void Start()
    {
        cur_health = max_health;

    }
    
    void Update()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
    }
    public void TakeDamage(float damage)
    {
        cur_health -= damage;
        DuelPunctuation.Dam += damage;
        Debug.Log(transform.name + " take " + damage + " damage ");
        if (cur_health <= 0)
        {
            cur_health = 0;
            alive = false;
        }

        SetHealthBar();

        if (!alive)
        {
            Die();
            DuelPunctuation.Time = seconds;
            if(transform.name != "Player1")
            {
                DuelPunctuation.Win = "Player 1 (Attacker)";
            }
            else
            {
                DuelPunctuation.Win = "Player 2 (Defender)";
            }

            SceneManager.LoadScene("DuelPunctuation");
        }
    }
    public void SetHealthBar()
    {
        float calc_Health = cur_health / max_health;
        healtBar.transform.localScale = new Vector3(calc_Health, healtBar.transform.localScale.y, healtBar.transform.localScale.z);
    }
    public void Die()
    {
        Debug.Log(transform.name + "Die");
        Destroy(gameObject);
    }
    public static int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
    public void DoDamage()
    {
        TakeDamage(10);
    }
}
