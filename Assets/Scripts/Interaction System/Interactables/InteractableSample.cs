using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Eugene van den berg
 * created 23/04/2023
 * updated 23/04/2023
*/

public class InteractableSample : MonoBehaviour, Interactable //<-- When adding this click the light buld icon and select implement
{
    [SerializeField] private string prompt; // <-- Add this line

    //public string interactionPrompt => throw new System.NotImplementedException();
    public string interactionPrompt => prompt; // Then replace the line above the the promt variable

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting");
        throw new System.NotImplementedException();// Add the script you want the item to do
    }
}
// When done making the script add it to the gameObject