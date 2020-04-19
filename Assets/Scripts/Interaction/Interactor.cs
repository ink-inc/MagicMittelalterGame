using UnityEngine;
using UnityEngine.UI;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactor")]
    public class Interactor : MonoBehaviour
    {
        public int interactRange = 3;
        public Transform origin;
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

            if (origin == null)
            {
                origin = GetComponentInChildren<Camera>().transform;
            }
        }

        private void FixedUpdate()
        {
            itemDisplayText.text = null;
            itemDisplaySubtext.text = null;
            _target = null;

            if (Physics.Raycast(origin.position, origin.forward, out var hit, interactRange)
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
}