using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _vInp;
    private float _hInp;
    private float _dashTime;
    private int _direction;
    private bool _isDashButtonDown;
    private bool _canDash;
    private int _dashCtr;

    [SerializeField] private LayerMask _dashMask;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _startDashTime;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject echo;
    [SerializeField] private float _shakeMagnitude;
    [SerializeField] private float _roughness;
    [SerializeField] private float _fadeInTime;
    [SerializeField] private float _fadeOutTime;
    [SerializeField] private bool _islevelfive;
    [SerializeField] private AudioSource _audio;
    public static event Func<bool> OnDash;
    public bool _canMove{get; set;}
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _dashTime = _startDashTime;
        this.GetComponent<SpriteRenderer>().enabled = true;
        _canDash = true;
         _canMove = true;
        
    }

    
    void Update()
    {
        _hInp = Input.GetAxis("Horizontal");
        _vInp = Input.GetAxis("Vertical");     
         if(_islevelfive)
           transform.position = new Vector2(Mathf.Clamp(transform.position.x, -22.4f, 22.4f ), Mathf.Clamp(transform.position.y, -12.6f , 12.6f));
        else
          transform.position = new Vector2(Mathf.Clamp(transform.position.x, -15.5f, 15.5f ), Mathf.Clamp(transform.position.y, -8.75f , 8.27f));

        if(Input.GetKeyDown(KeyCode.Space) && _canDash == true)
         {
        
            _isDashButtonDown = true;
            
            
            if(OnDash != null)
               _canDash = OnDash();            
     
           
         }   
               
        
    }
   
    
     void DashProperly()
     {
           
           GameObject instance = (GameObject)Instantiate(echo, transform.position, transform.rotation);
               
               Destroy(instance,3f);


     }

    
    void FixedUpdate()
    {

      var moveDir = new Vector3(_hInp , _vInp).normalized;
      if(_canMove)
        {
          _rb.velocity = moveDir * _speed;
        }

      if(_isDashButtonDown)
         {

             Vector3 dashPosition = transform.position + moveDir * _dashSpeed;
             CameraShaker.Instance.ShakeOnce(_shakeMagnitude, _roughness, _fadeInTime, _fadeOutTime);
             _audio.Play();
              DashProperly();
            
             RaycastHit2D raycasthit = Physics2D.Raycast(transform.position,moveDir,_dashSpeed , _dashMask);
              
             if(raycasthit.collider != null)
              {
                dashPosition = raycasthit.point;
                
              }
            _rb.MovePosition(dashPosition);
            _isDashButtonDown = false;
         }
         
    }
   
}
