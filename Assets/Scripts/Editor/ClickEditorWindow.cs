using UnityEngine;
using System.Collections;
using UnityEditor;

[InitializeOnLoad]
public class ClickEditorWindow : EditorWindow {
	[MenuItem("Window/Click Tracking Window")]
	public static void ShowWindow(){
		EditorWindow.GetWindow (typeof(ClickEditorWindow));
	}

	void OnSceneGUI(SceneView scene)
	{
		if (Event.current.type == EventType.mouseDown) {
			Vector3 mouseClick = HandleUtility.GUIPointToWorldRay (Event.current.mousePosition).origin;
			Debug.Log ("Click: " + mouseClick);
		}
	}

	void OnEnable()
	{
		SceneView.onSceneGUIDelegate += this.OnSceneGUI;
	}
	void OnDisable()
	{
		SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
	} 
}
