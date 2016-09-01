using UnityEngine;
using System.Collections;

public class levelScriptObject : MonoBehaviour {

	private static string PERFAB_NAME = "UI\\textMenu";
	
	private string[] nameLevels;

	//Позиция начала рисования записей об уровне
	private Vector2 startPos = new Vector2(450f, 350f);

	//Позиция смещения
	private Vector2 deltaPos = new Vector2(120f, 40f);

	//Количество строк записей уровня
	private int countRow = 7;

	//Количество уровней
	public int countLevel = 10;


	// Use this for initialization
	void Start () {
		nameLevels = new string[countLevel];

		generateLevelName();

		generateLevelTextUI();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Проуедура генерирует и заполняет имена уровней по шаблону
	private void generateLevelName(){
		for(int i = 0; i < countLevel; i++){
			nameLevels[i] = "Уровень " + (i+1).ToString();
		}
	}

	//Процедура генерирует надписи на канвасе.
	private void generateLevelTextUI(){
		
		GameObject canvas = GameObject.Find("Canvas");
		if(canvas == null) {
			Debug.LogError("Canvas not found");
			return;
		}
		

		int col = 0;
		int numCol = 0;
		int numRow = 0;
		for(int i = 0; i < countLevel; i++, col++, numRow++){
			if(col >= countRow){
				col = 0;
				numCol++;
				numRow = 0;
			}
			Vector3 pos=  new Vector3();
			pos.x = startPos.x + numCol * deltaPos.x;
			pos.y = startPos.y - numRow * deltaPos.y;
			levelScriptObject.Create(pos, canvas.transform, nameLevels[i]);
		}
	}

	//Функция создания экземпляра объекта записи о уровне
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
}
