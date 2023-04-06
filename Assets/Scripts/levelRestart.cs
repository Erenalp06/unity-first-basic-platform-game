using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelRestart : MonoBehaviour
{
    [SerializeField]CharacterController characterController;
    [SerializeField] AudioClip audioClip;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(characterController!= null){
                characterController.hurted = true;
                
            }
            AudioSource.PlayClipAtPoint(audioClip, characterController.transform.position);
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
