using System;
using UnityEditor;
using UnityEngine;

namespace Sounds.Manager
{
    /// <summary>
    /// This collects all triggers to play sounds for one character.
    /// </summary>
    public class CharacterSounds : MonoBehaviour
    {
        private const string FoleyPath = "Assets/Sounds/Foleys/";

        [Tooltip("This sound is played when the character receives damage.")]
        public AudioClip damage;

        [Tooltip("Sound of walking on stones.")]
        public AudioClip walkStone;
        
        private AudioSource _voiceSources;
        private AudioSource _movementSources;

        private void Start()
        {
            if (damage == null) {}

            {
                damage = AssetDatabase.LoadAssetAtPath<AudioClip>($"{FoleyPath}404109__deathscyp__damage-1.wav");
                walkStone = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/208103__phil25__stone-steps.wav");
            }
            _voiceSources = gameObject.AddComponent<AudioSource>();
            _movementSources = gameObject.AddComponent<AudioSource>();
        }

        /// <summary>
        /// Plays the damage sound for the character.
        /// </summary>
        public void Damage()
        {
            _voiceSources.clip = damage;
            _voiceSources.Play();
        }

        /// <summary>
        /// Plays walking sound for a given ground type.
        /// </summary>
        /// <param name="groundType">The type of ground the character is currently walking on.</param>
        public void Walking(String groundType)
        {
            switch (groundType)
            {
                case "Stone":
                    _movementSources.clip = walkStone;
                    _movementSources.loop = true;
                    _movementSources.Play();
                    break;
                
                default:
                    _movementSources.clip = walkStone;
                    _movementSources.loop = true;
                    _movementSources.Play();
                    break;
            }   
        }

        /// <summary>
        /// Stops all sound regarding movement.
        /// </summary>
        public void StopMovement()
        {
            _movementSources.Stop();
        }
    }
}