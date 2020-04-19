using UnityEngine;

namespace Sounds.Manager.Util
{
    public static class DefaultCharacterSounds
    {
        private const string FoleyPath = "Sounds/Foleys/";
        public static void SetDefaultForMissing(CharacterSounds characterSounds)
        {
            if (characterSounds.damage == null)
            {
                characterSounds.damage = Resources.Load<AudioClip>($"{FoleyPath}404109__deathscyp__damage-1");
            }
            if (characterSounds.damage == null)
            {
                characterSounds.runningStone = Resources.Load<AudioClip>(
                    $"{FoleyPath}Movement/430708__juandamb__running");
            }

            if (characterSounds.sneakingStone == null)
            {
                characterSounds.sneakingStone =Resources.Load<AudioClip>(
                    $"{FoleyPath}Movement/260120__splicesound__01-20-footsteps-tile-slippers-slow-pace");
            }

            if (characterSounds.walkSnow == null)
            {
                characterSounds.walkSnow = Resources.Load<AudioClip>(
                    $"{FoleyPath}Movement/215690__musicbrain__walking-in-snow-1");
            }

            if (characterSounds.walkStone == null)
            {
                characterSounds.walkStone = Resources.Load<AudioClip>(
                    $"{FoleyPath}Movement/208103__phil25__stone-steps");
            }
        }
    }
}