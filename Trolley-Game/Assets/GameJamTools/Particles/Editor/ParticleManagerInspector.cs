using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameJamTools
{
    [CustomEditor(typeof(ParticleManager))]
    public class ParticleManagerInspector : Editor
    {
        [HideInInspector] ParticleManager particleManager;

        private void OnEnable()
        {
        }

        // Todo: MAke ParticleManager Work
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Gimme ParticleObject with ParticleManager.Instance().SpawnParticle()!");
            /*
            base.OnInspectorGUI();
            EditorGUI.BeginChangeCheck();

            particleManager = (ParticleManager)target;
            swap = -1;
            if (particleManager.particlePoolInfo == null)
                particleManager.particlePoolInfo = new List<ParticlePoolInfo>();
            if (particleManager.toggles == null)
                particleManager.toggles = new List<bool>();

            //toggles = new List<bool>(particleManager.particlePoolInfo.Count);


            GUILayout.BeginHorizontal();
            if (GUILayout.Button("-", GUILayout.Width(75)))
            {
                if (particleManager.particlePoolInfo.Count > 0)
                {
                    Undo.RecordObject(particleManager, "Remove Pool");
                    particleManager.particlePoolInfo.RemoveAt(particleManager.particlePoolInfo.Count - 1);
                    particleManager.toggles.RemoveAt(particleManager.toggles.Count - 1);
                }
            }
            if (GUILayout.Button("+", GUILayout.Width(75)))
            {
                Undo.RecordObject(particleManager, "Add Pool");
                particleManager.particlePoolInfo.Add(new ParticlePoolInfo());
                if (particleManager.toggles.Count < particleManager.particlePoolInfo.Count)
                    particleManager.toggles.Add(false);
            }
            GUILayout.EndHorizontal();

            for (int i = 0; i < particleManager.particlePoolInfo.Count; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Size:", GUILayout.Width(75));
                particleManager.particlePoolInfo[i].sizePP = EditorGUILayout.IntField(particleManager.particlePoolInfo[i].sizePP, GUILayout.Width(75));
                GUILayout.Label("Prefab:", GUILayout.Width(75));
                particleManager.particlePoolInfo[i].particlePrefab = (ParticleBehaviour)EditorGUILayout.ObjectField(particleManager.particlePoolInfo[i].particlePrefab, typeof(ParticleBehaviour), false);

                // Debug.Log(particleManager.toggles.Count);
                particleManager.toggles[i] = GUILayout.Toggle(particleManager.toggles[i], ":Swap");
                if (particleManager.toggles[i])
                {
                    if (swap > -1 && swap != i)
                    {
                        ParticlePoolInfo temp = particleManager.particlePoolInfo[i];
                        particleManager.particlePoolInfo[i] = particleManager.particlePoolInfo[swap];
                        particleManager.particlePoolInfo[swap] = temp;

                        particleManager.toggles[i] = false;
                        particleManager.toggles[swap] = false;
                        swap = -1;
                    }
                    else
                    {
                        swap = i;
                    }
                }
                GUILayout.EndHorizontal();
            }
            if (GUILayout.Button("CLEAR"))
            {
                Undo.RecordObject(particleManager, "Clear");
                particleManager.particlePoolInfo.Clear();
                particleManager.toggles.Clear();
            }
        */

        }
    }
}