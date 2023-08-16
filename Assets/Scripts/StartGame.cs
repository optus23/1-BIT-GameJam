using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Camera MainCamera;
    GameObject button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.name == "StartBtn")
                {
                    button = hit.transform.gameObject;
                    button.SetActive(false);
                    GameStateController.Instance.UpdateGameState(GameStateController.GameState.GAME);
                }
            }
        }
    }
}
