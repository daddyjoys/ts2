using UnityEngine;
using System.Collections;

namespace utils
{
	public class timerManager : MonoBehaviour {

	//**************************************************************
	// Регион с приватными реквезитами
	#region

		private ArrayList timerList;
	
	#endregion
	//**************************************************************
	
	//**************************************************************
	// Регион с публичными методами
	#region

		// Процедура создания таймера
		public void createTimer(float time, Timer.eventTimer e){
			Timer t = new Timer(time / 1000, e);
			timerList.Add(t);
		}
	#endregion
	//**************************************************************
	
	//**************************************************************
	// Регион для работы с обработчиками
	#region

		// Use this for initialization
		void Start () {
			timerList = new ArrayList();

			// Тестовый вызов таймера
			//createTimer(1000, delegate(){
			//	Debug.Log("createTimer(10, delegate(){");
			//});
		}
		
		// Update is called once per frame
		void Update () {

			// Для хранения таймеров на удаление
			ArrayList timerDelete = new ArrayList();

			// Обработка таймеров
			foreach (Timer t in timerList){
				t.update(Time.deltaTime);

				if(t.isEnd())
					timerDelete.Add(t);
			}

			// Удаляем выбранные таймеры из массива
			foreach (Timer t in timerDelete){
				timerList.Remove(t);
			}

			// Очищаем таймеры на удаление
			timerDelete.Clear();
		}

	#endregion
	//**************************************************************
	}
}
