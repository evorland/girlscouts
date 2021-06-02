// ----------------------------------------------------------------------------
// AngryBird object Disabler
// ----------------------------------------------------------------------------

using UnityEngine;

namespace AngryBirds.Example1
{
    public class AngryBirdEnabler : MonoBehaviour
    {
        public AngryBirdRuntimeSet Set;
        public GameObject prefab;
        public Transform parent;

        public void StartLevel()
        {
            for(int i=0; i<5; i++)
            {
                Enable();
            }
        }

        public void Enable()
        {
            GameObject bird = Instantiate(prefab, RandomPosition(), Quaternion.identity) as GameObject;
            bird.transform.SetParent(parent);
            bird.GetComponent<RectTransform>().anchoredPosition = RandomPosition();
        }

        private Vector2 RandomPosition()
        {
            int minX = -375;
            int maxX = 1170;
            int minY = -325;
            int maxY = 615;
            int randomIntX = Random.Range (Mathf.RoundToInt(minX/10), Mathf.RoundToInt(maxX/10));
            int randomIntY = Random.Range (Mathf.RoundToInt(minY/10), Mathf.RoundToInt(maxY/10));
            return new Vector2(randomIntX, randomIntY) * 10;
        }
    }
}