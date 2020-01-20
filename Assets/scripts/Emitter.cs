using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter:MonoBehaviour {

	[SerializeField]private Level m_level=null;
	[SerializeField]private Line m_line=null;

	private bool m_isMouseDown;
	private Vector2 m_origin;
	private float m_angle;
	private Vector2 m_mousePos;
	private List<GameObject> m_playerCircleList;

	private void Start() {
		m_origin=transform.position;
		
		//初始创建一个球
		GameObject playerCircle=m_level.CreatePlayerCircle(true,m_origin);
		
		m_playerCircleList=new List<GameObject>();
		m_playerCircleList.Add(playerCircle);
	}

	private void Update() {
		if(Input.GetMouseButtonDown(0)) {
			OnMouseDownHandler();
		} else if(Input.GetMouseButtonUp(0)) {
			OnMouseUpHandler();
		}

		if(m_isMouseDown){
			m_mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 dv=m_mousePos-m_origin;
			m_angle=Mathf.Atan2(dv.y>0?-dv.y:dv.y,dv.x);
			m_angle=Mathf.Clamp(m_angle,-170*Mathf.Deg2Rad,-20*Mathf.Deg2Rad);
		}
	}

	private void OnMouseDownHandler() {
		m_isMouseDown=true;
	}

	private void OnMouseUpHandler() {
		m_isMouseDown=false;

		EmitCircle();
	}

	private void EmitCircle(){
		GameObject circle=GetNearestCircle();
		if(circle!=null) {
			circle.transform.position = transform.position;
			Invoke(nameof(EmitCircle),0.5f);
		}
	}

	private GameObject GetNearestCircle(){
		int nearestID=-1;
		float minDistance=float.MaxValue;
		for(int i=0;i<m_playerCircleList.Count;i++){
			float d=Vector2.Distance(m_playerCircleList[i].transform.position,transform.position);
			if(d<minDistance) nearestID=i;
		}
		if(nearestID>-1){
			GameObject result=m_playerCircleList[nearestID];
			m_playerCircleList.RemoveAt(nearestID);
			return result;
		}
		return null;
	}

	private void OnDisable() {
		CancelInvoke(nameof(EmitCircle));
	}

	public bool isMouseDown{ get { return m_isMouseDown; } }
	public Vector2 origin{ get{return m_origin; } }
	public Vector2 mousePos { get { return m_mousePos; } }
	public float angle { get { return m_angle; } }
	
}
