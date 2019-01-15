using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxClick : MonoBehaviour
{
    public GameObject gameBox;
    public Button myButton;

	public void Click ()
    {
        if (gameBox.GetComponent<boxCreator>().Offer == 0)
        {

            if (gameBox.GetComponent<boxCreator>().firstBox > 0)
            {

                if (gameBox.GetComponent<boxCreator>().rounds.Count == 0)
                {
                    gameBox.GetComponent<boxCreator>().swap();
                    return;
                }

                gameBox.GetComponent<boxCreator>().roundClick();
                //Changes text on box to display value that was inside of it
                this.transform.GetChild(0).GetComponent<Text>().text = "£" + gameBox.GetComponent<boxCreator>().values[0];
                //Removes values from list once revealed 
                gameBox.GetComponent<boxCreator>().values.RemoveAt(0);
            }

            else
            {
                gameBox.GetComponent<boxCreator>().firstBox = gameBox.GetComponent<boxCreator>().values[0];
                gameBox.GetComponent<boxCreator>().values.RemoveAt(0);
            }

            //Disables interaction of a button when clicked
            myButton.interactable = !myButton.interactable;
        }
    }

    //Process for when a player chooses to accept a deal
    public void dealClick ()
    {
        //If a deal has not been accepted previously
        if (gameBox.GetComponent<boxCreator>().ifDealAccepted == false)
        {
            //winText is changed to display the offer
            gameBox.GetComponent<boxCreator>().winText.text = "£" + gameBox.GetComponent<boxCreator>().Offer;
            //ifDealAccepted is changed to true so the player cannot accept another deal
            gameBox.GetComponent<boxCreator>().ifDealAccepted = true;
        }
        
        if (gameBox.GetComponent<boxCreator>().isSwap == true)
        {
            gameBox.GetComponent<boxCreator>().winText.text = "£" + gameBox.GetComponent<boxCreator>().values[0];
        }

        gameBox.GetComponent<boxCreator>().Offer = 0;
    }

    //Process for when a player chooses not to accept a deal
    public void noDealClick ()
    {
        gameBox.GetComponent<boxCreator>().Offer = 0;

        if (gameBox.GetComponent<boxCreator>().isSwap == true)
        {
            //winText displayed is the value of firstBox
            gameBox.GetComponent<boxCreator>().winText.text = "£" + gameBox.GetComponent<boxCreator>().firstBox;
        }
    }
}
