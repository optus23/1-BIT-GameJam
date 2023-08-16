using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Timeline;

public class GameStateController : Singleton <GameStateController>
{
    public MonoBehaviour[] InGameScripts;
    public TimelineAsset TimeLine;
    public enum GameState
    {
        START,
        GAME,
        END
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
   
                //TODO: Stop Timeline
                foreach ( var script in InGameScripts )
                {
                    script.enabled = false;
                }
                Debug.Log( "--- START STATE ---" );
                break;

            case GameState.GAME:
    
                //TODO: Start Timeline
                foreach ( var script in InGameScripts )
                {
                    script.enabled = true;
                }
                Debug.Log( "--- GAME STATE ---" );
                break;

            case GameState.END:
                //TODO: Stop Timeline

                foreach ( var script in InGameScripts )
                {
                    script.enabled = false;
                }
                Debug.Log( "--- END STATE ---" );

                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }


}
