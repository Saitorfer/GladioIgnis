using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerStay(Collider other)

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<HealthPlayer>().TakeDamage(damage);
            Debug.Log("from " + transform.name);
        }
        catch { }
        
    }
}
