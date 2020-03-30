using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Sounds.Manager
{
    /// <summary>
    /// This collects all triggers to play sounds for one character.
    /// </summary>
    public class CharacterSounds : MonoBehaviour, ISoundManager
    {
        private const string FoleyPath = "Assets/Sounds/Foleys/";
        
        [Header("Sound Clips")]
        [Tooltip("This sound is played when the character receives damage.")]
        public AudioClip damage;

        [Tooltip("Sound of walking in snow.")]
        public AudioClip walkSnow;
        
        [Tooltip("Sound of walking on stones.")]
        public AudioClip walkStone;
        
        private AudioSource _voiceSources;
        private AudioSource _movementSources;
        private List<AudioSource> _audioSources;

        private void Start()
        {
            if (damage == null) {}

            {
                damage = AssetDatabase.LoadAssetAtPath<AudioClip>($"{FoleyPath}404109__deathscyp__damage-1.wav");
            }
            if (walkSnow == null)
            {
                walkSnow = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/215690__musicbrain__walking-in-snow-1.wav");
            }
            if (walkStone == null)
            {
                walkStone = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/208103__phil25__stone-steps.wav");
            }
            
            
            _voiceSources = gameObject.AddComponent<AudioSource>();
            _movementSources = gameObject.AddComponent<AudioSource>();

            _audioSources = new List<AudioSource> {_movementSources, _voiceSources};
        }

        /// <summary>
        /// Pauses all sounds.
        /// </summary>
        public void Pause()
        {
            _audioSources.ForEach(source => source.Pause());
        }

        /// <summary>
        /// Continue all sounds from where they stopped.
        /// </summary>
        public void Continue()
        {
            _audioSources.ForEach(source => source.UnPause());
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
        public void Walking(string groundType)
        {
            switch (groundType)
            {
                case "Stone":
                    PlaySound(_movementSources, walkStone);
                    break;
                
                case "Snow":
                    PlaySound(_movementSources, walkSnow);
                    break;
                
                default:
                    PlaySound(_movementSources, walkSnow);
                    break;
            }   
        }

        /// <summary>
        /// Plays a sound clip at a given source.
        /// </summary>
        /// <param name="source">Which player to use.</param>
        /// <param name="clip">Which clip to play.</param>
        protected virtual void PlaySound(AudioSource source, AudioClip clip)
        {
            if (!source.isPlaying || source.clip != clip)
            {
                source.clip = clip;
                source.loop = true;
                source.Play();
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