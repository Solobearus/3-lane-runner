using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Player(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
