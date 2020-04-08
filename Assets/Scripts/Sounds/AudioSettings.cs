using UnityEngine;
using UnityEngine.Audio;

namespace Sounds
{
    public class AudioSettings: MonoBehaviour
    {
        [Tooltip("Audio master of the scene.")]
        public AudioMixer master;
        
        private AudioMixerGroup Music { get; set; }
        private AudioMixerGroup Dialogue { get; set; }
        private AudioMixerGroup Character { get; set; }
        private AudioMixerGroup Ambient { get; set; }
        private AudioMixerGroup Effects { get; set; }

        private void Start()
        {
            Music = master.FindMatchingGroups("Music")[0];
            Dialogue = master.FindMatchingGroups("Dialogue")[0];
            Character = master.FindMatchingGroups("Character")[0];
            Ambient = master.FindMatchingGroups("Ambient")[0];
            Effects = master.FindMatchingGroups("Effects")[0];
        }

        public void ChangeMaster(float value)
        {
            master.SetFloat("MasterVolume", value);
        }
        
        public void ChangeMusic(float value)
        {
            Music.audioMixer.SetFloat("MusicVolume", value);
        }
        
        public void ChangeDialogue(float value)
        {
            Dialogue.audioMixer.SetFloat("DialogueVolume", value);
        }
        public void ChangeCharacter(float value)
        {
            Character.audioMixer.SetFloat("CharacterVolume", value);
        }
        public void ChangeAmbient(float value)
        {
            Ambient.audioMixer.SetFloat("AmbientVolume", value);
        }
        public void ChangeEffects(float value)
        {
            Effects.audioMixer.SetFloat("EffectsVolume", value);
        }
    }
}