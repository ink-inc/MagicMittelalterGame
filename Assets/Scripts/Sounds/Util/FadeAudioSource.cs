using System;
using System.Collections;
using UnityEngine;

/*
 * This copied from https://gamedevbeginner.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/#first_method
 * It was posted on the 29th August 2019 by and retrieved by Marcel Haas (Segelzwerg) on 30th March 2020.
 */
namespace Sounds.Util
{
    public static class FadeAudioSource {

        public static IEnumerator StartFadeOut(AudioSource audioSource, float duration)
        {
            
            yield return StartFade(audioSource, duration, 0f);
            audioSource.clip = null;
            audioSource.Stop();
        }

        public static IEnumerator StartFadeIn(AudioSource audioSource, float duration,
            AudioClip clip, float targetVolume=1f, float startTime=0f)
        {
            audioSource.clip = clip;
            audioSource.volume = 0f;
            audioSource.time = startTime;
            audioSource.Play();
            yield return StartFade(audioSource, duration, targetVolume);

        }

        private static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
        }
    }
}