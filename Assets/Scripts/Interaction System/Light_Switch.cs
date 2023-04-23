using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Switch : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;

    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Switching the light switch");
        //Enter The Light Switch Script
        return true;
    }
}
