// ----------------------------------------------------------------------------
// AngryBird object Disabler
// ----------------------------------------------------------------------------

using UnityEngine;

namespace AngryBirds.Example1
{
    public class LevelLoadTrigger : MonoBehaviour
    {
        public Event spawnBirdEvent;
        public void Start()
        {
            for(int i=0; i<5; i++)
            {
                spawnBirdEvent.Raise();
            }
        }
    }
}