using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public float max_health = 20f;
    public float cur_health = 0;
    public bool alive = true;
    public GameObject healtBar;
    Rounds round;
    public GameObject cont;
    public GameObject potion;
    void Start()
    {
        cur_health = max_health;

    }
    void Update()
    {
        //Debug.Log(GetRandomNumber(0, 6));
    }
    public void TakeDamage(float damage)
    {
        cur_health -= damage;
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
        //COjo un numero aleatorio y cuando toque el correcto espawnea una potion de vida
        int prob = 0;
        prob = GetRandomNumber(0, 6);

        if(prob==3)
        {
            Instantiate(potion,transform.position+new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z), potion.transform.rotation);
        }

        Destroy(gameObject);
        //round.cont--;
        cont.gameObject.GetComponent<Rounds>().cont--;
        cont.gameObject.GetComponent<Rounds>().contKills++;
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
