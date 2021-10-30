using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Main.Scripts.Utils
{
    
    public class SceneSwitcherWindow : EditorWindow
    {
        private List<string> _scenePaths;

        [MenuItem("Tools/Scene Switcher")]
        private static void ShowWindow()
        {
            var window = GetWindow<SceneSwitcherWindow>();
            window.titleContent = new GUIContent("Scene Switcher");
            window.Show();
        }

        private void OnEnable()
        {
            var sceneGUIDS = AssetDatabase.FindAssets("t: Scene");
            _scenePaths = sceneGUIDS.Select(AssetDatabase.GUIDToAssetPath).ToList();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Reload", GUILayout.Width(100)))
            {
                OnEnable();
            }

            #region Hardcoded Scenes

            AddButton(new SceneDataWindow(_scenePaths.FirstOrDefault(scene => scene.Contains("Initialization")), "Initialization"));
            AddButton(new SceneDataWindow(_scenePaths.FirstOrDefault(scene => scene.Contains("_Main")), "Main"));
            AddButton(new SceneDataWindow(_scenePaths.FirstOrDefault(scene => scene.Contains("Rooms")), "PUN Room"));
            AddButton(new SceneDataWindow(_scenePaths.FirstOrDefault(scene => scene.Contains("chillroom")), "Chill room"));
            AddButton(new SceneDataWindow(_scenePaths.FirstOrDefault(scene => scene.Contains("HornyRoom")), "HornyRoom"));

            #endregion

            GUILayout.Space(20);
            
            #region Dynamic Scenes

            GUILayout.Label("Dynamic Scenes");

            EditorGUILayout.BeginVertical();
            {
                foreach (string scene in _scenePaths)
                {
                    if (!scene.Contains("Main/_Scenes")) continue;
                    
                    AddButton(new SceneDataWindow(scene, scene));
                }
            }
            EditorGUILayout.EndVertical();

            #endregion
        }

        private void AddButton(SceneDataWindow sceneData)
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button(sceneData.Name))
            {
                EditorSceneManager.OpenScene(sceneData.Path);
            }

            if (GUILayout.Button("L", GUILayout.Width(20)))
            {
                var obj = AssetDatabase.LoadAssetAtPath(sceneData.Path, typeof(SceneAsset));
                EditorGUIUtility.PingObject(obj);
            }
            
            EditorGUILayout.EndHorizontal();
        }
    }
}