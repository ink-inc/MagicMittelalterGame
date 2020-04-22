using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("Interaction/Interactable/DragWithYou")]
    public class InteractableDragWithYou : Interactable
    {
        private Transform _originalHolder;
        private Rigidbody _rigidbody;
        private Collider _collider;
        private bool _isAttached = false;
        private bool _oldKinematic;
        private bool _oldGravity;
        private bool _oldTrigger;
        private readonly List<Collider> _colliderList = new List<Collider>();

        private void Start()
        {
            _originalHolder = transform.parent;
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();

            displaySubtext = "[E] Take it with you";
        }

        public override void Interact(Interactor interactor)
        {
            if (!_isAttached)
            {
                pickup(interactor.transform.GetChild(0));
            }
            else
            {
                drop();
            }
        }

        private void pickup(Transform newParent)
        {
            _oldKinematic = _rigidbody.isKinematic;
            _oldGravity = _rigidbody.useGravity;
            _oldTrigger = _collider.isTrigger;
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = true;
            _collider.isTrigger = true;

            transform.parent = newParent;
            _isAttached = true;

            displaySubtext = "[E] Drop";
        }

        private void drop()
        {
            _rigidbody.isKinematic = _oldKinematic;
            _rigidbody.useGravity = _oldGravity;
            _collider.isTrigger = _oldTrigger;

            transform.parent = _originalHolder;
            _isAttached = false;

            displaySubtext = "[E] Take it with you";
        }

        private void OnTriggerEnter(Collider other)
        {
            // this checks if the collider is a collider, that the rigidbody was already in touch with while lying around.
            // that is to prevent pick-ups to drop again in an instance after getting picked up
            if (!other.gameObject.CompareTag("SoundArea") && !CheckIfColliderIsInColliderList(other))
            {
                drop();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            _colliderList.Add(collision.collider);
        }

        private void OnCollisionExit(Collision collision)
        {
            _colliderList.Remove(collision.collider);
        }

        private bool CheckIfColliderIsInColliderList(Collider other)
        {
            return _colliderList.Contains(other);
        }
    }
}