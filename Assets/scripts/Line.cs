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
	private bool _lineCirclesActive;

	private void Start() {
		
	}

	private void Update() {
		if(_emitter.isMouseDown){
			if(_lineCirclelist==null)_lineCirclelist=createLineCircles(6);
			setCirclesActive(_lineCirclelist,true);

			Vector2 origin=_emitter.origin;
			transform.position=origin;

			layoutCircles(_lineCirclelist,origin,_emitter.mousePos);
		}else{
			setCirclesActive(_lineCirclelist,false);
		}
	}

	private void setCirclesActive(GameObject[] circles,bool active){
		if(active==_lineCirclesActive)return;
		_lineCirclesActive=active;
		for(int i=0;i<circles.Length;i++){
			circles[i].SetActive(active);
		}
	}

	private void layoutCircles(GameObject[]circles,Vector2 origin,Vector2 mousePos){
		float angle=_emitter.angle;
		Vector2 dv=mousePos-origin;
		float distance=Mathf.Max(dv.magnitude,1);
		float space=distance/circles.Length;
		float scale=Mathf.Min(distance/1,1.5f);
		for(int i=0;i<circles.Length;i++){
			//set distance
			float c=i*space+0.2f;
			Vector2 offset=new Vector2(Mathf.Cos(angle)*c,Mathf.Sin(angle)*c);
			circles[i].transform.position=origin+offset;
			//set scale
			circles[i].transform.localScale=new Vector2(scale,scale);
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
		_lineCirclelist=null;
	}
}
