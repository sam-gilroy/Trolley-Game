using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameJamTools
{
    [CustomEditor(typeof(AudioObject), true)]
    public class AudioObjectEditor : Editor
    {
        [SerializeField] private AudioSource _previewer;

        private void OnEnable()
        {
            _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
        }

        public void OnDisable()
        {
            DestroyImmediate(_previewer.gameObject);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
            if (GUILayout.Button("Preview"))
            {
                ((AudioObject)target).Play(_previewer);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}