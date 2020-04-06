using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sounds.Manager
{
    public class ObjectManager : MonoBehaviour, ISoundManager
    {
        [Header("Movement Axis")] 
        public bool xIsActive;
        public bool yIsActive;
        public bool zIsActive;
        
        [Tooltip("The minimal velocity to play movement sound.")]
        public float minVelocity = 0.1f;

        
        [Header("Audio Clips")]
        [Tooltip("Sound that is played when this object moves.")]
        public AudioClip movementClip;
        [Tooltip("Sound that is played when this object hits something.")]
        public AudioClip collisionClip;
        
        private DoubleAudioSource _movementSource;
        private DoubleAudioSource _collisionSource;
        private List<DoubleAudioSource> _audioSources;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _movementSource = gameObject.AddComponent<DoubleAudioSource>();
            _collisionSource = gameObject.AddComponent<DoubleAudioSource>();

            _audioSources = new List<DoubleAudioSource> {_movementSource, _collisionSource};

            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.magnitude > 0.1f)
            {
                OnMovement();
            }
        }

        public void Pause()
        {
            foreach (DoubleAudioSource source in _audioSources)
            {
                source.Pause();
            }
        }

        public void Continue()
        {
            foreach (DoubleAudioSource source in _audioSources)
            {
                source.UnPause();
            }
        }

        public void OnCollisionEnter(Collision other)
        {
            _collisionSource.CrossFadeToNewClip(collisionClip);
        }

        private void OnMovement()
        {
            if (!(movementClip == null)) //maybe a object doesn't make sound while moving
            {
                _movementSource.CrossFadeToNewClip(movementClip);
            }
            throw new NotImplementedException();
        }
    }
}