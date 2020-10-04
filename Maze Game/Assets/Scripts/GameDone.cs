using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameDone : MonoBehaviour
{
   [SerializeField] private float _transitionTime = 1f;  
   [SerializeField] private Animator _anim; 

   void OnTriggerEnter2D(Collider2D other)
       {
         
           if(other.gameObject.name == "Player")
            {
               
              StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex+1));
              
            }

          IEnumerator ChangeScene(int levelIndex)
           {
             _anim.Play("swipeStart");
             yield return new WaitForSeconds(_transitionTime);   
              SceneManager.LoadScene(levelIndex);
           }
       }
}
