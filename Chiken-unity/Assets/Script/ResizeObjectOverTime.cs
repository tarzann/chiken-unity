using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeObjectOverTime : MonoBehaviour {

	private float _currentScale = InitScale;
	private const float TargetScale = 1.4f;
	private const float InitScale = 1f;
	private const int FramesCount = 100;
	private const float AnimationTimeSeconds = 3;
	private float _deltaTime = AnimationTimeSeconds/FramesCount;
	private float _dx = (TargetScale - InitScale)/FramesCount;
	private bool _upScale = false;
	private int scaleCount = 0;

	private IEnumerator Breath()
	{
		while (scaleCount < 2) {
			//while (true ) {
				while (_upScale) {
					_currentScale += _dx;
					if (_currentScale > TargetScale) {
						scaleCount++;
						_upScale = false;
						_currentScale = TargetScale;
					}
					transform.localScale = Vector3.one * _currentScale;
					yield return new WaitForSeconds (_deltaTime);
				}

				while (!_upScale) {
					_currentScale -= _dx;
					if (_currentScale < InitScale) {
						scaleCount++;
						_upScale = true;
						_currentScale = InitScale;
					}
					transform.localScale = Vector3.one * _currentScale;
					yield return new WaitForSeconds (_deltaTime);
				}
		//	}
			print ("scaleCount = " + scaleCount);
		}
	}
	private void Start()
	{
		StartCoroutine(Breath());
	}
}
