/*
* Filename: InteractableItem.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the adapter interface implementation
* Notes: 
***** Justification of use:
* Intent of a bridge is to decouple an abstraction from its implementation (the InteractableItem interface and the PlatformerItem).
* Additionally it is a strong form of encapsulation.
***** Would something else have worked better?
* Not entirely, in example:
* Bridge is designed up-front to let the abstraction and the implementation vary independently.
* Adapter is retrofitted to make unrelated classes work together.
* The structure of the State pattern and Bridge are identical 
* (except that Bridge admits hierarchies of envelope classes, whereas State allows only one).
* the State pattern allows an object's behavior to change along with its state,
* while Bridge's intent is to decouple an abstraction from its implementation so that the two can vary independently.
***** When would be a bad time to use this pattern?
* A bad time to use the bridge pattern is after a structure has already been implemented (an adapter should be used)
* When would something else be better?
* If interface classes delegate the creation of their implementation classes (instead of creating/coupling themselves directly),
* then the design usually uses the Abstract Factory pattern to create the implementation objects.
* Bridge is designed up-front to let the abstraction and the implementation vary independently.
* Adapter is retrofitted to make unrelated classes work together.
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
