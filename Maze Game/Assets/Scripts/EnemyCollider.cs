using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

   [SerializeField] private GameObject _player;
   [SerializeField] private ParticleSystem _particles;
   public static event Action OnDead;

    
   void OnTriggerEnter2D(Collider2D other)
       {
         
           if(other.gameObject.name == "Player")
            {
              Destroy(_player , 0.08f);
              _particles.Play();
              
              
              if(OnDead != null)
                 OnDead();
            }
       }
}
