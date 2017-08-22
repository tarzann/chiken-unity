using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {

	public static float pixelToUnits = 0.2f;
	public static float scale = 1f;

	//real resolution that we design the game to
	//public Vector2 nativeResolution = new Vector2 (240, 160);
	public Vector2 nativeResolution = new Vector2 (1440, 2560);

	void Awake () {
		var camera = GetComponent<Camera> ();

		if (camera.orthographic) {

			scale = Screen.height / nativeResolution.y;
			pixelToUnits *= scale;
			camera.orthographicSize = (Screen.height / 2.0f) / pixelToUnits;
		}
	}

}
