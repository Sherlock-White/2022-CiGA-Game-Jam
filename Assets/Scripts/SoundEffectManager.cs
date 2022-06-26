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

        audiosource.playOnAwake = false;  //playOnAwake��Ϊfalseʱ��ͨ������play()��������

        _instance = this; //ͨ��SoundEffectManager._instance.��������
    }

    //����ͬʱ���Ŷ����Ƶ
    public void PlayEffect(int audioIndex)
    {
        string path = "Resources/Effect/" + audioPath[audioIndex];
        AudioClip clip = Resources.Load<AudioClip>("Effect/" + audioPath[audioIndex]);
        audiosource.PlayOneShot(clip);
    }

    //�����ǰ��������Ƶ���ڲ��ţ�ֹͣ��ǰ��Ƶ��������һ��
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

    //ֹͣ��ǰ���ڲ��ŵ���Ч
    public void StopEffect()
    {
        if (audiosource.isPlaying)
        {
            audiosource.Stop();
        }
    }
}
