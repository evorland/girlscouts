// ----------------------------------------------------------------------------
// Monobehaviour example for an object that will be added to a RuntimeSet
// ----------------------------------------------------------------------------

using UnityEngine;

namespace AngryBirds.Example1
{
    public class AngryBird : MonoBehaviour
    {
        public AngryBirdRuntimeSet RuntimeSet;
        public GameObject angryBirdPrefab;

        private void OnEnable()
        {
            RuntimeSet.Add(this);
        }

        private void OnDisable()
        {
            RuntimeSet.Remove(this);
        }
    }
}