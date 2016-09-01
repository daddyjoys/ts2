using UnityEngine;
using System.Collections;

public class levelScriptObject : MonoBehaviour {

	public static string PERFAB_NAME = "UI\\textMenu";
	public static void Create(
		Vector3 pos, 
		Transform parent, 
		string text){

		
		UnityEngine.Object res = Resources.Load(PERFAB_NAME);

		if(res == null){
			Debug.LogError("Resource \"" + PERFAB_NAME + "\" not loaded");
			return;
		}

		GameObject newGO = Instantiate(res, pos, Quaternion.identity) as GameObject;
		
		newGO.transform.parent = parent;

		UnityEngine.UI.Text t = newGO.GetComponent<UnityEngine.UI.Text>();
		if(t == null){
			Debug.LogError("Text not found in GO " + newGO.name);
			return;
		}
		t.text = text;
	}
	// Use this for initialization
	void Start () {
		//1. добавим надпись о уровне программно

		GameObject canvas = GameObject.Find("Canvas");
		if(canvas == null) {
			Debug.LogError("Canvas not found");
			return;
		}
		
		levelScriptObject.Create(new Vector3(450, 350, 0), canvas.transform, "level 1");

		levelScriptObject.Create(new Vector3(450, 330, 0), canvas.transform, "level 2");

		levelScriptObject.Create(new Vector3(450, 310, 0), canvas.transform, "level 3");
		
		levelScriptObject.Create(new Vector3(450, 290, 0), canvas.transform, "level 4");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
