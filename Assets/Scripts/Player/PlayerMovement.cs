using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 startTouchPosition, endTouchPosition;

    private GameStateManager gameStateManager;
    private GameScoreManager gameScoreManager;

    private void Start()
    {
        gameStateManager = GameObject.Find("GameManager").GetComponent<GameStateManager>();
        gameScoreManager = GameObject.Find("GameManager").GetComponent<GameScoreManager>();
    }

    private void Update()
    {
        if (gameStateManager.playing)
        {
            float xAxisMovement = CheckMovement();


            Vector3 newPlayerPosition = new Vector3(transform.position.x + xAxisMovement, transform.position.y, transform.position.z + calculateSpeedRelativeToScore() * Time.deltaTime);
            transform.position = newPlayerPosition;
        }
    }

    float calculateSpeedRelativeToScore()
    {
        float calculatedSpeed = gameStateManager.playerInitialSpeed;

        calculatedSpeed += gameScoreManager.score * gameStateManager.speedScoreMultiplier;

        calculatedSpeed -= gameStateManager.speedSubtractionFromPowerUp;

        if(calculatedSpeed < gameStateManager.playerInitialSpeed){
            calculatedSpeed = gameStateManager.playerInitialSpeed;
        }

        return calculatedSpeed;
    }

    float CheckMovement()
    {
        float xAxisMovement = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
            {
                xAxisMovement = -1.75f;
            }
            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < 1.75f)
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
