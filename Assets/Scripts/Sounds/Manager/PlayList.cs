using System;
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

        public PlayList(string name, DoubleAudioSource audioSource, List<AudioClip> tracks)
        {
            Name = name;
            _audioSource = audioSource;
            _tracks = tracks;
        }

        /// <summary>
        /// Name of the playlist.
        /// </summary>
        public string Name { get; }

        public static PlayList Load(string area, DoubleAudioSource audioSource)
        {
            //TODO: use actual db to load lists
            AudioClip cave = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Music/A1-Cave.mp3");
            AudioClip fanfare = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Music/413203__joepayne__clean-and-pompous-fanfare-trumpet.mp3");
            List<AudioClip> clips = new List<AudioClip> {cave, fanfare};
            return new PlayList(area, audioSource, clips);
        }

        /// <summary>
        /// Starts playing the playlist.
        /// </summary>
        public void Play()
        {
            AudioClip clip = GetRandomClip();
            _audioSource.CrossFadeToNewClip(clip);
        }
        
        public void CheckPlaying()
        {
            if (!_audioSource.IsPlaying)
            {
                Play();
            }
        }


        /// <summary>
        /// Stops the current clip in the audio source.
        /// </summary>
        public void Stop()
        {
            _audioSource.Stop();
        }


        private AudioClip GetRandomClip()
        {
            int next = Random.Range(0, _tracks.Count);
            return _tracks[next];
        }

    }
}