using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class EnemyCollider : MonoBehaviour
{

   [SerializeField] private GameObject _player;
   [SerializeField] private ParticleSystem _particles;
   [SerializeField] private float _restartBeforTime = 0.2f;
   [SerializeField] private AudioSource _deadAud;
   [SerializeField] private float _shakeMagnitude = 3f;
   [SerializeField] private float _roughness = 2f;
   [SerializeField] private float _fadeInTime = 0.08f;
   [SerializeField] private float _fadeOutTime = 0.5f;
   public static event Action OnDead;

    
   void OnTriggerEnter2D(Collider2D other)
       {
         
           if(other.gameObject.name == "Player")
            {
               _player.GetComponent<SpriteRenderer>().enabled = false;
               _player.GetComponent<PlayerMovement>()._canMove = false;
                CameraShaker.Instance.ShakeOnce(_shakeMagnitude, _roughness, _fadeInTime, _fadeOutTime);
               _deadAud.Play();
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
