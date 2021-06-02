// ----------------------------------------------------------------------------
// Scriptable Objects Event Editor Enabling
//
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace AngryBirds
{
    [CustomEditor(typeof(Event), editorForChildClasses: true)]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            Event e = target as Event;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
}
