using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

   [SerializeField] private float _rotSpeed = 3f;
  
   
    
    void Start()
    {
        
    }

    
    void Update()
    {
       float inp = Input.GetAxis("Horizontal");
       float inpVer = Input.GetAxis("Vertical");
 
       if(inp > 0.1f)
       {
        
         var right = Quaternion.Euler(0,0,-90);
         transform.rotation = Quaternion.Slerp(transform.rotation , right, Time.deltaTime * _rotSpeed);
       }
    
      else if(inp < -0.1f)
      {
         var left = Quaternion.Euler(0,0,90);
         transform.rotation = Quaternion.Slerp(transform.rotation , left , Time.deltaTime * _rotSpeed);
      }
        
      if(inpVer > 0.1f)
       {
          var up = Quaternion.Euler(0,0,0);
         transform.rotation = Quaternion.Slerp(transform.rotation , up, Time.deltaTime * _rotSpeed);
       }
 
       else if(inpVer < -0.1f)
      {
         var down = Quaternion.Euler(0,0,180);
         transform.rotation = Quaternion.Slerp(transform.rotation , down , Time.deltaTime * _rotSpeed);
      }

         
    }
} 
