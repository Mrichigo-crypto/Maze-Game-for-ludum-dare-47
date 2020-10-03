using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _vInp;
    private float _hInp;
    [SerializeField] private float _speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _hInp = Input.GetAxis("Horizontal");
        _vInp = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
      _rb.velocity = new Vector2(_hInp * _speed , _vInp * _speed);
    }
}
