using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

        public AudioMixerGroup mixerGroup;
        
        private DoubleAudioSource _movementSource;
        private DoubleAudioSource _collisionSource;
        private List<DoubleAudioSource> _audioSources;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _movementSource = gameObject.AddComponent<DoubleAudioSource>();
            _collisionSource = gameObject.AddComponent<DoubleAudioSource>();

            _movementSource.IsLoop = true;
            _movementSource.MixerGroup = mixerGroup;

            _collisionSource.MixerGroup = mixerGroup;

            _audioSources = new List<DoubleAudioSource> {_movementSource, _collisionSource};

            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 velocity = _rigidbody.velocity;
            if (Math.Abs(velocity.x) > minVelocity && xIsActive)
            {
                OnMovement();
            }
            else if (Math.Abs(velocity.y) > minVelocity && yIsActive)
            {
                OnMovement();
            }
            else if (Math.Abs(velocity.z) > minVelocity && zIsActive)
            {
                OnMovement();
            }
            else
            {
                _movementSource.Stop();
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
            _collisionSource.MixerGroup = mixerGroup;
            _collisionSource.CrossFadeToNewClip(collisionClip);
        }

        private void OnMovement()
        {
            if (movementClip == null || _movementSource.IsPlaying) return;
            _movementSource.MixerGroup = mixerGroup;
            _movementSource.CrossFadeToNewClip(movementClip, fadeDuration: 0.1f);
        }
    }
}