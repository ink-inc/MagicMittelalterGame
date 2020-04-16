using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/PushUp")]
    public class InteractablePushUp : Interactable
    {
        public float force = 5f;
        public new Rigidbody rigidbody;

        private void Start()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
                Logger.logWarning("Interactable rigidbody is missing and has been automatically assigned. Please assign it manually.");
            }
        }

        public override void Interact(Interactor interactor)
        {
            rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}