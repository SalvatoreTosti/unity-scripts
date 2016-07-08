using UnityEngine;
using System.Collections;
using UnityEditor;
[InitializeOnLoad]
public class ObjectArrayGenerator : EditorWindow {

	GameObject parentObject;
	GameObject obj = null;

	int rowLength;
	int rowCount;
	int objectSpacing;
	bool generate;

	bool verticalArray = false;
	int rowHeight;

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
		verticalArray = EditorGUILayout.BeginToggleGroup ("3D Array", verticalArray);
			rowHeight = EditorGUILayout.IntField ("Array Height",rowHeight);
		EditorGUILayout.EndToggleGroup ();

		if (GUILayout.Button ("Instantiate")) {
			Vector3 startLocation = new Vector3 ();
			if (verticalArray) {
				InstantiateRowStack (rowLength, rowCount, rowHeight, objectSpacing, startLocation);
			} else {
				InstantiateRowStack (rowLength, rowCount, 1, objectSpacing, startLocation);
			}
		}
	}
	void InstantiateRowStack(int length, int width, int height, int spacing, Vector3 setLocation){
		for (int i = 0; i < height; i++) {
			InstantiateRowSeries (length, width, spacing, setLocation);
			setLocation = new Vector3 (setLocation.x, setLocation.y + spacing, setLocation.z);
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
