// ----------------------------------------------------------------------------
// Monitor a Set of Angry Birds for updates
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace AngryBirds.Example1
{
    public class MonitorAngryBirds : MonoBehaviour
    {
        public AngryBirdRuntimeSet Set;

        public Text Text;

        private int previousCount = -1;

        private void OnEnable()
        {
            UpdateText();
        }

        private void Update()
        {
            if (previousCount != Set.Items.Count)
            {
                UpdateText();
                previousCount = Set.Items.Count;
            }
        }

        public void UpdateText()
        {
            Text.text = "" + Set.Items.Count;
        }
    }
}