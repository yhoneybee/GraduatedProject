using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum SCENE_STEP //씬 스텝
{ 
    FIRST_FRAME, //시작
    START,
    PLAYING, 
    END_BEFORE,
    END,
    END_AFTER, //끝 (씬 변경)
}

public abstract class SceneBase<T> : Singleton<T> where T : class //베이스 씬 클래스
{
    [Header("=====Base Scene Class=====")]
    public SCENE_STEP sceneStep = SCENE_STEP.FIRST_FRAME; 
    string changeSceneName;
    public void Awake()
    {
        V.Awake();
        SceneAwake();
    }
    
    public void Start()
    {
        V.Start();
        Fade.Instance.FadeOut(Color.black, 1f, 1f, 1); //씬 시작 페이드 아웃
        SceneStart();
    }

    public void Update()
    {
        V.Update();

        switch (sceneStep) 
        {
            case SCENE_STEP.FIRST_FRAME:

                if(Fade.Instance.fadeStep == FADE_STEP.FADE_END_BEFORE)
                {
                    sceneStep = SCENE_STEP.START;
                }

                break;
            case SCENE_STEP.START:

                SceneEnter();

                sceneStep = SCENE_STEP.PLAYING;

                break;
            case SCENE_STEP.PLAYING:

                ScenePlaying();

                break;
            case SCENE_STEP.END_BEFORE:

                Fade.Instance.FadeIn(Color.black, 1f, 1f, 1);

                sceneStep = SCENE_STEP.END;

                break;
            case SCENE_STEP.END:

                if (Fade.Instance.fadeStep == FADE_STEP.FADE_END_BEFORE)
                {
                    SceneEnd();
                    sceneStep = SCENE_STEP.END_AFTER;
                }

                break;
            case SCENE_STEP.END_AFTER:

                SceneManager.LoadScene(changeSceneName);

                break;
        }
    }
    public void ChangeScene(string scenename) //씬 변경
    {
        changeSceneName = scenename;
        Debug.Log("Change Scene Name is : " + changeSceneName);

        sceneStep = SCENE_STEP.END_BEFORE;
    }

    public void PlayButtonSound() 
    {
        SoundManager.Instance.PlayButton();    
    }

    public abstract void SceneAwake();
    public abstract void SceneStart();
    public abstract void SceneEnter();
    public abstract void ScenePlaying();
    public abstract void SceneEnd();

}