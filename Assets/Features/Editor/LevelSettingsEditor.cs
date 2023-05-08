using Features.Level.Data;
using Features.SceneMarkers.Scripts;
using UnityEditor;
using UnityEngine;

namespace Features.Editor
{
	[CustomEditor(typeof(LevelSettings))]
	public class LevelSettingsEditor : UnityEditor.Editor
	{
		private LevelSettings settings;
		public override void OnInspectorGUI()
		{
			settings = (LevelSettings) target;
			base.OnInspectorGUI();
			GUILayout.BeginVertical();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Collect Bonus Spawn Position"))
				CollectBonusSpawnPositions();
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
		}

		private void CollectBonusSpawnPositions()
		{
			BonusSpawnMarker[] markers = FindObjectsOfType<BonusSpawnMarker>();
			settings.BonusSpawnPositions = new Vector3[markers.Length];

			for (int i = 0; i < markers.Length; i++)
			{
				settings.BonusSpawnPositions[i] = markers[i].transform.position;
			}

			EditorUtility.SetDirty(settings);
			AssetDatabase.SaveAssets();
		}
	}
}