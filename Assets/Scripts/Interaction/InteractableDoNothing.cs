using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/DoNothing")]
    public class InteractableDoNothing : Interactable
    {
        public override void Interact(Interactor interactor)
        {
        }
    }
}