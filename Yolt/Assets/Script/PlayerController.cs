using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject GameManager;

    private static float _lùth;
    private float _maxlùth;
    private bool lùthfinito;

    private bool alive;
    public bool resurrection;
    private bool transformable;

    //public Vector3 _Slots;
    public bool[] _Slots;

    //assassin = 0; tank = 1; support = 2;
    public enum CLASSES {assassin, tank, support};

    private Health _playerHealth;
    private GameManager _gameManager;

    
    public CLASSES state;

	// Use this for initialization
	void Start () {

        alive = true;
        transformable = false;
        resurrection = false;

        lùthfinito = false;

        _lùth = 0;
        _maxlùth = 100;

        _gameManager = GameManager.GetComponent<GameManager>();

        

        //0 è libero, 1 è occupato. x = Assassin, y = Support, z = Tank;
        //new Vector3(0,0,0)
        //
        _Slots = new bool[3];

        for (int i = 0; i < 3; i++)
            _Slots[i] = true;

        _playerHealth = GetComponent<Health>();
        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (_playerHealth._health == 0)
        {
            tag = "Ghost";
            alive = false;
            //change the model in the ghost

        }


        if (resurrection) {

            _playerHealth._health = 100; //maxhealth
            tag = "Player";
            alive = true;
            resurrection = false;
            //change the model in the player

        }



        if (transformable) {
            if (Input.GetKeyDown("Transform"))
            {

                //canvas con i bottoni

                /* Questo è un GameObject -> _gameManager.playersConnected[i]
                 * 
                 * for each (GameObject player in _gameManager.playersConnected) {
                 * 
                 *      for(int i = 0; i<3;i++){
                 *          if(player._Slots[i]){
                 *              button1 = cliccabile;
                 *          }
                 *      }
                 *      
                 * }
                 * 
                 * 
                */

                
            

            }


        }
		
	}

    public void FreeTheSlots() {

        for (int i = 0; i < 3; i++)
            _Slots[i] = true;

    }

    public void IncreaseLùth(float i) {

        Debug.Log(_lùth);

        if (_lùth == _maxlùth)
        {
            transformable = true;
            //cambia tag in class che scegli
            //cambia mesh renderer in class che scegli
        }
        else {
            _lùth += i;
        }

    }

    public void DecreaseLùth(float i) {

        _lùth -= i;

        if (_lùth < 0) {
            _lùth = 0;

            lùthfinito = true;
        }

    }
}
