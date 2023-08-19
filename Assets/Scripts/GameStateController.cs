using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class GameStateController : Singleton <GameStateController>
{
    public MonoBehaviour[] InGameScripts;
    public PlayableDirector director;
    
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

                StopTimeline();
                
                foreach ( var script in InGameScripts )
                {
                    script.enabled = false;
                }
                Debug.Log( "--- END STATE ---" );

                break;
            case GameState.RESTART:
                StartTimeline();

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

}




