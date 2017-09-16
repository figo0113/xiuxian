﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Sound : Singleton<Sound>
{
    protected override void Awake()
    {
        base.Awake();

        m_bgSound = this.gameObject.AddComponent<AudioSource>();
        m_bgSound.playOnAwake = false;
        m_bgSound.loop = true;

        m_effectSound = this.gameObject.AddComponent<AudioSource>();
    }
    public string ResourceDir = "";

    AudioSource m_bgSound;
    AudioSource m_effectSound;


    //音乐大小
    public float BgVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }

    //音效大小
    public float EffectVolume
    {
        get { return m_effectSound.volume; }
        set { m_effectSound.volume = value; }
    }

    //播放音乐
    public void PlayBg(string audioName)
    {
        string oldName;
        if (m_bgSound.clip = null)
            oldName = "";
        else
            oldName = m_bgSound.clip.name;

        if (oldName != audioName)
        {
            string path;
            if (string.IsNullOrEmpty(ResourceDir))
                path = "";
            else
                path = ResourceDir + "/" + audioName;

            AudioClip clip = Resources.Load<AudioClip>(path);

            if (clip != null)
            {
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }
    }
    //停止音乐
    public void StopBg()
    {
        m_bgSound.Stop();
        m_bgSound.clip = null;
    }

    //播放音效
    public void PlayEffect(string audioName)
    {
        string path;
        if (string.IsNullOrEmpty(ResourceDir))
            path = "";
        else
            path = ResourceDir + "/" + audioName;

        AudioClip clip = Resources.Load<AudioClip>(path);

        m_effectSound.PlayOneShot(clip);

    }

}
