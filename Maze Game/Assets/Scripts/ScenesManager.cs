using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    [SerializeField] private Animator _anim; 
    [SerializeField] private float _transitionTime = 1f; 
    
    // Update is called once per frame
    void Update()
    {
        
    }


    public void NextScene()
    {
      StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex + 1));   
    }
   
    IEnumerator Transition(int levelIndex)
     {
        _anim.Play("swipeStart");
        yield return new WaitForSeconds(_transitionTime);   
        SceneManager.LoadScene(levelIndex);

     }

    public void MainMenu()
    {
      StartCoroutine(Transition2());
    }

    IEnumerator Transition2()
     {
        _anim.Play("swipeStart");
        yield return new WaitForSeconds(_transitionTime);   
        SceneManager.LoadScene(0);

     }
    public void QuitGame()
    {
       Application.Quit();
    }
}
