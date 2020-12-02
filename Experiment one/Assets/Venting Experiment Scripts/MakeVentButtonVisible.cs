using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using System;
public class MakeVentButtonVisible : MonoBehaviour
{

   [SerializeField] private GameObject _ventButton;
   [SerializeField] private CinemachineVirtualCamera _ventCamera;
   [SerializeField] private GameObject _indexObject;
    
    public static event Action OnVenting;

    void OnTriggerEnter2D(Collider2D other)
    {
        _indexObject = other.gameObject;
        _ventCamera.Follow = other.gameObject.transform;
        _ventButton.SetActive(true);
        
         if(OnVenting != null)
            OnVenting();
        

    }

    void OnTriggerExit2D(Collider2D other)
    {
         _ventButton.SetActive(false);
    }

     void Update()
     {
         SetIndex();
     }

    public int SetIndex()
    {
       
        if(_indexObject.name == "Vent 1")
           return 0;

        else if(_indexObject.name == "Vent 2")
           return 1;

        else if(_indexObject.name == "Vent 3")
           return 2;

        else if(_indexObject.name == "Vent 4")
           return 3;

        else if(_indexObject.name == "Vent 5")
           return 4;

        else return 5;
         
    }
 
}
