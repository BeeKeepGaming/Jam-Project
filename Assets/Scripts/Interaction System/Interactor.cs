using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactRadius = 05f;
    [SerializeField] private LayerMask interactionMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;
    
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactRadius, colliders, interactionMask);

        if(numFound > 0)
        {
            var interactable = colliders[0].GetComponent<Interactable>();
            if(interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactRadius);
    }

}
