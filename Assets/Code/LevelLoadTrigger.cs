// ----------------------------------------------------------------------------
// AngryBird object Disabler
// ----------------------------------------------------------------------------

using UnityEngine;

namespace AngryBirds.Example1
{
    public class LevelLoadTrigger : MonoBehaviour
    {
        public Event levelLoaded;
        public void Start()
        {
            levelLoaded.Raise();
        }
    }
}