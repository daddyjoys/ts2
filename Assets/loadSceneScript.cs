using UnityEngine;
using System.Collections;

public class loadSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("startLEvel");
	}
	
	IEnumerator startLEvel(){
		AsyncOperation async = Application.LoadLevelAsync("test");
		while(!async.isDone){
			float p = async.progress * 100f;
			int r = Mathf.RoundToInt(p);
			Debug.Log("Загрузка ... " + r);
			yield return true; 
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
