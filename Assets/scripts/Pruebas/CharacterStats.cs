
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stats damage;
    public int maxHealth;

    //lo ponemos asi para que cualquier otra clase pueda coger su valor pero solo podemos asignarla desde aqui
    public int health { get; private set; }

    public virtual void Start()
    {

    }

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //este metodo se va a sobreescribir ya que depende de lo que queramos que haga el que muere
        Debug.Log(transform.name + "Die");
    }

    void Update()
    {
        
    }
}
