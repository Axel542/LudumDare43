using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject CanvasObject;

    private static GameManager _GameManager;

	// Use this for initialization
	void Start () {
        _GameManager = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static GameManager Instance
    {
        get
        {
            if(_GameManager != null)
            {
                return _GameManager;
            }
            else
            {
                return null;
            }
        }
    }
}
