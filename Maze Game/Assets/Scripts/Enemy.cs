using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _breakTime = 0.3f;
    
    private Transform _currentWayPoint;
    private bool _goingForward;
    private int _size;
    private int _wpIndx;

    void Start()
    {      
        _size = _wayPoints.Length - 1;
    
    }

  
    void Update()
    {
        if(transform.position == _wayPoints[0].position)
         {
             StartCoroutine(Break());
            _wpIndx = 1;
            _currentWayPoint = _wayPoints[_wpIndx];
            _goingForward = true;
         }

        else if(transform.position == _wayPoints[_wpIndx].position && _wpIndx != _size)
         {
            if(_goingForward)
               {
                  
                  _wpIndx += 1;
                  _currentWayPoint = _wayPoints[_wpIndx];
               }
            else
               {
                  
                 _wpIndx -= 1;
                 _currentWayPoint = _wayPoints[_wpIndx];
               }
         } 

         else if(transform.position == _wayPoints[_size].position)
           {
              StartCoroutine(Break());
             _wpIndx -=1;
             _currentWayPoint = _wayPoints[_wpIndx];
              _goingForward = false;
           }

       transform.position = Vector2.MoveTowards(transform.position, _currentWayPoint.position, _enemySpeed * Time.deltaTime);
    }

    IEnumerator Break()
     {
       yield return new WaitForSeconds(_breakTime);
     }
       
}
