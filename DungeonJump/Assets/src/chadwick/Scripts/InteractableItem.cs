/*
* Filename: InteractableItem.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the adapter interface implementation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: The InteractableItem item interface which acts as a generic abstraction for any interactable item
*
* Member Variables:
* none
*/
public interface InteractableItem
{
    public void Pickup(Collider2D other);
}
