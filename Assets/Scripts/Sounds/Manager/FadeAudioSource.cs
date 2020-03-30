using System;
using System.Collections;
using UnityEngine;
/*
 * This copied from https://gamedevbeginner.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/#first_method
 * It was posted on the 29th August 2019 by and retrieved by Marcel Haas (Segelzwerg) on 30th March 2020.
 */
namespace Sounds.Manager
{
    public static class FadeAudioSource {

        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }

            if (!(Math.Abs(targetVolume) < 0.1f)) yield break;
            audioSource.clip = null;
            audioSource.Stop();
        }
    }
}