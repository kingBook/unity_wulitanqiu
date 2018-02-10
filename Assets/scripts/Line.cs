using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line:MonoBehaviour {
	[SerializeField]
	private GameObject _lineCircle;
	[SerializeField]
	private Emitter _emitter;
	private Vector2 _target;
	private GameObject[] _lineCirclelist;

	private void Start() {
		
	}

	private void Update() {
		if(_emitter.isMouseDown){
			if(_lineCirclelist==null)_lineCirclelist=createLineCircles(5);

			Vector2 origin=_emitter.origin;
			Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Vector2 dv=mousePos-origin;
			float length=dv.magnitude;
		}
	}

	private GameObject[] createLineCircles(int count){
		GameObject[] list=new GameObject[count];
		for(int i=0;i<count;i++){
			GameObject lineCircle=Instantiate(_lineCircle,transform) as GameObject;
			lineCircle.SetActive(true);
			list[i]=lineCircle;
		}
		return list;
	}

	public void setPoints(Vector2 pt1,Vector2 pt2){
		transform.position=pt1;
		_target=pt2;
	}

	private void OnDestroy() {

	}
}
