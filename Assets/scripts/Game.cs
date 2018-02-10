using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	[SerializeField]
	private Emitter _emitter;

	private bool _isMouseDown;
	private void Start () {
		
	}
	
	private void Update () {
		if(Input.GetMouseButtonDown(0)){
			onMouseDownHandler();
		}else if(Input.GetMouseButtonUp(0)){
			onMouseUpHandler();
		}

	}

	private void onMouseDownHandler() {
		_isMouseDown=true;
	}

	private void onMouseUpHandler() {
		_isMouseDown=false;
	}
}
