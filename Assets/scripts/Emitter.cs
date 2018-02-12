using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter:MonoBehaviour {
	[SerializeField]
	private Line _line;
	[SerializeField]
	private GameContent _gameContent;

	private bool _isMouseDown;
	private Vector2 _origin;
	private float _angle;
	private Vector2 _mousePos;
	private List<GameObject> _playerCircleList;

	private void Start() {
		_origin=transform.position;
		
		//初始创建一个球
		GameObject playerCircle=_gameContent.createPlayerCircle(true,_origin);
		
		_playerCircleList=new List<GameObject>();
		_playerCircleList.Add(playerCircle);
	}

	private void Update() {
		if(Input.GetMouseButtonDown(0)) {
			onMouseDownHandler();
		} else if(Input.GetMouseButtonUp(0)) {
			onMouseUpHandler();
		}

		if(_isMouseDown){
			_mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 dv=_mousePos-_origin;
			_angle=Mathf.Atan2(dv.y>0?-dv.y:dv.y,dv.x);
			_angle=Mathf.Clamp(_angle,-170*Mathf.Deg2Rad,-20*Mathf.Deg2Rad);
		}
	}

	private void onMouseDownHandler() {
		_isMouseDown=true;
	}

	private void onMouseUpHandler() {
		_isMouseDown=false;
	}

	public bool isMouseDown{ get { return _isMouseDown; } }
	public Vector2 origin{ get{return _origin; } }
	public Vector2 mousePos { get { return _mousePos; } }
	public float angle { get { return _angle; } }
	
}
