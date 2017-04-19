using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour {

    public static bool NO_TURN = false; //Controls when to stop cards being turned

    [SerializeField]
    private int cardState; //state of card (Turned or not, 0 = face up, 1 = facedown)
    [SerializeField]
    private int cardNumber; //Card value (1-13)
    [SerializeField]
    private bool SetUp = false;

    private Sprite back; //card back (Green square)
    private Sprite face; //card face (1-10 JQKA)

    private GameObject pairsManager;

    void Begin()
    {
        cardState = 0; //cards face down
        pairsManager = GameObject.FindGameObjectWithTag("Pairs"); //slightly inificiant method, works with small games

    }

    public void setUpArt()
    {
        back = pairsManager.GetComponent<Pairs>().getBack();
        face = pairsManager.GetComponent<Pairs>().getFace(cardNumber);

        turnCard();//turns the card
    }

    void turnCard() //handles turning of card
    {
        if (cardState == 0 && !NO_TURN)
        {
            GetComponent<Image>().sprite = back; // shows card back
        }
        else if (cardState == 1 && !NO_TURN)
        {
            GetComponent<Image>().sprite = face; // shows card front
        }
    }

    //setters and getters

    public int Number
    {
        get {return cardNumber;}
        set { cardNumber = value;}
    }
    
    public int State
    {
        get { return cardState; }
        set { cardState = value; }
    }

    public bool SetUp
    {
        get { return SetUp; }
        set { SetUp = value; }
    }

    
    public void PairCheck() //allows time for user to check if card is the one they are lookign for 
    {
        StartCoroutine(pause ());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1); //pauses for 1 second to show card to user
        if (cardState == 0)
        {
            GetComponent<Image>().sprite = back;
        }
        else if (cardState == 1)
        {
            GetComponent<Image>().sprite = face;
        }
    }
}
