using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Vuforia;

public class TurretManager : MonoBehaviour {

    [SerializeField] private Button[] buttons;
    [SerializeField] private BaseTurret[] turrets;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(Button vb) {

        for (int i = 0; i < this.buttons.Length; i++) {
            if (vb == this.buttons[i]) {

                if (this.turrets[i].IsTurretFiring()) {
                    this.turrets[i].StopTurret();
                }
                else {
                    this.turrets[i].FireTurretEndless();
                }
                
            }
        }
        
    }

    public void OnButtonReleased(Button vb) {
        
    }


}