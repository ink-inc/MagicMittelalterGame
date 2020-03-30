using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;

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

        [Tooltip("Sound of running on stone.")]
        public AudioClip runningStone;

        [Tooltip("Sound of sneaking on stone.")]
        public AudioClip sneakingStone;
        
        [Tooltip("Sound of walking in snow.")]
        public AudioClip walkSnow;
        
        [Tooltip("Sound of walking on stones.")]
        public AudioClip walkStone;
        
        [Header("Audio Sources")]
        private DoubleAudioSource _voiceSources;
        private DoubleAudioSource _movementSources;
        private List<DoubleAudioSource> _audioSources;

        [Header("Audio Mixer")]
        private AudioMixer _audioMixer;

        private void Start()
        {
            if (damage == null) {}

            {
                damage = AssetDatabase.LoadAssetAtPath<AudioClip>($"{FoleyPath}404109__deathscyp__damage-1.wav");
            }
            if (runningStone == null)
            {
                runningStone = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/430708__juandamb__running.wav");
            }

            if (sneakingStone == null)
            {
                sneakingStone = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/260120__splicesound__01-20-footsteps-tile-slippers-slow-pace.wav");
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
            
            
            _voiceSources = gameObject.AddComponent<DoubleAudioSource>();
            _movementSources = gameObject.AddComponent<DoubleAudioSource>();

            _audioSources = new List<DoubleAudioSource> {_movementSources, _voiceSources};
            
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
            PlaySound(_voiceSources, damage);
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
        /// Plays running sounds for a given ground type.
        /// </summary>
        /// <param name="groundType">The type of ground the character is currently running on.</param>
        public void Running(string groundType)
        {
            switch (groundType)
            {
                case "Stone":
                    PlaySound(_movementSources, runningStone);
                    break;
                default:
                    PlaySound(_movementSources, runningStone);
                    break;
            }
        }
        /// <summary>
        /// Plays sneaking sounds for a given ground type.
        /// </summary>
        /// <param name="groundType">The type of ground the character is currently sneaking on.</param>
        public void Sneaking(string groundType)
        {
            switch (groundType)
            {
                case "Stone":
                    PlaySound(_movementSources, sneakingStone);
                    break;
                default:
                    PlaySound(_movementSources, sneakingStone);
                    break;
            }
        }

        /// <summary>
        /// Plays a sound clip at a given source.
        /// </summary>
        /// <param name="source">Which player to use.</param>
        /// <param name="clip">Which clip to play.</param>
        protected virtual void PlaySound(DoubleAudioSource source, AudioClip clip)
        {
            if (!source.IsPlaying || source.Clip != clip)
            {
                source.CrossFadeToNewClip(clip);
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