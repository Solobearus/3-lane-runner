using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    
    private bool _playing = false;
    public bool playing { 
        get { return _playing; }
        set { _playing = value; }
    }

}