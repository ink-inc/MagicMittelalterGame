using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class AttackCalculator : MonoBehaviour
    {
        public GameObject attachedGameobjekt { get; set; }

        private void Start()
        {
            attachedGameobjekt = transform.parent.gameObject;
        }
        public void CalculateDamage(float damage)
        {
            PlayerProperties NPCProps = attachedGameobjekt.GetComponent<PlayerProperties>();
            NPCProps.SetHealth(Mathf.Clamp(NPCProps.health - damage, 0, NPCProps.maxHealth));
        }

        public void CalculateEffect()
        {
            // TODO: Empty call, add Miles' status Effects
        }
    }
}
