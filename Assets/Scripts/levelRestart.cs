using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelRestart : MonoBehaviour
{
    
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(CharacterController.Instance!= null){
                CharacterController.Instance.hurted = true;
                print("hurted" + CharacterController.Instance.hurted);
                
            }
            AudioManager.Instance.PlaySFX("character-dead");
            AudioManager.Instance.musicSource.mute = true;
            score.lives--;
            score.totalScore = 0;
            print(score.lives);
            StartCoroutine(WaitForSecondMethod());

        }
    }



    IEnumerator WaitForSecondMethod(){
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
