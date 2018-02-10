using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter:MonoBehaviour {
	[SerializeField]
	private Line _line;

	private bool _isMouseDown;
	private Vector2 _origin;

	private void Start() {
		_origin=transform.position;
	}

	private void Update() {
		if(Input.GetMouseButtonDown(0)) {
			onMouseDownHandler();
		} else if(Input.GetMouseButtonUp(0)) {
			onMouseUpHandler();
		}

		if(_isMouseDown){
		}
	}

	private void onMouseDownHandler() {
		_isMouseDown=true;
	}

	private void onMouseUpHandler() {
		_isMouseDown=false;
	}

	public bool isMouseDown{ get { return _isMouseDown; } }

	public Vector2 origin{ get{return _origin;} }
	
}
