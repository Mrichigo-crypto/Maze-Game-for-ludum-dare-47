using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
public class ControlVents : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _vents;
    [SerializeField] private MakeVentButtonVisible _index;
    [SerializeField] private CinemachineVirtualCamera _ventCamera;
    private bool _canVent;
    private int _currentIndex;
    

   

    void Start()
    {

      MakeVentButtonVisible.OnVenting += VentIndex;

     _index = GameObject.Find("Player").GetComponent<MakeVentButtonVisible>();
    }
    
    void Update()
    {
        _canVent = CanVent();
        
         if(_canVent)
          {
             MoveVents();
          }

          
   
        Debug.Log(_currentIndex);
    }


     void MoveVents()
     {

        if(Input.GetKeyDown(KeyCode.D))
          {
             if(_currentIndex == _vents.Length - 1)
               {
                 _currentIndex = 0;
               }
            
              else
                {
                   _currentIndex++;
                }
           
             _ventCamera.Follow = _vents[_currentIndex].transform;
             
          }

         else if(Input.GetKeyDown(KeyCode.A))
          {
             if(_currentIndex == 0)
               {
                 _currentIndex = _vents.Length - 1;
               }
            
              else
                {
                   _currentIndex--;
                }
           
             _ventCamera.Follow = _vents[_currentIndex].transform;
             
          }
     }

    bool CanVent()
    {
        if(_player.activeSelf == false)
           return true;
        else
           return false;
    }


    void VentIndex()
     {

         _currentIndex = _index.SetIndex();

     }

     public int GetIndex()
     {
        return _currentIndex;
     }
}

