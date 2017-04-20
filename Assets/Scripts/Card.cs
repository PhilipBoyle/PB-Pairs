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
    private bool _setUp = false;

    private Sprite cBack; //card back (Green square)
    private Sprite cFace; //card face (1-10 JQKA)

    private GameObject pairsManager;

    void Begin()
    {
        cardState = 1; //cards face down
        pairsManager = GameObject.FindGameObjectWithTag("PairsManager"); //slightly inificiant method, works with small games

    }

    public void SetUpArt()
    {
        cBack = pairsManager.GetComponent<Pairs>().GetBack();//<--error
        cFace = pairsManager.GetComponent<Pairs>().GetFace(cardNumber);

        turnCard();//turns the card
    }

    public void turnCard() //handles turning of card
    {
        if (cardState == 0)
        {
            cardState = 1;
        }
        else if(cardState == 1)
        {
            cardState = 0;
        }
        if (cardState == 0 && !NO_TURN)
        {
            GetComponent<Image>().sprite = cBack; // shows card back
        }
        else if (cardState == 1 && !NO_TURN)
        {
            GetComponent<Image>().sprite = cFace; // shows card front
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
        get { return _setUp; }
        set { _setUp = value; }
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
            GetComponent<Image>().sprite = cBack;
        }
        else if (cardState == 1)
        {
            GetComponent<Image>().sprite = cFace;
        }
    }
}
