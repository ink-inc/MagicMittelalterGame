using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Interaction/Interactable/ColorChange")]
public class Interactable_ColorChangeCube : Interactable
{
    public new Renderer renderer;
    public Material[] materials;
    public int materialIndex = 0;

    //Cube rotates through these materials when interacted with
    private void Start()
    {
        if (renderer == null)
            renderer = GetComponent<Renderer>();
        if (materials == null || materials.Length < 1)
        {
            Debug.LogError("ColorChangeCube has no materials");
            return;
        }
        updateMaterial();
    }

    public override void interact()
    {
        nextMaterial();
        updateMaterial();
    }

    private void updateMaterial()
    {
        renderer.material = materials[materialIndex];
    }

    private void nextMaterial()
    {
        materialIndex++;
        materialIndex = materialIndex % materials.Length;
    }
}