using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int sound=0;
    
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private bool isPlaying;

    private Animator animator;

    public static AudioManager Instance;

    
    void Awake()
    {
        
        if(Instance == null){
            Instance = this;
            
        }
    }

    
    void Start()
    {
        if(sound == 0){
            PlayMusic("theme1");
            
        }else if(sound == 1){
            PlayMusic("theme2");
        }
        
    }

    public void PlayMusic(string name){
        Sound s = Array.Find(musicSounds, x => x.soundName == name);
        if(s == null){
            Debug.Log("Sound Not Found");
        }else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name){
        Sound s = Array.Find(sfxSounds, x => x.soundName == name);
        if(s == null){
            Debug.Log("Sound Not Found");
        }else{
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic(){    
        print(musicSource.mute);    
        musicSource.mute = !musicSource.mute;
        print("mutelendi");
        print(musicSource.mute);
    }

    public void ToggleSFX(){
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume){
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume){
        sfxSource.volume = volume;
    }
    
    
    void Update()
    {
        //print(isPlaying);
        
        
        
    }
    
}
