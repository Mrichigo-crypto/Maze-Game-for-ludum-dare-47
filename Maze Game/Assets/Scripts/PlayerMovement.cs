using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _vInp;
    private float _hInp;
    private bool _spaceInp;
    [SerializeField] private float _speed;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _hInp = Input.GetAxis("Horizontal");
        _vInp = Input.GetAxis("Vertical");
        _spaceInp = Input.GetKeyDown(KeyCode.Space);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -12.43f, 12.38f ), Mathf.Clamp(transform.position.y, -6.9f , 6.7f));
    }

    void FixedUpdate()
    {
      _rb.velocity = new Vector2(_hInp * _speed , _vInp * _speed);

      if(_spaceInp)
       {
          _rb.AddRelativeForce(new Vector2(_rb.velocity.x * _speed * 2,_rb.velocity.y * _speed * 2), ForceMode2D.Force);
       }
    }
}
