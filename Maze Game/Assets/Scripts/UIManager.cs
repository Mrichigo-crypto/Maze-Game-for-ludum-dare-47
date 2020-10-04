using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider  _timerSlider;   
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private Color _red;
    [SerializeField] private Color _green;
    [SerializeField] private Image _img;
    [SerializeField] private float _gameTime;
    [SerializeField] private float _time;
    private bool _stopTimer;
    private bool _canRestart;
    public static event Action OnTimeOver;
    
    void Start()
    {
       

    }
   
    void OnEnable()
    {
       _stopTimer = false;
 
      _timerSlider.maxValue = _gameTime;
      _timerSlider.value = _gameTime;
           
      _time = _gameTime;
      _img.color = _green;
    }

    void Update()
     {

         
           if(_time != 0)
             _time -= Time.deltaTime;
            
           else
              _time = _gameTime;

           int minutes = Mathf.FloorToInt(_time / 60);
           int seconds = Mathf.FloorToInt(_time - minutes * 60);
      
           

         if(seconds <= 0)
         {
             _stopTimer = true;
             
             _canRestart = true;
              
          }

         if(_stopTimer == false)
           {
               _canRestart = false;
              _timeText.SetText(seconds + " sec");
              _timerSlider.value = _time;
           }

         if(seconds <= 10)
           {      
                _img.color = _red;
           }

           if(_canRestart == true)
             {
               restartGame();
               _canRestart = false;
             }
     }

      void restartGame()
       {
            if(OnTimeOver != null)
               OnTimeOver();
       }
}
