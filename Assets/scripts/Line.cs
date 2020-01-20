using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line:MonoBehaviour {

	[SerializeField]private GameObject m_lineCircle=null;
	[SerializeField]private Emitter m_emitter=null;

	private Vector2 m_target;
	private GameObject[] m_lineCirclelist;
	private bool m_lineCirclesActive;

	private void Start() {
		
	}

	private void Update() {
		if(m_emitter.isMouseDown){
			if(m_lineCirclelist==null)m_lineCirclelist=CreateLineCircles(6);
			SetCirclesActive(m_lineCirclelist,true);

			Vector2 origin=m_emitter.origin;
			transform.position=origin;

			LayoutCircles(m_lineCirclelist,origin,m_emitter.mousePos);
		}else{
			SetCirclesActive(m_lineCirclelist,false);
		}
	}

	private void SetCirclesActive(GameObject[] circles,bool active){
		if(active==m_lineCirclesActive)return;
		m_lineCirclesActive=active;
		for(int i=0;i<circles.Length;i++){
			circles[i].SetActive(active);
		}
	}

	private void LayoutCircles(GameObject[]circles,Vector2 origin,Vector2 mousePos){
		float angle=m_emitter.angle;
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

	private GameObject[] CreateLineCircles(int count){
		GameObject[] list=new GameObject[count];
		for(int i=0;i<count;i++){
			GameObject lineCircle=Instantiate(m_lineCircle,transform) as GameObject;
			lineCircle.SetActive(true);
			list[i]=lineCircle;
		}
		return list;
	}

	public void SetPoints(Vector2 pt1,Vector2 pt2){
		transform.position=pt1;
		m_target=pt2;
	}

	private void OnDestroy() {
		m_lineCirclelist=null;
	}
}
