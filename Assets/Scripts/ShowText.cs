using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] Text textElement;
    [SerializeField] int fuel = 100;

    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        FuelCounter();
    }

    void FuelCounter() 
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (fuel >= 1) 
            {
                textElement.text = "Fuel: " + fuel;
                fuel--;
            }
            else 
            {
                textElement.text = "No Fuel!";
                movement.enabled = false;
                movement.StopBoosting();
            }
            
        }
    }

}
