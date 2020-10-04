using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    [SerializeField] private float _transitionTime = 1f;  
    [SerializeField] private Animator _anim; 
    
 

    
   
    void OnEnable()
    { 
      EnemyCollider.OnDead += Restart;
      UIManager.OnTimeOver += Restart;
      
    }
    void OnDisable()
    {
      EnemyCollider.OnDead -= Restart;
      UIManager.OnTimeOver -= Restart;
    }
    
    void Restart()
     {
         
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex));     
        StopCoroutine(Transition(SceneManager.GetActiveScene().buildIndex));
     }

     IEnumerator Transition(int levelIndex)
     {
        _anim.Play("CrossFade_End");
        yield return new WaitForSeconds(_transitionTime);   
        SceneManager.LoadScene(levelIndex);

     }
     
}
