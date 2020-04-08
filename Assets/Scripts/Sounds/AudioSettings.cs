using UnityEngine;
using UnityEngine.Audio;

namespace Sounds
{
    public class AudioSettings: MonoBehaviour
    {
        [Tooltip("Audio master of the scene.")]
        public AudioMixer master;
        
        [field: Tooltip("Music Mixer")] public AudioMixerGroup Music { get; private set; }
        [field: Tooltip("Dialogue Mixer")] public AudioMixerGroup Dialogue { get; private set; }
        [field: Tooltip("Character Mixer")] public AudioMixerGroup Character { get; private set; }
        [field: Tooltip("Ambient Mixer")] public AudioMixerGroup Ambient { get; private set; }
        [field: Tooltip("Effects Mixer")] public AudioMixerGroup Effects { get; private set; }

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
            master.SetFloat("Volume", value);
        }
        
        public void ChangeMusic(float value)
        {
            VolumeChange(Music, value);
        }
        
        public void ChangeDialogue(float value)
        {
            VolumeChange(Dialogue, value);
        }
        public void ChangeCharacter(float value)
        {
            VolumeChange(Character, value);
        }
        public void ChangeAmbient(float value)
        {
            VolumeChange(Ambient, value);
        }
        public void ChangeEffects(float value)
        {
            VolumeChange(Effects, value);
        }
        
        

        private static void VolumeChange(AudioMixerGroup mixerGroup, float value)
        {
            mixerGroup.audioMixer.SetFloat("Volume", value);
        }

        
    }
}