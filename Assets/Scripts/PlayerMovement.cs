using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeReference]
    [Range(1f, 100f)] private float speed = 10F;
    private Vector2 startTouchPosition, endTouchPosition;

    [SerializeReference]
    private GameObject gameManager;
    private GameStateManager gameStateManager;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>().Player = gameObject;
        gameStateManager = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }

    private void Update()
    {
        if (!gameStateManager.gameOver)
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

            Vector3 newPlayerPosition = new Vector3(transform.position.x + xAxisMovement, transform.position.y, transform.position.z + speed * Time.deltaTime);
            transform.position = newPlayerPosition;
        }
    }
}
