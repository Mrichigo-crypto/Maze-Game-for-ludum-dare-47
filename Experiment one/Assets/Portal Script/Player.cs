using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
       
    }

    void FixedUpdate()
    {
       Movement();
       Rotate();
        
    }

    void Movement()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _vertical * _speed);
    }

    void Rotate()
     {
       if(_horizontal > 0.1f)
       {
        
         var right = Quaternion.Euler(0,0,-90);
         transform.rotation = Quaternion.Slerp(transform.rotation , right, Time.deltaTime * _rotationSpeed);
       }
    
      else if(_horizontal < -0.1f)
      {
         var left = Quaternion.Euler(0,0,90);
         transform.rotation = Quaternion.Slerp(transform.rotation , left , Time.deltaTime * _rotationSpeed);
      }
        
      if(_vertical > 0.1f)
       {
          var up = Quaternion.Euler(0,0,0);
         transform.rotation = Quaternion.Slerp(transform.rotation , up, Time.deltaTime * _rotationSpeed);
       }
 
       else if(_vertical < -0.1f)
      {
         var down = Quaternion.Euler(0,0,180);
         transform.rotation = Quaternion.Slerp(transform.rotation , down , Time.deltaTime * _rotationSpeed);
      }
     }
}
