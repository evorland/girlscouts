// ----------------------------------------------------------------------------
// 
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace AngryBirds.Example3
{
    public class BigPigHPMonitor : MonoBehaviour
    {
        public Text Text;
        public BigPig Pig;
        public bool AlwaysUpdate;

        private void Start()
        {
            Text.text = ""+Pig.StartHP;
        }
        
        private void OnEnable()
        {
            Text.text = ""+Pig.HPRemaining;
        }

        public void UpdateHP()
        {
a            Debug.Log("BigPig Update HP: " + Pig.HPRemaining);
            if (AlwaysUpdate)
            {
                Text.text = ""+Pig.HPRemaining;
            }
        }
    }
}