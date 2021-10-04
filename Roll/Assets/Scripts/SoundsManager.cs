using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField]
    AudioSource musicSource;

    [SerializeField]
    AudioClip music;

    private static SoundsManager instance;
    public static SoundsManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("SoundsManager instance not found");

            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }


}
