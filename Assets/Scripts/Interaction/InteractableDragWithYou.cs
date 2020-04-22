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

        private List<Collider> _colliderList = new List<Collider>();

        private void Start()
        {
            _originalHolder = transform.parent;
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public override void Interact(Interactor interactor)
        {
            if (!_isAttached)
            {
                _oldKinematic = _rigidbody.isKinematic;
                _rigidbody.isKinematic = true;
                _collider.isTrigger = true;

                transform.parent = interactor.transform.GetChild(0);
                _isAttached = true;

                this.displaySubtext = "[E] Drop";
            }
            else
            {
                _rigidbody.isKinematic = _oldKinematic;
                _collider.isTrigger = false;

                transform.parent = _originalHolder;
                _isAttached = false;

                this.displaySubtext = "[E] Take it with you";
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // this checks if the collider is a collider, that the rigidbody was already in touch with while lying around.
            // that is to prevent pick-ups to drop again in an instance after getting picked up
            if(!CheckIfColliderisInColliderList(other)) { 
                _rigidbody.isKinematic = _oldKinematic;
                _collider.isTrigger = false;

                transform.parent = _originalHolder;
                _isAttached = false;

                this.displaySubtext = "[E] Take it with you";
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

        private bool CheckIfColliderisInColliderList(Collider other)
        {
            foreach(Collider collider in _colliderList)
            {
                if (collider == other)
                {
                    return true;
                }
            }
            return false;
        }
    }
}