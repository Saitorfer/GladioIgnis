using UnityEngine;
using System.Collections;

public class WarriorAnimationDemoFREE : MonoBehaviour 
{
	public Animator animator;
	float rotationSpeed = 30;
	Vector3 inputVec;
	Vector3 targetDirection;
    public Interactable focus;
    public LayerMask interactionMask;
    //Warrior types
    public enum Warrior{Karate, Ninja, Brute, Sorceress, Knight, Mage, Archer, TwoHanded, Swordsman, Spearman, Hammer, Crossbow};
	public Warrior warrior;
    Camera cam;
    public LayerMask movementMask;

    void Start()
    {
        cam = Camera.main; 
    }
	void Update()
	{
		//Get input from controls
		float z = Input.GetAxisRaw("Horizontal1");
		float x = -(Input.GetAxisRaw("Vertical1"));
		inputVec = new Vector3(x, 0, z);
		//Apply inputs to animator
		animator.SetFloat("Input X", z);
		animator.SetFloat("Input Z", -(x));

		if (x != 0 || z != 0 )  //if there is some input
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
				StartCoroutine (COStunPause(1.2f));
			else if (warrior == Warrior.Sorceress)
				StartCoroutine (COStunPause(1.2f));
			else
				StartCoroutine (COStunPause(.6f));

            Hit();
		}

        // Shoot out a ray
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If we hit
        if (Physics.Raycast(ray, out hit, 100f, interactionMask))
        {
            SetFocus(hit.collider.GetComponent<Interactable>());
        }

        //update character position and facing
        UpdateMovement();
	}

	public IEnumerator COStunPause(float pauseTime)
	{
		yield return new WaitForSeconds(pauseTime);
	}

	//converts control input vectors into camera facing vectors
	void GetCameraRelativeMovement()
	{  
		Transform cameraTransform = Camera.main.transform;

		// Forward vector relative to the camera along the x-z plane   
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;

		// Right vector relative to the camera
		// Always orthogonal to the forward vector
		Vector3 right= new Vector3(forward.z, 0, -forward.x);

		//directional inputs
		float v = Input.GetAxisRaw("Vertical1");
		float h = Input.GetAxisRaw("Horizontal1");

		// Target direction relative to the camera
		targetDirection = h * right + v * forward;
	}

	//face character along input direction
	void RotateTowardMovementDirection()  
	{
		if(inputVec != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotationSpeed);
		}
	}

	void UpdateMovement()
	{
		//get movement input from controls
		Vector3 motion = inputVec;

		//reduce input for diagonal movement
		motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? 0.7f:1;
		
		RotateTowardMovementDirection();  
		GetCameraRelativeMovement();  
	}
    void SetFocus(Interactable newFocus)
    {
        

    }

    //Placeholder functions for Animation events
    void Hit()
	{
        
	}

	void FootR()
	{
	}

	void FootL()
	{
	}

	
}