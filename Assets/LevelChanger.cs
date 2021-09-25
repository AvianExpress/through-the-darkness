using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private string levelToLoad;
    
    void Update(){
        if (Input.GetMouseButtonDown(2)){
            FadeToLevel("Game"); 
        }
    }

    public void FadeToLevel(string levelName){
        levelToLoad = levelName;
        animator.SetTrigger("Fade_out");
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene(levelToLoad);
    }
}
