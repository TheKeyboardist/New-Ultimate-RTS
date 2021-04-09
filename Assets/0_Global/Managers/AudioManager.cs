using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource[] sounds;
    private AudioSource click;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();

        click = sounds[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
