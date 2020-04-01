using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sounds.Manager
{
    public class PlayList
    {
        private readonly DoubleAudioSource _audioSource;
        private readonly List<AudioClip> _tracks;

        public PlayList(string name, [NotNull] DoubleAudioSource audioSource, List<AudioClip> tracks)
        {
            if (audioSource == null) throw new ArgumentNullException(nameof(audioSource));
            Name = name;
            Debug.Log("Constructor:" + audioSource);
            _audioSource = audioSource;
            _tracks = tracks;
        }

        /// <summary>
        /// Name of the playlist.
        /// </summary>
        public string Name { get; }

        public static PlayList Load(string area, DoubleAudioSource audioSource)
        {
            Debug.Log(audioSource);
            AudioClip cave = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Music/A1-Cave.mp3");
            List<AudioClip> clips = new List<AudioClip> {cave};
            return new PlayList(area, audioSource, clips);
        }

        /// <summary>
        /// Starts playing the playlist.
        /// </summary>
        public IEnumerator Play()
        {
            AudioClip clip = GetRandomClip();
            _audioSource.CrossFadeToNewClip(clip);
            return CheckTrackPlaying();
        }


        /// <summary>
        /// Stops the current clip in the audio source.
        /// </summary>
        public void Stop()
        {
            _audioSource.Stop();
        }

        private IEnumerator CheckTrackPlaying()
        {
            yield return new WaitWhile(() => _audioSource.IsPlaying);
        }

        

        private AudioClip GetRandomClip()
        {
            int next = Random.Range(0, _tracks.Count);
            return _tracks[next];
        }

    }
}