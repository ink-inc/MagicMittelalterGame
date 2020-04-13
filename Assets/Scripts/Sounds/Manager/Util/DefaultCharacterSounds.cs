using UnityEditor;
using UnityEngine;

namespace Sounds.Manager.Util
{
    public static class DefaultCharacterSounds
    {
        private const string FoleyPath = "Assets/Sounds/Foleys/";
        public static void SetDefaultForMissing(CharacterSounds characterSounds)
        {
            if (characterSounds.damage == null)
            {
                characterSounds.damage = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}404109__deathscyp__damage-1.wav");
            }
            if (characterSounds.damage == null)
            {
                characterSounds.runningStone = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/430708__juandamb__running.wav");
            }

            if (characterSounds.sneakingStone == null)
            {
                characterSounds.sneakingStone = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/260120__splicesound__01-20-footsteps-tile-slippers-slow-pace.wav");
            }

            if (characterSounds.walkSnow == null)
            {
                characterSounds.walkSnow = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/215690__musicbrain__walking-in-snow-1.wav");
            }

            if (characterSounds.walkStone == null)
            {
                characterSounds.walkStone = AssetDatabase.LoadAssetAtPath<AudioClip>(
                    $"{FoleyPath}Movement/208103__phil25__stone-steps.wav");
            }
        }
    }
}