using UnityEngine;
using UnityEngine.Audio;

namespace Sounds
{
    public class AudioSettings: MonoBehaviour
    {
        [Tooltip("Audio master of the scene.")]
        public AudioMixer master;

        private AudioMixerGroup _music;
        private AudioMixerGroup _dialogue;
        private AudioMixerGroup _character;
        private AudioMixerGroup _ambient;
        private AudioMixerGroup _effects;


        private void Start()
        {
            _music = master.FindMatchingGroups("Music")[0];
            _dialogue = master.FindMatchingGroups("Dialogue")[0];
            _character = master.FindMatchingGroups("Character")[0];
            _ambient = master.FindMatchingGroups("Ambient")[0];
            _effects = master.FindMatchingGroups("Effects")[0];
        }

        public void ChangeMaster(float value)
        {
            master.SetFloat("MasterVolume", value);
        }
        
        public void ChangeMusic(float value)
        {
            _music.audioMixer.SetFloat("MusicVolume", value);
        }
        
        public void ChangeDialogue(float value)
        {
            _dialogue.audioMixer.SetFloat("DialogueVolume", value);
        }
        public void ChangeCharacter(float value)
        {
            _character.audioMixer.SetFloat("CharacterVolume", value);
        }
        public void ChangeAmbient(float value)
        {
            _ambient.audioMixer.SetFloat("AmbientVolume", value);
        }
        public void ChangeEffects(float value)
        {
            _effects.audioMixer.SetFloat("EffectsVolume", value);
        }
    }
}