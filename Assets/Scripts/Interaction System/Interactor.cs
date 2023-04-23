using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/* Eugene van den berg
 * Created 23/04/2023
 * Updated 23/04/2023
*/

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactRadius = 05f;
    [SerializeField] private LayerMask interactionMask;

    private readonly Collider colliders;

    public void OnInteraction(InputAction.CallbackContext context)
    {
        var interactable = colliders.GetComponent<Interactable>();
        interactable?.Interact(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactRadius);
    }
}
