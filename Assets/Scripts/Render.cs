using UnityEngine;
using System.Collections;
using System.IO;

public class Render : MonoBehaviour
{
	public enum ImageType { PNG,JPEG };

	public string directoryName = "Export"; //name of directory where images will be stored
	public string filename = "capture"; //name for exported image
	public ImageType imageType = ImageType.PNG;

	//based on http://pixeland.io/guides/using-unity-for-rendering-isometric-tiles
	public void captureImage (string name)
	{
		StartCoroutine (captureImageCoroutine (name));	
	}

	private IEnumerator captureImageCoroutine (string name)
	{
		yield return new WaitForEndOfFrame ();

		int width = Camera.main.pixelWidth;
		int height = Camera.main.pixelHeight;

		Texture2D tex = new Texture2D (width, height, TextureFormat.ARGB32, false);
		tex.ReadPixels (new Rect (0, 0, width, height), 0, 0);
		tex.Apply ();

		byte[] bytes = null;
		string fileExtension = "";


		if (imageType == ImageType.PNG) {
			bytes = tex.EncodeToPNG ();
			Destroy (tex);
			fileExtension = ".png";
		} else if (imageType == ImageType.JPEG) {
			bytes = tex.EncodeToJPG ();
			Destroy (tex);
			fileExtension = ".jpg";
		} else {
			Debug.Log ("Unknown ImageType: " + imageType.ToString ());
			return false;
		}

		string path = Application.dataPath + "/../" + directoryName + "/" + name + "_" + System.DateTime.Now.ToFileTimeUtc () + fileExtension;
		if (!Directory.Exists (path)) {
			Directory.CreateDirectory (Application.dataPath + "/../" + directoryName);
		}

		File.WriteAllBytes (path, bytes);
	}


}
