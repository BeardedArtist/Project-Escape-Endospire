using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] Text textElement;
    [SerializeField] float fuel = 100;
    

    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        gameObject.tag = "Refull Station";
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

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Refull Station") 
        {
            if (fuel < 2001) 
            {
                textElement.text = "Fuel: " + fuel;
                fuel++;
            }
        }    
    }




}
