using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace AngryBirds
{
    [CreateAssetMenu]
    public class SceneEvent : ScriptableObject
    {
        public void GoNextScene()
        {
            var active = SceneManager.GetActiveScene();
            var next = SceneManager.GetSceneAt(active.buildIndex + 1);
            SceneManager.LoadScene(next.name);
        }
        public void GoPreviousScene()
        {
            var active = SceneManager.GetActiveScene();
            var prev = SceneManager.GetSceneAt(active.buildIndex - 1);
            SceneManager.LoadScene(prev.name);
        }
        public void GoMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}