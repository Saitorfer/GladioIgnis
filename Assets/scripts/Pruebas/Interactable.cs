using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    
    public Transform interactionTransform;
    void Update()
    {
        
        float distance = Vector3.Distance(player.position,player.position);
        if (distance <= radius)
        {
            //interaction
            hasInteracted = true;
            Interact();
        }
        
    }
    
    public virtual void Interact()
    {
        //es virtual porque va a cambiar segun el personaje que lo utilize (override)
    }
    public void onFocused(Transform playerTransform)
    {
        //si el enemigo hace cosas raras despues de ser atacado, mira este metodo
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void onDeFocused()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
