using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

   [SerializeField] private GameObject _player;
   [SerializeField] private ParticleSystem _particles;
   [SerializeField] private float _restartBeforTime = 0.2f;
   public static event Action OnDead;

    
   void OnTriggerEnter2D(Collider2D other)
       {
         
           if(other.gameObject.name == "Player")
            {
               _player.GetComponent<SpriteRenderer>().enabled = false;
              _particles.Play();
              
              StartCoroutine(dead());
              
            }
       }

   IEnumerator dead()
   { 
      yield return new WaitForSeconds(_restartBeforTime);

         Debug.Log("Restarting");
           if(OnDead != null)
                 OnDead();

   }
}
