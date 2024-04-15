using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AirResistance2
{
	[CustomEditor(typeof(AirResistance))]
	public class AirResistanceInspector : Editor
	{
		private SerializedProperty raycastDensity;
		private SerializedProperty useOverrideDensity;
		private SerializedProperty useOverrideVariation;
		private SerializedProperty overrideAirDensity;
		private SerializedProperty overrideDensityVariation;
		private SerializedProperty debug;
		private AirResistanceDefaults defaults;
		private GUIStyle inactiveField;
		private GUIContent airDensityLabel;
		private GUIContent densityVariationLabel;

		private void OnEnable()
		{
			raycastDensity = serializedObject.FindProperty("raycastDensity");
			useOverrideDensity = serializedObject.FindProperty("useOverrideDensity");
			useOverrideVariation = serializedObject.FindProperty("useOverrideVariation");
			overrideAirDensity = serializedObject.FindProperty("overrideAirDensity");
			overrideDensityVariation = serializedObject.FindProperty("overrideDensityVariation");
			debug = serializedObject.FindProperty("debug");

			defaults = AssetDatabase.LoadAssetAtPath<AirResistanceDefaults>("Assets/AirResistanceDefaults.asset");
			if(defaults == null)
			{
				defaults = CreateInstance<AirResistanceDefaults>();
				AssetDatabase.CreateAsset(defaults, "Assets/AirResistanceDefaults.asset");
			}
		}

		public override void OnInspectorGUI()
		{
			if(inactiveField == null || airDensityLabel == null || densityVariationLabel == null)
			{
				inactiveField = new GUIStyle(GUI.skin.box);
				inactiveField.alignment = TextAnchor.MiddleLeft;

				airDensityLabel = new GUIContent("Air Density");
				densityVariationLabel = new GUIContent("Density Variation");
			}

			serializedObject.Update();
			EditorGUILayout.PropertyField(raycastDensity);

			EditorGUILayout.BeginHorizontal();
			if(useOverrideDensity.boolValue) EditorGUILayout.PropertyField(overrideAirDensity, airDensityLabel);
			else
			{
				overrideAirDensity.floatValue = defaults.defaultAirDensity;

				EditorGUILayout.LabelField(airDensityLabel, GUILayout.Width(EditorGUIUtility.labelWidth));
				GUILayout.Box(defaults.defaultAirDensity.ToString(), inactiveField, GUILayout.ExpandWidth(true));
			}

			useOverrideDensity.boolValue = GUILayout.Toggle(useOverrideDensity.boolValue, "Override Air Density");
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if (useOverrideVariation.boolValue) EditorGUILayout.PropertyField(overrideDensityVariation, densityVariationLabel);
			else
			{
				overrideDensityVariation.floatValue = defaults.defaultDensityVariation;

				EditorGUILayout.LabelField(densityVariationLabel, GUILayout.Width(EditorGUIUtility.labelWidth));
				GUILayout.Box(defaults.defaultDensityVariation.ToString(), inactiveField, GUILayout.ExpandWidth(true));
			}

			useOverrideVariation.boolValue = GUILayout.Toggle(useOverrideVariation.boolValue, "Override Density Variation");
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.PropertyField(debug);

			serializedObject.ApplyModifiedProperties();
			AssetDatabase.SaveAssetIfDirty(defaults);
		}
	}
}
