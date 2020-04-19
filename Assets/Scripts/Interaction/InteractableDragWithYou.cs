using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Interaction/Interactable/DragWithYou")]
    public class InteractableDragWithYou : Interactable
    {
        private Transform _originalHolder;
        private Rigidbody _rigidbody;
        private bool _isAttached = false;
        private bool _oldKinematic;

        private void Start()
        {
            _originalHolder = transform.parent;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Interact(Interactor interactor)
        {
            if (!_isAttached)
            {
                _oldKinematic = _rigidbody.isKinematic;
                _rigidbody.isKinematic = true;
                transform.parent = interactor.transform;
                _isAttached = true;
            }
            else
            {
                _rigidbody.isKinematic = _oldKinematic;
                transform.parent = _originalHolder;
                _isAttached = false;
            }
        }
    }
}