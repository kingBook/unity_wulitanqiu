using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡类
/// <br>管理关卡内的对象。</br>
/// </summary>
public class Level:BaseMonoBehaviour{

	protected Game m_game;

	[SerializeField]private GameObject m_playerCircleGameObj=null;
	[SerializeField]private GameObject[] m_shapeList=null;
	private List<GameObject> m_runtimeShapeList;

	protected override void Start(){
		base.Start();
		m_game=App.instance.GetGame<Game>();
	}

	public GameObject CreatePlayerCircle(bool active){
		GameObject gameObj=Instantiate(m_playerCircleGameObj,transform);
		gameObj.SetActive(active);
		return gameObj;
	}
	public GameObject CreatePlayerCircle(bool active,Vector3 position){
		GameObject gameObj=Instantiate(m_playerCircleGameObj,transform);
		gameObj.SetActive(active);
		gameObj.transform.position=position;
		return gameObj;
	}

	private void CreateShape(){
		int ranID=Random.Range(0,m_shapeList.Length);
		GameObject shapePrefab=m_shapeList[ranID];
		GameObject gameObj=Instantiate(shapePrefab,transform);
		gameObj.SetActive(true);
		//gameObj.transform.position=
	}

	public void Victory(){
		
	}

	public void Failure(){
		
	}


	protected override void OnDestroy(){
		base.OnDestroy();
	}

}
