using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 10f;
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
            other.gameObject.GetComponent<HealthEnemy>().TakeDamage(damage);
            Debug.Log("from " + transform.name);
        }
        catch { }
        

    }
}
