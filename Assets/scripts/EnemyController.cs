using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combatManager;

    public Animator animator;
    float rotationSpeed = 30;
    Vector3 inputVec;
    Vector3 targetDirection;
    public LayerMask interactionMask;
    public enum Warrior { Karate, Ninja, Brute, Sorceress, Knight, Mage, Archer, TwoHanded, Swordsman, Spearman, Hammer, Crossbow };
    public Warrior warrior;

    float attackTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combatManager = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            float distance = Vector3.Distance(target.position, transform.position);
            float z = transform.position.z;
            float x = transform.position.x;
            //Debug.Log("Esta es mi z: " + z);
            inputVec = new Vector3(x, 0, z);
            //Apply inputs to animator
            animator.SetFloat("Input X", z);
            animator.SetFloat("Input Z", -(x));

            if (distance <= lookRadius)
            {
                animator.SetBool("Moving", true);
                agent.SetDestination(target.position);


                if (distance <= agent.stoppingDistance)
                {
                    animator.SetBool("Moving", false);
                    animator.SetTrigger("Attack1Trigger");
                    StartCoroutine(COStunPause(150000f));

                }
            }else
            {
                animator.SetBool("Moving", false);
            }
            /*if (x != 0 || z != 0)  //if there is some input
            {
                //set that character is moving
                animator.SetBool("Moving", true);
            }
            else
            {
                //character is not moving
                animator.SetBool("Moving", false);
            }*/
            attackTimer -= Time.deltaTime;
            UpdateMovement();
        }
        catch (Exception e)
        {

        }
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
        FaceTarget();
        //RotateTowardMovementDirection();
    }


    void FaceTarget()
    {
        //este metodo es para mejorar la rotation del enemigo
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
