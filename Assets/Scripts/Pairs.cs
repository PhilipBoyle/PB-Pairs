using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pairs : MonoBehaviour {

    public Sprite[] cardFace; //array of card faces
    public Sprite cardBack;
    public GameObject[] deck; //array of deck
    public Text pairsCount;


    private bool deckSetUp = false;
    private int pairsLeft = 13;

	
	// Update is called once per frame
	void Update () {
        if (!deckSetUp)
        {
            SetUpDeck();
        }
        if (Input.GetMouseButtonUp(0)) //detects left click
        {
            CheckDeck();
        }
	}//Update

    void SetUpDeck()
    {
        
        for(int i = 0; i <deck.Length; i++)//resets cards, had to be added due to issue with infinite looping While
        {
            deck[i].GetComponent<Card>().SetUp = false;
        }

        for (int ix = 0; ix < 2; ix++) //sets up cards twice, ensuring there is a pair for each card
        {
            for(int i = 1; i < 14; i++)//sets up card value (2-10 JQKA)
            {
                bool test = false;
                int val = 0;
                while (!test)
                {
                   val = Random.Range(0, deck.Length);
                   test = !(deck[val].GetComponent<Card>().SetUp);//finds cards that are not set up
                }//while

                //sets up cards
                
                deck[val].GetComponent<Card>().Number = i;
                deck[val].GetComponent<Card>().SetUp = true;

            }//nested for

        }//for

        foreach (GameObject crd in deck)
        {
            crd.GetComponent<Card>().SetUpArt();
        }

        if (!deckSetUp)
        {
            deckSetUp = true;
        }
    }//SetUpDeck

    public Sprite GetBack()
    {
        return cardBack;
    }//getBack

    public Sprite GetFace(int i)
    {
        return cardFace[i - 1];

    }//getFace

    void CheckDeck()
    {
        List < int > crd = new List<int>();

        for(int i = 0; i < deck.Length; i++)
        {
            if(deck[i].GetComponent<Card>().State == 1)
            {
                crd.Add(i);
            }

        }

        if(crd.Count == 2)
        {
            CompareCards(crd);
        }
    }//CheckDeck

    void CompareCards(List<int> crd)
    {
        Card.NO_TURN = true; //stops cards turning

        int x = 0;

        if(deck[crd[0]].GetComponent<Card>().Number == deck[crd[1]].GetComponent<Card>().Number)
        {
            x = 2;
            pairsLeft--;
            pairsCount.text = "PAIRS REMAINING: " + pairsLeft; //updates game text

            if(pairsLeft == 0) // goes to home screen when game has been won
            {
                SceneManager.LoadScene("Home");
            }

        }

        for(int j = 0; j < crd.Count; j++)
        {
            deck[crd[j]].GetComponent<Card>().State = x;
            deck[crd[j]].GetComponent<Card>().PairCheck();

        }

    }//CompareCards
}
