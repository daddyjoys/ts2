using UnityEngine;

namespace utils
{
    public class Timer
    {
    //**************************************************************
    // Регион с приватными реквезитами
    #region

        // Время до следующего срабатывания таймера
        private float timeByEvent;

        // Ссылка на делегат обработчика события таймера
        private eventTimer m_Event;

        // Флаг законченности таймера
        private bool m_IsEnd = false;

    #endregion
    //**************************************************************

    //**************************************************************
    // Регион с публичными методами
    #region

        // Объявление делегата на обработчик события
        public delegate void eventTimer();
		
        // Функция проверки законченности таймера
        public bool isEnd(){
            return m_IsEnd;
        }

        // Конструктор
		public Timer(float time, eventTimer e){
            this.timeByEvent = time;
            this.m_Event = e;
        }

        // Обработчик кадра. вызывается из класса timerManager
        public void update(float deltaTime){
            Debug.Log("this.timeByEvent " + this.timeByEvent);
            this.timeByEvent -= deltaTime;
            if(this.timeByEvent <= 0){
                onEvent();
            }
        }
        
    #endregion
    //**************************************************************

    //**************************************************************
    // Регион с приватными методами
    #region

        // Обработчик завершения таймера
        private void onEvent(){
            m_IsEnd = true;
            this.m_Event();
        }

    #endregion
    //**************************************************************
    }
}
