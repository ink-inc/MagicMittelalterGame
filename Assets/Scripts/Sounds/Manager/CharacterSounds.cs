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
        
        private AudioSource _voiceSources;

        private void Start()
        {
            if (damage == null) {}

            {
                damage = AssetDatabase.LoadAssetAtPath<AudioClip>($"{FoleyPath}404109__deathscyp__damage-1.wav");
            }
            _voiceSources = gameObject.AddComponent<AudioSource>();
        }

        /// <summary>
        /// Plays the damage sound for the character.
        /// </summary>
        public void Damage()
        {
            _voiceSources.clip = damage;
            _voiceSources.Play();
        }
    }
}