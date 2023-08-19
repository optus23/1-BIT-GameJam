using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Xml.Linq;

public class GameStateController : Singleton <GameStateController>
{
    public MonoBehaviour[] InGameScripts;
    public PlayableDirector director;
    public GameObject[] restartButtons;
    public GameObject startBtn;
    FadeObject fdObject;

    public enum GameState
    {
        START,
        GAME,
        END,
        RESTART
    }

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        UpdateGameState( GameState.START );
    }

    public void UpdateGameState(GameState state)
    {
        switch ( state )
        {
            case GameState.START:

                StopTimeline();

                
                fdObject = startBtn.GetComponent<FadeObject>();
                if (fdObject != null)
                {
                    startBtn.SetActive(true);
                    fdObject.FadeInObject();
                }


                foreach ( var script in InGameScripts )
                {
                    script.enabled = false;
                }
                Debug.Log( "--- START STATE ---" );
                break;

            case GameState.GAME:

                StartTimeline();
                
                foreach ( var script in InGameScripts )
                {
                    script.enabled = true;
                }
                Debug.Log( "--- GAME STATE ---" );
                break;

            case GameState.END:

                foreach (var g_object in restartButtons)
                {
                    g_object.SetActive(true);
                    if (g_object.GetComponent<FadeObject>() == null)
                    {
                        g_object.AddComponent<FadeObject>();
                    }

                    g_object.GetComponent<FadeObject>().FadeInObject();
                }
                foreach ( var script in InGameScripts )
                {
                    script.enabled = false;
                }
                Debug.Log( "--- END STATE ---" );

                break;
            case GameState.RESTART:
                director.time = 0;
                director.Stop();
                director.Evaluate();

                UpdateGameState( GameState.START );
                //TODO: Restart texture (no se como)

                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void StartTimeline()
    {
        director.Play();
    }
    
    public void StopTimeline()
    {
        director.Stop();
    }
    public void AsignEndGameState()
    {
        UpdateGameState( GameState.END );
    }
}




