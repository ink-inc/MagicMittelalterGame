using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public int interactRange = 3;
    public Camera origin;
    public bool drawRay = false;
    public Text itemDisplayText;
    public Text itemDisplaySubtext;
    private Interactable target;

    private void Start()
    {
        Logger.log("Initializing Interactor: " + gameObject.name);
        if (itemDisplayText == null || itemDisplaySubtext == null)
        {
            Logger.log("ItemDisplayText or ItemDisplaySubText is null!");
        }
    }

    public void FixedUpdate()
    {
        RaycastHit hit;
        itemDisplayText.text = null;
        itemDisplaySubtext.text = null;
        if (Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, interactRange))
        {
            if (hit.collider.tag == "Interactable")
            {
                target = hit.transform.GetComponent<Interactable>();
                itemDisplayText.text = target.displayText;
                itemDisplaySubtext.text = target.displaySubtext;
            }
        }
        else
        {
            target = null;
        }
    }

    public void keyDown()
    {
        if (target != null)
        {
            target.interact();
        }
    }
}