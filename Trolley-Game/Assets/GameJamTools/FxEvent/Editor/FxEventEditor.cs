using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameJamTools
{
    [CustomPropertyDrawer(typeof(FxEvent))]
	public class FxEventEditor : PropertyDrawer {
        FxEvent Target;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //Label
            EditorGUI.BeginProperty(position, label, property);

            EditorGUILayout.Space();
            GUI.Box(position, "FxEvent: " + label.text,GUI.skin.window);

            SerializedProperty eventTypeProp = property.FindPropertyRelative("eventType");

            position.height = EditorGUIUtility.singleLineHeight;
            AdvanceRect(ref position);
            EditorGUI.PropertyField(position, eventTypeProp);
            AdvanceRect(ref position);

            EventType eventType = (EventType)eventTypeProp.enumValueIndex;
            switch (eventType)
            {
                case EventType.None:
                    break;
                case EventType.Particle:
                    ParticleFields(position, property);
                    break;
                case EventType.Audio:
                    AudioFields(position, property);
                    break;
                case EventType.Camera:
                    CameraFields(position, property);
                    break;
            }

            EditorGUI.EndProperty();
        }

        void AdvanceRect(ref Rect position)
        {
            position.y += EditorGUIUtility.singleLineHeight;
        }

        public void ParticleFields(Rect position, SerializedProperty property)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("particleEvent.particleObject"));
            AdvanceRect(ref position);
            EditorGUI.PropertyField(position, property.FindPropertyRelative("particleEvent.bUseTransform"));
            AdvanceRect(ref position);
            if (property.FindPropertyRelative("particleEvent.bUseTransform").boolValue)
            {
                EditorGUI.PropertyField(position, property.FindPropertyRelative("particleEvent.transform"));
            }
            else
            {
                EditorGUI.PropertyField(position, property.FindPropertyRelative("particleEvent.position"));
            }
        }

        public void AudioFields(Rect position, SerializedProperty property)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("audioEvent.audioObject"));
        }

        public void CameraFields(Rect position, SerializedProperty property)
        {
            SerializedProperty eventTypeProp = property.FindPropertyRelative("cameraEvent.EventType");

            EditorGUI.PropertyField(position, eventTypeProp);
            AdvanceRect(ref position);

            CameraEventType eventType = (CameraEventType)eventTypeProp.enumValueIndex;

            switch (eventType)
            {
                case CameraEventType.Position:
                    EditorGUI.PropertyField(position, property.FindPropertyRelative("cameraEvent.position"));
                    break;
                case CameraEventType.Transform:
                    EditorGUI.PropertyField(position, property.FindPropertyRelative("cameraEvent.transform"));
                    break;
                case CameraEventType.Shake:
                    EditorGUI.PropertyField(position, property.FindPropertyRelative("cameraEvent.shakeDir"));
                    AdvanceRect(ref position);
                    EditorGUI.PropertyField(position, property.FindPropertyRelative("cameraEvent.shakeRate"));
                    AdvanceRect(ref position);
                    EditorGUI.PropertyField(position, property.FindPropertyRelative("cameraEvent.shakeDecay"));
                    break;
                case CameraEventType.Push:
                    EditorGUI.PropertyField(position, property.FindPropertyRelative("cameraEvent.pushDir"));
                    break;
            }

            AdvanceRect(ref position);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 100;
        }
    }
}