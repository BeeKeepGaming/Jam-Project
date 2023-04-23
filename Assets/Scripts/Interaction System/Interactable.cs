using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Eugene van den berg
 * created 23/04/2023
 * updated 23/04/2023
*/

public interface Interactable
{
    public string interactionPrompt { get; }

    public bool Interact(Interactor interactor);

}
