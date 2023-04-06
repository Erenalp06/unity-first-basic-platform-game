using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    private Collider2D collider2D;
    [SerializeField] AudioClip audioClip;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    

    

    
   
    
    void Awake()
    {
        textMeshProUGUI.SetText(score.totalScore.ToString());
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Collectible")){            
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(audioClip, other.transform.position);
            score.totalScore++;
            textMeshProUGUI.SetText(score.totalScore.ToString());
            
            
        }
    }
}
