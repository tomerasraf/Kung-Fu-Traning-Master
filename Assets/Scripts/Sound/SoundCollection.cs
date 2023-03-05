using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollection : MonoBehaviour
{
    public static SoundCollection Instance { get; private set; }

    [Header("Anticipation Sound")]
    [SerializeField]
    private AudioClip[] _anticipationSounds;

    public AudioClip[] Anticipation
    {
        get { return _anticipationSounds; }
        set { _anticipationSounds = value; }
    }

    [Header("Break Sound")]
    [SerializeField]
    private AudioClip[] _breakSounds;

    public AudioClip[] BreakSounds
    {
        get { return _breakSounds; }
        set { _breakSounds = value; }
    }

    [Header("Fail Sound")]
    [SerializeField]
    private AudioClip[] _failSounds;

    public AudioClip[] FailSounds
    {
        get { return _failSounds; }
        set { _failSounds = value; }
    }

    [Header("Player Sound")]
    [SerializeField]
    private AudioClip[] _playerHitSounds;

    public AudioClip[] PlayerHitSounds
    {
        get { return _playerHitSounds; }
        set { _playerHitSounds = value; }
    }

    [Header("Music")]
    [SerializeField]
    private AudioClip _music;

    public AudioClip Music
    {
        get { return _music; }
        set { _music = value; }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
