using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

    public Player Player;

    public Slider HealthSlider;
    public Slider BloodSlider;

    private WaveManager waveManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        BloodSlider.value = Player.Blood;
        HealthSlider.value = Player.Health;
	}
}
