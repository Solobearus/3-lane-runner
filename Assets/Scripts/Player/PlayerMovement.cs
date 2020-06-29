using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 startTouchPosition, endTouchPosition;
    GameObject gameManager;

    GameStateManager gameStateManager;
    GameConfigManager gameConfigManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameStateManager = gameManager.GetComponent<GameStateManager>();
        gameConfigManager = gameManager.GetComponent<GameConfigManager>();
    }

    void Update()
    {
        if (gameStateManager.playing)
        {
            float xAxisMovement = CheckMovement();


            Vector3 newPlayerPosition = new Vector3(transform.position.x + xAxisMovement, transform.position.y, transform.position.z + gameStateManager.speed * Time.deltaTime);
            transform.position = newPlayerPosition;
        }
    }

    

    float CheckMovement()
    {
        float xAxisMovement = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.5f)
            {
                xAxisMovement = -1.75f;
            }
            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < 1.5f)
                xAxisMovement = 1.75f;
        }

        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -1.5f)
        {
            xAxisMovement = -1.75f;
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5f)
            xAxisMovement = 1.75f;

        return xAxisMovement;
    }
}
