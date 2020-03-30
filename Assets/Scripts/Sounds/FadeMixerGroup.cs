using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
/*
 * This copied from https://gamedevbeginner.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/#second_method
 * It was posted on the 29th August 2019 by and retrieved by Marcel Haas on 30th March 2020.
 */
namespace Sounds
{
    /// <summary>
    /// This fades a audio mixer.
    /// </summary>
    public static class FadeMixerGroup {

        public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
        {
            float currentTime = 0;
            float currentVol;
            audioMixer.GetFloat(exposedParam, out currentVol);
            currentVol = Mathf.Pow(10, currentVol / 20);
            float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
                audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
                yield return null;
            }
            yield break;
        }
    }
}