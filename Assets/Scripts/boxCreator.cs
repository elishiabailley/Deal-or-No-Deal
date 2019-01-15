using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxCreator : MonoBehaviour
{

    //Lists all the values that will be present in each of the boxes
    public List<float> values = new List<float> { 0.1f, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000, 200000, 300000, 400000, 500000, 750000, 1000000 };
    //List for each of the rounds
    public List<int> rounds = new List<int>();
    //First box that the player chooses
    public float firstBox;
    //Amount that the banker offers
    public float Offer;
    //Text displayed showing the bankers offer
    public Text offerText;
    //Condition for if a deal is accepted
    public bool ifDealAccepted;
    //Text for the amount of money the player has won
    public Text winText;
    //Condition for whether the player has chosen to swap firstBox
    public bool isSwap;
    GameObject dealButton;

    void Start()
    {
        //Loop used for randomising the values in the boxes
        for (int i = 0; i < values.Count; i++)
        {
            float temp = values[i];
            int randomIndex = Random.Range(i, values.Count);
            values[i] = values[randomIndex];
            values[randomIndex] = temp;
        }

        print(values[0]);
    }

    public void roundClick()
    {
        rounds[0]--;
        Debug.Log(rounds[0]);

        if (rounds[0] == 0)
        {
            Banker();
            //Once the round number is equal to 0, it is removed from the list
            rounds.RemoveAt(0);   
        }
    }

    void Banker()
    {
        int redblueCounter = 0;
        float total = 0;
        int Multiplier = 10 * (7 - rounds.Count);

        for(int i = 0; i < values.Count; i++)
        {
            //Values above 999 are classes as red numbers and so if there are more of these left, a higher offer is offered
            if (values[i] > 999)
            {
                redblueCounter++;
            }
            //Calculates the values left over and adds them to the total
            total = total + values[i];
        }

        if (firstBox > 999)
        {
            redblueCounter++;
        }

        //Includes the value of the first box within the total
        total = total + firstBox;
        
        //This is the equation used to calculate the offers
        Offer = (total / values.Count) / 100;

        if (redblueCounter > values.Count / 2)
        {
            Multiplier = Multiplier - 5;
        }

        Offer = Offer * Multiplier;
        
        offerText.text = "£" + Offer;
    }

    public void swap ()
    {
        //Changes "deal" text on the deal button to "swap" on the final round
        dealButton = GameObject.Find("Deal");

        dealButton.transform.GetChild(0).GetComponent<Text>().text = "Swap";
        isSwap = true;
    }
}
