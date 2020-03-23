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
            //if (drawRay)
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            //Debug.Log("Did Hit");
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
            //if (drawRay)
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactRange, Color.red);
        }
    }

    public void keyDown()
    {
        if (target != null)
        {
            target.interact();
        }
        /*RaycastHit hit;
        if(Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, interactRange))
        {
            if(drawRay)
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            if(hit.collider.tag == "Interactable")
            {
                Debug.Log("Hit Interactable Object: " + hit.transform.name);
                Interactable hitObject = hit.transform.GetComponent<Interactable>();
                hitObject.interact();
            }
        }
        else
        {
            if(drawRay)
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactRange, Color.red);
            Debug.Log("Did not Hit");
        }*/
    }
}