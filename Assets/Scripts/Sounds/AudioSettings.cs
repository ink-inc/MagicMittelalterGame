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

        public static void VolumeChange(AudioMixerGroup mixerGroup, float value)
        {
            mixerGroup.audioMixer.SetFloat("Volume", value);
        }
    }
}