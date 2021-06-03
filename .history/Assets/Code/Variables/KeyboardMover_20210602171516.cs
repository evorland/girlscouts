// ----------------------------------------------------------------------------
// WASD Keyboard Script
// ----------------------------------------------------------------------------

using System;
using UnityEngine;

namespace AngryBirds
{
    public class KeyboardMover : MonoBehaviour
    {
        [Serializable]
        public class MoveAxis
        {
            public KeyCode Positive;
            public KeyCode Negative;

            public MoveAxis(KeyCode positive, KeyCode negative)
            {
                Positive = positive;
                Negative = negative;
            }

            public static implicit operator float(MoveAxis axis)
            {
                return (Input.GetKey(axis.Positive)
                    ? 1.0f : 0.0f) -
                    (Input.GetKey(axis.Negative)
                    ? 1.0f : 0.0f);
            }
        }

        public FloatVariable MoveRate;
        public MoveAxis Horizontal = new MoveAxis(KeyCode.D, KeyCode.A);
        public MoveAxis Vertical = new MoveAxis(KeyCode.W, KeyCode.S);
        public Transform Parent;

        private void Update()
        {
            transform.SetParent(Parent);
            Vector2 moveNormal = new Vector2(Horizontal, Vertical).normalized;

            // transform.position += moveNormal*Time.deltaTime*MoveRate.Value;
            GetComponent<RectTransform>().anchoredPosition += moveNormal*Time.deltaTime*MoveRate.Value;
        }
    }
}