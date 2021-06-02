// ----------------------------------------------------------------------------
// 
// ----------------------------------------------------------------------------

using UnityEngine;

namespace AngryBirds
{
    public class ScoreHandler : MonoBehaviour
    {
        public FloatVariable Score;
        public FloatVariable StartScore;
        public Event ScoreChangeEvent;

        private void Start()
        {
            Score.SetValue(StartScore);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Made it here");
            ScoreAddedReference scoreChange = other.gameObject.GetComponent<ScoreAddedReference>();
            if (scoreChange != null)
                Score.ApplyChange(scoreChange.ScoreAdded);
                Debug.Log(Score.Value);
                ScoreChangeEvent.Raise();
        }
    }
}