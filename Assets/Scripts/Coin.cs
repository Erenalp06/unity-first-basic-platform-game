using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    
    private Collider2D collider2D;    
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    

    

    
   
    
    void Awake()
    {
        textMeshProUGUI.SetText(score.totalScore.ToString());
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Collectible")){            
            Destroy(other.gameObject);
            AudioManager.Instance.PlaySFX("collectible");
            score.totalScore++;
            textMeshProUGUI.SetText(score.totalScore.ToString());
            
            
        }
    }
}
