using UnityEngine;
using System.Collections;
using UnityEditor;

[InitializeOnLoad]
public class ObjectArrayGenerator : EditorWindow {

	GameObject parentObject;
	GameObject obj = null;
	bool groupEnabled = false;
	int rowLength;
	int rowCount;
	int objectSpacing;
	bool generate;

	[MenuItem("Window/Object Array Generator")]
	public static void ShowWindow(){
		EditorWindow.GetWindow (typeof(ObjectArrayGenerator));
	}

	void OnGUI(){
		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		obj = EditorGUILayout.ObjectField ("Object", obj, typeof(GameObject), true) as GameObject;
		rowLength = EditorGUILayout.IntField ("Array Length", rowLength);
		rowCount = EditorGUILayout.IntField ("Array Width", rowCount);
		objectSpacing = EditorGUILayout.IntField ("Object Spacing", objectSpacing);

		if (GUILayout.Button ("Instantiate")) {
			Vector3 startLocation = new Vector3 ();
			InstantiateRowSeries (rowLength, rowCount, objectSpacing, startLocation);
		}
	}

	void InstantiateRowSeries(int length, int width, int spacing, Vector3 rowLocation){
		for (int i = 0; i < width; i++) {
			InstantiateRow (length, spacing, rowLocation);
			rowLocation = new Vector3 (rowLocation.x + spacing, rowLocation.y, rowLocation.z);
		}
	}

	void InstantiateRow(int length, int spacing, Vector3 instantiateLocation){
		for (int i = 0; i < length; i++) {
			GameObject newObj = (GameObject) PrefabUtility.InstantiatePrefab (obj);
			newObj.transform.position = instantiateLocation;
			instantiateLocation = new Vector3 (instantiateLocation.x, instantiateLocation.y, instantiateLocation.z + spacing);
		}
	}

}
