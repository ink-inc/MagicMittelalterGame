using Interaction;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Interaction/Interactor")]
public class Interactor : MonoBehaviour
{
    public int interactRange = 3;
    public Camera origin;
    public Text itemDisplayText;
    public Text itemDisplaySubtext;

    private Interactable _target;

    private void Start()
    {
        Logger.log("Initializing Interactor: " + gameObject.name);
        if (itemDisplayText == null || itemDisplaySubtext == null)
        {
            Logger.log("ItemDisplayText or ItemDisplaySubText is null!");
        }
    }

    private void FixedUpdate()
    {
        itemDisplayText.text = null;
        itemDisplaySubtext.text = null;
        _target = null;

        if (Physics.Raycast(origin.transform.position, origin.transform.forward, out var hit, interactRange)
            && hit.collider.CompareTag("Interactable"))
        {
            _target = hit.transform.GetComponent<Interactable>();
            itemDisplayText.text = _target.displayText;
            itemDisplaySubtext.text = _target.displaySubtext;
        }
    }

    public void KeyDown()
    {
        if (_target != null)
        {
            _target.Interact(this);
        }
    }
}