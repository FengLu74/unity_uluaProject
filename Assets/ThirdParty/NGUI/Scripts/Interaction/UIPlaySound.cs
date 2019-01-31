//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Plays the specified sound.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
    public enum Trigger
    {
        OnClick,
        OnMouseOver,
        OnMouseOut,
        OnPress,
        OnRelease,
        Custom,
        OnEnable,
        OnDisable,
    }
    private bool m_isInit = false;
    [SerializeField]
    public AudioClip audioClip;
    public int soundID = 4001;
    public Trigger trigger = Trigger.OnClick;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0f, 2f)]
    public float pitch = 1f;

    bool mIsOver = false;
    /// <summary>
    /// 设置管理器
    /// </summary>
   // private CMusicManage m_musicManage = null;

    bool canPlay
    {
        get
        {
            if (!enabled) return false;
            UIButton btn = GetComponent<UIButton>();
            return (btn == null || btn.isEnabled);
        }
    }

    void Star()
    {
        InitMusicManager();
        m_isInit = true;
    }


    void OnEnable()
    {
        if (true == m_isInit)
        {
            if (trigger == Trigger.OnEnable)
            {
                InitMusicManager();
            }
            //    NGUITools.PlaySound(audioClip, volume, pitch);
        }
    }

    void OnDisable()
    {
        //if (trigger == Trigger.OnDisable)
        //    NGUITools.PlaySound(audioClip, volume, pitch);
    }

    void OnHover(bool isOver)
    {
        if (trigger == Trigger.OnMouseOver)
        {
            if (mIsOver == isOver) return;
            mIsOver = isOver;
        }

        //if (canPlay && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)))
        //    NGUITools.PlaySound(audioClip, volume, pitch);
    }

    void OnPress(bool isPressed)
    {
        if (trigger == Trigger.OnPress)
        {
            if (mIsOver == isPressed) return;
            //mIsOver = isPressed;
            InitMusicManager();
        }
        //if (canPlay && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)))
        //    NGUITools.PlaySound(audioClip, volume, pitch);
    }

    void OnClick()
    {
        if (trigger == Trigger.OnClick)
        {
            //    NGUITools.PlaySound(audioClip, volume, pitch);
            InitMusicManager();
        }
    }

    void OnSelect(bool isSelected)
    {
        if (canPlay && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
            OnHover(isSelected);
    }

    public void Play()
    {
        //NGUITools.PlaySound(audioClip, volume, pitch);
    }

    private void InitMusicManager()
    {
        //if (null == m_musicManage)
        //{
        //    m_musicManage = Ioo.MusicManager;
        //}
        //if (soundID > 0 && m_musicManage)
        //    m_musicManage.OnLoadMusic(soundID);
        //else
        //    Debug.Log("声音ID 没有配置 对象名字=== " + this.transform.parent.name);
    }

}
