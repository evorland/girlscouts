// ----------------------------------------------------------------------------
// Monobehaviour example for an object that will be added to a RuntimeSet
// ----------------------------------------------------------------------------

using UnityEngine;

namespace AngryBirds.Example3
{
    public class BigPig : MonoBehaviour
    {
        public BigPigRuntimeSet RuntimeSet;
        public FloatVariable StartHP;
        public Event HPChangeEvent;
        public float HPRemaining;

        public float HP()
        {
            return HPRemaining;
        }

        private void Start()
        {
            Debug.Log("Setting Initial HP: " + StartHP.Value);
            HPRemaining = StartHP.Value;
        }

        private void OnEnable()
        {
            RuntimeSet.Add(this);
        }

        private void OnDisable()
        {
            RuntimeSet.Remove(this);
        }

        private void TakeDamage(FloatReference amount)
        {
            if (amount.Value > HPRemaining)
            {
                Debug.Log("BigPig has no HP left!");
                HPRemaining = 0;
                Debug.Log("Raising HP Change Event");
                HPChangeEvent.Raise();
                enabled = false;
                return;
            }
            Debug.Log("BigPig took " + amount.Value + " damage!");
            HPRemaining -= amount.Value;
            Debug.Log("Raising HP Change Event");
            HPChangeEvent.Raise();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("BigPig Took Damage!");
            DamageDealtReference damage = other.gameObject.GetComponent<DamageDealtReference>();
            if (damage != null)
                TakeDamage(damage.DamageDealt);
        }
    }
}