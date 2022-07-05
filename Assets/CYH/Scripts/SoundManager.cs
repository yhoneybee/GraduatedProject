using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPacket;

public struct CharactorSounds
{
    public AudioClip start;
    public AudioClip hit;
    public AudioClip attack;
    public AudioClip command;
    public AudioClip die;
}

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioBgm;
    public AudioSource[] audioSfx = new AudioSource[4];

    public CharactorSounds samdae;
    public CharactorSounds kanzi;

    public CharactorSounds CurrentSound => (K.player1.id == K.userInfo.id ? (K.player1Type == CharactorType.Samdae ? samdae : kanzi) : (K.player2Type == CharactorType.Samdae ? samdae : kanzi));


}
