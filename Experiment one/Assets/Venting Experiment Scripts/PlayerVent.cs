using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerVent : MonoBehaviour
{
    [SerializeField] private GameObject _player; 
    [SerializeField] private GameObject _followCamera;
    [SerializeField] private GameObject _ventCamera;   

    public static event Action OnPlayerVentEvent;

    public void PlayerGoesInVent()
    {
      _player.SetActive(false);
      _followCamera.SetActive(false); 
      _ventCamera.SetActive(true);

      if(OnPlayerVentEvent != null)
         OnPlayerVentEvent();
        
    }
}
