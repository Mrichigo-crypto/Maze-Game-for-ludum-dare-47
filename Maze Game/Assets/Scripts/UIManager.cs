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
    [SerializeField] private TextMeshProUGUI _dashLeft;
    [SerializeField] private Color _red;
    [SerializeField] private Color _green;
    [SerializeField] private Image _img;
    [SerializeField] private float _gameTime;
    [SerializeField] private float _time;
    [SerializeField] private int _totalDash;
    private bool _stopTimer;
    private bool _canRestart;
    private int _dashCtr;
    public static event Action OnTimeOver;
    
   
   
    void OnEnable()
    {
    
        PlayerMovement.OnDash += dashAmount;
     
       _dashCtr = _totalDash;
       _stopTimer = false;
 
      _timerSlider.maxValue = _gameTime;
      _timerSlider.value = _gameTime;
           
      _time = _gameTime;
      _img.color = _green;

      _dashLeft.SetText("Dash Left: " + _totalDash);


    }
    void OnDisable()
     {
         
       PlayerMovement.OnDash -= dashAmount;
     }
    void Update()
     {
       Timer();
          
     }

     void Timer()
      {
         if(_time != 0)
             _time -= Time.deltaTime;
            
           else
              _time = _gameTime;

           int minutes = Mathf.FloorToInt(_time / 60);
           int seconds = Mathf.FloorToInt(_time - minutes * 60);
      
           

         if(_time <= 0)
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

     bool dashAmount()
      {
          _dashCtr--;
         
          _dashLeft.SetText("Dash Left: " + _dashCtr);

          if(_dashCtr <= 0)
            return false;
        
         return true;
     }
}
