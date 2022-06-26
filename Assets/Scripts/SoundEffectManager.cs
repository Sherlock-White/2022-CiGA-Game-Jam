using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioSource audiosource;

    private string[] audioPath = {"lightNoise","heavyNoise","error","jump","windNoise"};

    public static SoundEffectManager _instance;
    void Awake()
    {
        audiosource = gameObject.AddComponent<AudioSource>();

        audiosource.playOnAwake = false;  //playOnAwake设为false时，通过调用play()方法启用

        _instance = this; //通过SoundEffectManager._instance.方法调用
    }

    //可以同时播放多个音频
    public void PlayEffect(int audioIndex)
    {
        string path = "Resources/Effect/" + audioPath[audioIndex];
        AudioClip clip = Resources.Load<AudioClip>("Effect/" + audioPath[audioIndex]);
        audiosource.PlayOneShot(clip);
    }

    //如果当前有其他音频正在播放，停止当前音频，播放下一个
    public void PlayNextEffect(int audioIndex)
    {
        AudioClip clip = Resources.Load<AudioClip>("Effect/" + audioPath[audioIndex]);

        if (audiosource.isPlaying)
        {
            audiosource.Stop();
        }

        audiosource.clip = clip;
        audiosource.Play();
    }

    //停止当前正在播放的音效
    public void StopEffect()
    {
        if (audiosource.isPlaying)
        {
            audiosource.Stop();
        }
    }
}
