// ----------------------------------------------------------------------------
// 
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace AngryBirds
{
    public class TextReplacer : MonoBehaviour
    {
        public Text Text;

        public FloatVariable Variable;

        public bool AlwaysUpdate;
        
        private void OnEnable()
        {
            Text.text = ""+Variable.Value;
        }

        public void Update()
        {
            if (AlwaysUpdate)
            {
                Text.text = ""+Variable.Value;
            }
        }
    }
}