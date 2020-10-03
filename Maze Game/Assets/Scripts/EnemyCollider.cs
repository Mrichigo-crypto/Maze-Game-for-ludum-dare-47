using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

   [SerializeField] private GameObject _player;
   

    
   void OnTriggerEnter2D(Collider2D other)
       {
         Debug.Log(other.gameObject.name);
           if(other.gameObject.name == "Player")
            {
              Destroy(_player , 0.2f);
            }
       }
}
