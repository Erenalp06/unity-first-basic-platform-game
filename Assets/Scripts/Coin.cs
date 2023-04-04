using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Collider2D collider2D;
    [SerializeField] AudioClip audioClip;

    public int score = 0;   

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Collectible")){            
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(audioClip, other.transform.position);
            score++;
            
        }
    }
}
