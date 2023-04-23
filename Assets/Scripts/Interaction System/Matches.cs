using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matches : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("picked up matches");
        //Run pick up script
        return true;
    }
}
