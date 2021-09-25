using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTheGame : MonoBehaviour
{
    
        public void PlayGame(){
            SceneManager.LoadScene("Game");
        }
         public void ExitGame(){
            Application.Quit();
        }

}
