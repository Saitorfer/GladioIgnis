using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHeal : MonoBehaviour
{
    public float heal = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,Time.deltaTime*25));
    }
    private void OnTriggerEnter(Collider other)
    {

        try
        {
            other.gameObject.GetComponent<HealthPlayer>().TakeHeal(heal);
            Debug.Log("from " + transform.name);
            Die();
        }
        catch (Exception e)
        {

        }
    }
    public void Die()
    {
        Debug.Log(transform.name + "was used");
        Destroy(gameObject);
    }


}
