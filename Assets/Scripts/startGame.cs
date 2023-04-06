using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void startToGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        score.lives = 3;
        score.totalScore = 0;
    }
}
