using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    [SerializeField] private float _transitionTime = 1f;
    
    [SerializeField] private Animator _anim;
    
   
    void OnEnable()
    { 
      EnemyCollider.OnDead += Restart;
    }
    void OnDisable()
    {
      EnemyCollider.OnDead -= Restart;
    }
   
    void Restart()
     {
       
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex));
     }

     IEnumerator Transition(int levelIndex)
     {
        yield return new WaitForSeconds(_transitionTime);  
       _anim.Play("CrossFade_End"); 
       SceneManager.LoadScene(levelIndex);

     }
     
}
