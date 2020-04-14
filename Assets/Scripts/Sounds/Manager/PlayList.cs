using System.Collections.Generic;
using UnityEngine;

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
                AudioClip battle = Resources.Load<AudioClip>("Music/510953__theojt__cinematic-battle-song");
                clips.Add(battle);
            } else {
                AudioClip cave = Resources.Load<AudioClip>("Music/A1-Cave");
                clips.Add(cave);
            }
            return new PlayList(name, audioSource, clips);
        }

        /// <summary>
        /// Starts playing the playlist.
        /// </summary>
        /// <param name="delay">Seconds of delaying the start of the next track.</param>
        /// <param name="fadeDuration">Seconds the fade will took.</param>
        public void Play(int delay = 0, float fadeDuration = 3f)
        {
            AudioClip clip = GetRandomClip(_audioSource.Clip);
            if (_audioSource.IsPlaying)
            {
                _audioSource.CrossFadeToNewClip(clip);
            }
            else
            {
                _audioSource.FadeIn(clip,duration:fadeDuration, delay:delay);
            }
        }
        
        /// <summary>
        /// Checks if the last track is finished.
        /// </summary>
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

        /// <summary>
        /// Like Stop but slower.
        /// </summary>
        public void FadeOut()
        {
            _audioSource.FadeOut(3f);
        }


        /// <summary>
        /// Selects a random clip from playlist other than the current one, unless it is the only one.
        /// </summary>
        /// <param name="currentClip">The track currently playing.</param>
        /// <returns>The next track.</returns>
        private AudioClip GetRandomClip(AudioClip currentClip)
        {
            List<AudioClip> otherClips = _tracks.FindAll(item => item != currentClip);


            if (_tracks.Count ==  1)
            {
                otherClips = _tracks;
            }
            
            int next = Random.Range(0, otherClips.Count);
            return _tracks[next];
        }

    }
}