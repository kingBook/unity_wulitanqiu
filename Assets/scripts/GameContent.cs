using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContent : MonoBehaviour {
	[SerializeField]
	private GameObject _playerCircleGameObj;
	[SerializeField]
	private GameObject[] _shapeList;
	private List<GameObject> _runtimeShapeList;

	private void Start() {
		
	}

	public GameObject createPlayerCircle(bool active){
		GameObject gameObj=Instantiate(_playerCircleGameObj,transform);
		gameObj.SetActive(active);
		return gameObj;
	}
	public GameObject createPlayerCircle(bool active,Vector3 position){
		GameObject gameObj=Instantiate(_playerCircleGameObj,transform);
		gameObj.SetActive(active);
		gameObj.transform.position=position;
		return gameObj;
	}

	private void createShape(){
		int ranID=Random.Range(0,_shapeList.Length);
		GameObject shapePrefab=_shapeList[ranID];
		GameObject gameObj=Instantiate(shapePrefab,transform);
		gameObj.SetActive(true);
		//gameObj.transform.position=
	}
	
	
}
