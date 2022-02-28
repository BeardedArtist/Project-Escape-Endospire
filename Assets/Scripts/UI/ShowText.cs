using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] Text textElement;
    [SerializeField] public float fuel = 3500;
    public float currentFuel;


    public FuelBar fuelBar;
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        gameObject.tag = "Refull Station";
        currentFuel = fuel;
        fuelBar.SetMaxFuel(fuel);
    }

    // Update is called once per frame
    void Update()
    {
        FuelCounter();
    }

    void FuelCounter() 
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
        {
            if (currentFuel >= 1) 
            {
                textElement.text = "Fuel: " + currentFuel;
                currentFuel = fuel--;
                fuelBar.SetFuel(currentFuel);
            }
            else 
            {
                //textElement.text = "No Fuel!";
                movement.enabled = false;
                movement.StopBoosting();
            }
            
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Refull Station") 
        {
            if (fuel < 3500) 
            {
                textElement.text = "Fuel: " + fuel;
                fuel += 250 * Time.deltaTime;
                currentFuel = fuel;
                //currentFuel = fuel++;
                fuelBar.SetFuel(currentFuel);
            }
        }
    }




}
