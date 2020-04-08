using UnityEngine;
using UnityEngine.Audio;

namespace Sounds
{
    /// <summary>
    /// Handles all audio settings.
    /// </summary>
    public class AudioSettings: MonoBehaviour
    {
        [Tooltip("Audio master of the scene.")]
        public AudioMixer master;

        private AudioMixerGroup _music;
        private AudioMixerGroup _dialogue;
        private AudioMixerGroup _character;
        private AudioMixerGroup _ambient;
        private AudioMixerGroup _effects;


        private void Awake()
        {
            _music = master.FindMatchingGroups("Music")[0];
            _dialogue = master.FindMatchingGroups("Dialogue")[0];
            _character = master.FindMatchingGroups("Character")[0];
            _ambient = master.FindMatchingGroups("Ambient")[0];
            _effects = master.FindMatchingGroups("Effects")[0];
        }

        /// <summary>
        /// Changes the master volume.
        /// </summary>
        /// <param name="value">The volume to change too. Must be in [-80, 20]</param>
        public void ChangeMaster(float value)
        {
            master.SetFloat("MasterVolume", value);
        }
        /// <summary>
        /// Changes the music volume.
        /// </summary>
        /// <param name="value">The volume to change too. Must be in [-80, 20]</param>
        public void ChangeMusic(float value)
        {
            if (_music != null) _music.audioMixer.SetFloat("MusicVolume", value);
        }
        /// <summary>
        /// Changes the dialogue volume.
        /// </summary>
        /// <param name="value">The volume to change too. Must be in [-80, 20]</param>
        public void ChangeDialogue(float value)
        {
            if (_dialogue != null) _dialogue.audioMixer.SetFloat("DialogueVolume", value);
        }
        /// <summary>
        /// Changes the character volume.
        /// </summary>
        /// <param name="value">The volume to change too. Must be in [-80, 20]</param>
        public void ChangeCharacter(float value)
        {
            if (_character != null) _character.audioMixer.SetFloat("CharacterVolume", value);
        }
        /// <summary>
        /// Changes the ambient volume.
        /// </summary>
        /// <param name="value">The volume to change too. Must be in [-80, 20]</param>
        public void ChangeAmbient(float value)
        {
            if (_ambient != null) _ambient.audioMixer.SetFloat("AmbientVolume", value);
        }
        /// <summary>
        /// Changes the effects volume.
        /// </summary>
        /// <param name="value">The volume to change too. Must be in [-80, 20]</param>
        public void ChangeEffects(float value)
        {
            if (_effects != null) _effects.audioMixer.SetFloat("EffectsVolume", value);
        }
    }
}