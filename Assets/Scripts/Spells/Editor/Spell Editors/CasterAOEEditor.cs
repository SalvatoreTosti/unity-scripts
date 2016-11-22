using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(CasterAOE))]

public class CasterAOEEditor : Editor
{
	public bool showMissProperties = false;
	public bool showCasterEffects = false;
	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();
		var script = target as CasterAOE;
		SerializedObject so = new SerializedObject(target);
		SerializedProperty targetEffects = so.FindProperty ("targetEffects");
		EditorGUILayout.PropertyField (targetEffects,true);

		showCasterEffects = GUILayout.Toggle (showCasterEffects,"Caster Effects");
		if (showCasterEffects) {
			SerializedProperty casterEffects = so.FindProperty ("casterEffects");
			EditorGUILayout.PropertyField (casterEffects, true);
		} else {
			script.casterEffects = null;
		}

		SerializedProperty range = so.FindProperty ("range");
		EditorGUILayout.PropertyField (range,true);

		SerializedProperty targetTags = so.FindProperty ("targetTags");
		EditorGUILayout.PropertyField (targetTags,true);

		SerializedProperty targetType = so.FindProperty ("targetType");
		EditorGUILayout.PropertyField (targetType,true);

		if (script.targetType == CasterAOE.TARGET_TYPE.TARGET_RANDOM) {
			script.maxRandomTargets = EditorGUILayout.IntField ("Number Of Targets", script.maxRandomTargets);
		}

		SerializedProperty includeCaster = so.FindProperty ("includeCaster");
		EditorGUILayout.PropertyField (includeCaster,true);
		so.ApplyModifiedProperties();

		showMissProperties = GUILayout.Toggle (showMissProperties,"On Miss Effects");
		if (showMissProperties) {
			SerializedProperty missTargetEffects = so.FindProperty ("missTargetEffects");
			EditorGUILayout.PropertyField (missTargetEffects, true);

			SerializedProperty missCasterEffects = so.FindProperty ("missCasterEffects");
			EditorGUILayout.PropertyField (missCasterEffects, true);

			so.ApplyModifiedProperties ();
		} else {
			script.missTargetEffects = null;
			script.missCasterEffects = null;
		}

	}
}
