using UnityEngine;
using System.Collections;

public class levelScriptObject : MonoBehaviour {

	//Путь к перфабу надписи УИ
	private static string PERFAB_NAME = "UI\\textMenu";
	
	//Массив хранения надписей уровней
	private string[] nameLevels;

	//Массив хранения гровых объектов уровней
	private GameObject[] levelsUI;

	//Позиция начала рисования записей об уровне
	private Vector2 startPos = new Vector2(450f, 350f);

	//Позиция смещения
	private Vector2 deltaPos = new Vector2(120f, 40f);

	//Количество строк записей уровня
	private int countRow = 7;

	private int numSelectLevelUI = 0;
	//Количество уровней
	public int countLevel = 10;


	// Use this for initialization
	void Start () {
		nameLevels = new string[countLevel];
		levelsUI = new GameObject[countLevel];

		generateLevelName();

		generateLevelTextUI();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			nextLevel();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			prevLevel();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			nextLevelPage();
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			prevLevelPage();
		}
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
			GameObject newGO = levelScriptObject.Create(pos, canvas.transform, nameLevels[i]);
			levelsUI[i] = newGO;
		}

		selectLevelUI(0);
	}

	//Выделить уровень по индексу
	private void selectLevelUI(int numLevel){

		GameObject cursor = GameObject.Find("cursor");
		if(cursor == null) {
			Debug.LogError("cursor not found");
			return;
		}

		Vector3 cPos = levelsUI[numLevel].transform.position;
		cPos.x -= 100;
		cPos.y += 10;
		cursor.transform.position = cPos;
	}

	//Выделить следующий уровень
	private void nextLevel(){
		numSelectLevelUI++;
		if(numSelectLevelUI >= countLevel){
			numSelectLevelUI = 0;
		}
		selectLevelUI(numSelectLevelUI);
	}

	//Выделить предыдущий уровень
	private void prevLevel(){
		numSelectLevelUI--;
		if(numSelectLevelUI < 0){
			numSelectLevelUI = countLevel - 1;
		}
		selectLevelUI(numSelectLevelUI);
	}


	//следующая страница уровня
	private void nextLevelPage(){
		numSelectLevelUI += countRow;
		if(numSelectLevelUI >= countLevel){
			numSelectLevelUI = numSelectLevelUI - countLevel;
		}
		selectLevelUI(numSelectLevelUI);
	}

	//предыдущая страница уровня
	private void prevLevelPage(){
		numSelectLevelUI -= countRow;
		if(numSelectLevelUI < 0){
			numSelectLevelUI = numSelectLevelUI + countLevel;
		}
		selectLevelUI(numSelectLevelUI);
	}

	//Функция создания экземпляра объекта записи о уровне
	public static GameObject Create(
		Vector3 pos, 
		Transform parent, 
		string text){

		
		UnityEngine.Object res = Resources.Load(PERFAB_NAME);

		if(res == null){
			Debug.LogError("Resource \"" + PERFAB_NAME + "\" not loaded");
			return null;
		}

		GameObject newGO = Instantiate(res, pos, Quaternion.identity) as GameObject;
		
		newGO.transform.parent = parent;

		UnityEngine.UI.Text t = newGO.GetComponent<UnityEngine.UI.Text>();
		if(t == null){
			Debug.LogError("Text not found in GO " + newGO.name);
			return null;
		}
		t.text = text;

		return newGO;
	}
}
