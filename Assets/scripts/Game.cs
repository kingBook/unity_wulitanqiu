using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	
	[SerializeField]
	private GameObject _gameContent;
	
	private void Start () {
		deactivateChildren();

		_gameContent.SetActive(true);
	}

	private void deactivateChildren(){
		int childCount=transform.childCount;
		for(int i=0;i<childCount;i++){
			var t=transform.GetChild(i);
			t.gameObject.SetActive(false);
		}
	}
	
	
}
