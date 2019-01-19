using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameJamTools
{
    [CustomEditor(typeof(TriggerVolume))]
	public class TriggerVolumeEditor : Editor{
        TriggerVolume Target;
        bool bHideTags;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Target = ((TriggerVolume)target);

            TagsLabel();
            TagsList();
            TagsAddButton();
            HideTags();
        }

        void TagsLabel()
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Tags to Check For");
        }

        void HideTags()
        {
            bHideTags = EditorGUILayout.Toggle("Hide: ", bHideTags);
        }

        void TagsList()
        {
            if (!bHideTags)
            {
                for (int i = 0; i < Target.Tags.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    Target.Tags[i] = EditorGUILayout.TagField(Target.Tags[i]);
                    if (GUILayout.Button("-", GUILayout.Width(25)))
                    {
                        Target.Tags.RemoveAt(i);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }

        void TagsAddButton()
        {
            if (!bHideTags)
            {
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("+", GUILayout.Width(100)))
                {
                    Target.Tags.Add(UnityEditorInternal.InternalEditorUtility.tags[0]);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}