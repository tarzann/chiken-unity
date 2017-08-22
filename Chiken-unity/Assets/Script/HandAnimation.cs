using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour {
	void Start(){

		//iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		iTween.ScaleTo(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		iTween.ScaleTo(gameObject, iTween.Hash("y", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}

	/*
	private float _currentScale = InitScale;
	private const float TargetScale = 3f;
	private const float InitScale = 2f;
	private const int FramesCount = 100;
	private const float AnimationTimeSeconds = 1;
	private float _deltaTime = AnimationTimeSeconds/FramesCount;
	private float _dx = (TargetScale - InitScale)/FramesCount;
	private bool _upScale = false;
	private int scaleCount = 0;

	private IEnumerator Breath()
	{
		
		while (true ) {
			while (_upScale) {
				_currentScale += _dx;
				if (_currentScale > TargetScale) {
					scaleCount++;
					_upScale = false;
					_currentScale = TargetScale;
				}
				transform.localScale = Vector3.one * _currentScale;
				yield return new WaitForFixedUpdate ();
			}

			while (!_upScale) {
				_currentScale -= _dx;
				if (_currentScale < InitScale) {
					scaleCount++;
					_upScale = true;
					_currentScale = InitScale;
				}
				transform.localScale = Vector3.one * _currentScale;
				yield return new WaitForFixedUpdate ();

			}
		}
	}
	private void Start()
	{
		StartCoroutine(Breath());
	}
	*/
}
