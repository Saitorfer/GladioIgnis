using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    float rotationSpeed = 30;
    Vector3 inputVec;
    Vector3 targetDirection;
    public LayerMask interactionMask;
    public enum Warrior { Karate, Ninja, Brute, Sorceress, Knight, Mage, Archer, TwoHanded, Swordsman, Spearman, Hammer, Crossbow };
    public Warrior warrior;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.localScale.z;
        float x = -transform.localScale.x;
        inputVec = new Vector3(x, 0, z);
        //Apply inputs to animator
        animator.SetFloat("Input X", z);
        animator.SetFloat("Input Z", -(x));

        if (x != 0 || z != 0)  //if there is some input
        {
            //set that character is moving
            animator.SetBool("Moving", true);
        }
        else
        {
            //character is not moving
            animator.SetBool("Moving", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack1Trigger");
            if (warrior == Warrior.Brute)
                StartCoroutine(COStunPause(1.2f));
            else if (warrior == Warrior.Sorceress)
                StartCoroutine(COStunPause(1.2f));
            else
                StartCoroutine(COStunPause(.6f));
        }
        UpdateMovement();
    }

    public IEnumerator COStunPause(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
    }

    void RotateTowardMovementDirection()
    {
        if (inputVec != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotationSpeed);
        }
    }

    void UpdateMovement()
    {
        //get movement input from controls
        Vector3 motion = inputVec;

        //reduce input for diagonal movement
        motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? 0.7f : 1;

        RotateTowardMovementDirection();
    }
    
}
