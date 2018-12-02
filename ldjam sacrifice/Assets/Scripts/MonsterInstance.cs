using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInstance : MonoBehaviour {

    public GameObject DemonPrefab;
    public GameObject CivilianPrefab;
    public GameObject SummonerPrefab;

    private static MonsterInstance _MonsterInstace;

	// Use this for initialization
	void Start () {
        _MonsterInstace = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static MonsterInstance Instance
    {
       get
        {
            if(_MonsterInstace == null)
            {
                return null;
            }
            return _MonsterInstace;
        }
    }
}
