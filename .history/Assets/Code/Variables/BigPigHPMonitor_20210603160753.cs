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
            Text.text = ""+Pig.StartHP.Value;
        }
        
        private void OnEnable()
        {
            Text.text = ""+Pig.HP();
        }

        public void UpdateHP()
        {
            Debug.Log("BigPig Update HP: " + Pig.HP());
            if (AlwaysUpdate)
            {
                Text.text = ""+Pig.HP();
            }
            if (Pig.HP() == 0)
            {
                Text.enabled = false;
                enabled = false;
            }
        }
    }
}