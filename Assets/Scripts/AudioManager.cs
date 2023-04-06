using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioSource;
    [SerializeField]CharacterController controller;
    private bool isPlaying;

    private Animator animator;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        isPlaying = true;
        audioSource.Play();
             
        
    }

    public void MuteAudio(){      
        if(!isPlaying){
            isPlaying = true;
        }else{
            isPlaying = false;
        }
        print("isPlaying : " + isPlaying);
        
    }
    
    
    void Update()
    {
        //print(isPlaying);
        if(controller!=null){
            if(controller.hurted){
            audioSource.mute = true;
            
        }
        }
        
        
    }
    
}
