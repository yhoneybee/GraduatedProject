using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

[System.Serializable]
public struct CharactorSounds
{
    public AudioClip start;
    public AudioClip hit;
    public AudioClip attack;
    public AudioClip attackSfx;
    public AudioClip defence;
    public AudioClip command;
    public AudioClip die;
}

public enum eCHARACTOR_SOUND_TYPE
{
    Start,
    Hit,
    Attack,
    AttackSfx,
    Defence,
    Command,
    Die,
}

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioBgm;
    public AudioSource[] audioSfx = new AudioSource[10];

    public AudioClip loading;
    public AudioClip title;
    public AudioClip main;
    public AudioClip room;
    public AudioClip ingame;

    public CharactorSounds samdae;
    public CharactorSounds kanzi;

    public CharactorSounds Player1 => K.player1Type == CharactorType.Samdae ? samdae : kanzi;
    public CharactorSounds Player2 => K.player2Type == CharactorType.Samdae ? samdae : kanzi;

    float bgmVolume;
    public float BgmVolume
    {
        get => bgmVolume;
        set
        {
            if (value < 0 || 1 < value) return;
            audioBgm.volume = value;
        }
    }

    public bool BgmMute
    {
        set
        {
            audioBgm.mute = value;
        }
    }

    float sfxVolume;
    public float SfxVolume
    {
        get => sfxVolume;
        set
        {
            if (value < 0 || 1 < value) return;

            foreach (var item in audioSfx)
                item.volume = value;
        }
    }

    public bool SfxMute
    {
        set
        {
            foreach (var item in audioSfx)
                item.mute = value;
        }
    }

    public override void Init()
    {
        audioBgm.loop = true;

        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            SfxVolume = PlayerPrefs.GetFloat("SfxVolume");
        }
        if (PlayerPrefs.HasKey("BgmVolume"))
        {
            BgmVolume = PlayerPrefs.GetFloat("BgmVolume");
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        BgmVolume = SfxVolume = 0.5f;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("BgmVolume", BgmVolume);
        PlayerPrefs.SetFloat("SfxVolume", SfxVolume);
    }

    public void PlayPlayer1Sound(eCHARACTOR_SOUND_TYPE type) => PlayCharactorSound(type, Player1);
    public void PlayPlayer2Sound(eCHARACTOR_SOUND_TYPE type) => PlayCharactorSound(type, Player2);
    public void PlaySamdaeSound(eCHARACTOR_SOUND_TYPE type) => PlayCharactorSound(type, samdae);
    public void PlayKanziSound(eCHARACTOR_SOUND_TYPE type) => PlayCharactorSound(type, kanzi);
    void PlayCharactorSound(eCHARACTOR_SOUND_TYPE type, CharactorSounds charactorSounds)
    {
        AudioSource select = null;

        for (int i = 0; i < audioSfx.Length; i++)
        {
            var obj = audioSfx[i];
            if (obj.isPlaying) continue;
            select = obj;
        }

        var sound = type switch
        {
            eCHARACTOR_SOUND_TYPE.Start => charactorSounds.start,
            eCHARACTOR_SOUND_TYPE.Hit => charactorSounds.hit,
            eCHARACTOR_SOUND_TYPE.Attack => charactorSounds.attack,
            eCHARACTOR_SOUND_TYPE.AttackSfx => charactorSounds.attackSfx,
            eCHARACTOR_SOUND_TYPE.Defence => charactorSounds.defence,
            eCHARACTOR_SOUND_TYPE.Command => charactorSounds.command,
            eCHARACTOR_SOUND_TYPE.Die => charactorSounds.die,
            _ => null,
        };

        if (select != null)
            select.PlayOneShot(sound);
    }

    public void PlayLoading() => PlayBgm(loading);
    public void PlayTitle() => PlayBgm(title);
    public void PlayMain() => PlayBgm(main);
    public void PlayRoom() => PlayBgm(room);
    public void PlayIngame() => PlayBgm(ingame);
    void PlayBgm(AudioClip bgm)
    {
        audioBgm.clip = bgm;
        audioBgm.Play();
    }
}
