using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotonPlayerSetup : MonoBehaviour {
  
  public string[] playerNames;  // get the names of the players from the
                                // thorsten name input script (?)
  public TextMeshProUGUI[] playerNameTexts;  // the texts that display the
                                             // player names in leaderboard
  public int[] playerScores;  // get the scores of the players from the thorsten
                              // score script (?)
  public int scoreTotal;                      // the total score of each player
  public TextMeshProUGUI[] playerScoreTexts;  // the texts that display the
                                              // player scores in leaderboard
  public Transform[] scoreRank;  // where on the board the score is

  // Update is called once per frame
  void Update()
  {
    LeaderBoardUpdate();                          // update the leaderboard
    for (int i = 0; i < playerNames.Length; i++)  // for each player
    {
      playerNameTexts[i].text = playerNames[i];  // update the player name text to the new player name
    }
  }

  void LeaderBoardUpdate()
  {
    int tempTotal = 0;  // set a temporary score total to 0

    for (int i = 0; i < playerScores.Length; i++)  // for each player
    {
      tempTotal += playerScores[i];  // add their score to the total
    }

    if (tempTotal != scoreTotal)  // if the total score has changed
    {
      RankUpdate();  // update the ranking
      scoreTotal = tempTotal;
      for (int i = 0; i < playerScores.Length; i++)  // for each player score
      {
        playerScoreTexts[i].text = playerScores[i].ToString();  // update the player score text to the
                                                                // new player score (tempTotal)
      }
    }
  }

  void RankUpdate()
  {
    Transform[] rank = scoreRank;  // set the rank to the score rank
    int[] scores = playerScores;   // set the scores to the player scores
    int[] places = { 0, 0, 0, 0, 0 };  // the number of places is 5 (as in 5 zeros)

    /// basically it sorts out the scores in the board, trying to see which one
    /// is the biggest and smallest and so on
    for (int i = 0; i < scores.Length; i++)  // for each player
    {
      for (int j = 0; j < scores.Length; j++)  // check for each other player and themselves included
      {
        if (scores[i] < scores[j])  // if the score is less than the other scores
        {
          places[i]++;  // add one to the place (go down the leaderboard)
        }
      }
    }
    for (int i = 0; i < rank.Length; i++)  // depending on the rank of the player score
    {
      rank[i].SetSiblingIndex(places[i]);  // sends it to its respective place
                                           // in the leaderboard grid
    }
  }
}
