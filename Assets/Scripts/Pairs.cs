using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pairs : MonoBehaviour {

    public Sprite[] face; //array of card faces
    public Sprite back;
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
        for (int i = 0; i < 2; i++) //sets up cards twice, ensuring there is a pair for each card
        {
            for(int j = 1; j < 14; j++)//sets up card value (1-10 JQKA)
            {
                bool check = false;
                int val = 0;
                while(!check)
                {
                    val = Random.Range(0, deck.Length);
                    check = !(deck[val].GetComponent<Card>().SetUp);

                }//while

                deck[val].GetComponent<Card>().Number = j;
                deck[val].GetComponent<Card>().SetUp = true;

            }//nested for
        }//for

        foreach (GameObject crd in deck)
        {
            crd.GetComponent<Card>().setUpArt();
        }

        if (!deckSetUp)
        {
            deckSetUp = true;
        }
    }//SetUpDeck

    public Sprite getBack()
    {
        return back;
    }//getBack

    public Sprite getFace(int j)
    {
        return face[j - 1];
    }//getFace

    void CheckDeck()
    {
        List < int > crd = new List<int>();

        for(int j = 0; j < deck.Length; j++)
        {
            if(deck[j].GetComponent<Card>().State == 1)
            {
                crd.Add(j);
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

        int c = 0;

        if(deck[crd[0]].GetComponent<Card>().Number == deck[crd[1]].GetComponent<Card>().Number)
        {
            c = 2;
            pairsLeft--;
            pairsCount.text = "PAIRS REMAINING: " + pairsLeft; //updates game text

            if(pairsLeft == 0) // goes to home screen when game has been won
            {
                SceneManager.LoadScene("Home");
            }

        }

        for(int j = 0; j <crd.Count; j++)
        {
            deck[crd[j]].GetComponent<Card>().State = c;
            deck[crd[j]].GetComponent<Card>().PairCheck();

        }

    }//CompareCards
}
