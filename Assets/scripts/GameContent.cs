using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContent : MonoBehaviour {
	[SerializeField]
	private GameObject _playerCircleGameObj;	

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
	
}
