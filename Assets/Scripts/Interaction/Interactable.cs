using UnityEngine;

namespace Interaction
{
    /// <summary>
    /// <list type="number">
    /// <listheader><description>This is the base class for all Interactable objects. To create an interactable behavior, follow these steps:</description></listheader>
    /// <item><description>Create a new class "&lt;name&gt; : Interactable"</description></item>
    /// <item><description>Override the virtual methods to implement custom behavior</description></item>
    /// <item><description>Add the "Interactable"-Tag to the game object</description></item>
    /// </list>
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        public string displayText;
        public string displaySubtext;
        public bool ignoreTagCheck = false;

        private void Start()
        {
            if (!gameObject.CompareTag("Interactable") && !ignoreTagCheck)
            {
                Logger.logWarning("Interactable " + gameObject.name +
                                  " has no Tag 'Interactable'. This might lead to functionality problems.");
            }
        }

        public abstract void Interact(Interactor interactor);
    }
}