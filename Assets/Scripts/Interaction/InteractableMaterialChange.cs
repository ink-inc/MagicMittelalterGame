using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/MaterialChange")]
    public class InteractableMaterialChange : Interactable
    {
        public new Renderer renderer;
        public Material[] materials;
        public int materialIndex = 0;

        //Cube rotates through these materials when interacted with
        private void Start()
        {
            if (renderer == null)
            {
                renderer = GetComponent<Renderer>();
            }

            if (materials == null || materials.Length < 1)
            {
                Debug.LogError("InteractableColorChange has no materials");
                return;
            }

            UpdateMaterial();
        }

        public override void Interact(Interactor interactor)
        {
            NextMaterial();
            UpdateMaterial();
        }

        private void UpdateMaterial()
        {
            renderer.material = materials[materialIndex];
        }

        private void NextMaterial()
        {
            materialIndex++;
            materialIndex %= materials.Length;
        }
    }
}