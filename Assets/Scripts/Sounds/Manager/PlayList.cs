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

        public static PlayList Load(string name, DoubleAudioSource audioSource)
        {
            //TODO: use actual db to load lists
            List<AudioClip> clips = new List<AudioClip>();
            if (name == "fight")
            {
                AudioClip battle = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Music/510953__theojt__cinematic-battle-song.mp3");
                clips.Add(battle);
            } else {
                AudioClip cave = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Music/A1-Cave.mp3");
                clips.Add(cave);
            }
            return new PlayList(name, audioSource, clips);
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