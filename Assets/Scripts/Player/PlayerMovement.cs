using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 startTouchPosition, endTouchPosition;

    private GameStateManager gameStateManager;

    private void Start()
    {
        gameStateManager = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }

    private void Update()
    {
        if (gameStateManager.playing)
        {
            float xAxisMovement = 0;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                startTouchPosition = Input.GetTouch(0).position;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
                    xAxisMovement = -1.75f;

                if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < 1.75f)
                    xAxisMovement = 1.75f;
            }

            Vector3 newPlayerPosition = new Vector3(transform.position.x + xAxisMovement, transform.position.y, transform.position.z + gameStateManager.playerSpeed * Time.deltaTime);
            transform.position = newPlayerPosition;
        }
    }
}
