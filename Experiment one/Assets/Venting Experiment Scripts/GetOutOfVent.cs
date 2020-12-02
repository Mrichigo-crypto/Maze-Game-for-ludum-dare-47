using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GetOutOfVent : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] vents;
    [SerializeField] private GameObject ventCamera,followCamera;
     private ControlVents index;


    private int currentIndex;

    
    void Start() 
    {
        index = GetComponent<ControlVents>();
    }
    
    void Update() 
    {
        
        currentIndex = index.GetIndex();
    }

    public void GettingOut()
    {
        player.transform.position = vents[currentIndex].transform.GetChild(1).position;
        player.SetActive(true);


        followCamera.SetActive(true); 
        ventCamera.SetActive(false);
    }
    
}
