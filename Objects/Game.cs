using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MemoryGame
  {
    public class Game
    {
      private int _id;
      private string _theme;
      private int _difficulty;
      public static int count = 0;


      public Game(int Difficulty, string Theme, int Id = 0)
      {
        _id = Id;
        _theme = Theme;
        _difficulty = Difficulty;
      }
      public int GetCount()
      {
        return count;
      }
      public bool Check(Card card1, Card card2)
      {
        bool result = false;
        if(card1.GetPairNum() == card2.GetPairNum())
        {
          count++;
          result = true;
        }
        return result;
      }

      public List<Card> CreateGame()
      {
        Random rnd = new Random();
        List<Card> game = new List<Card>{};
        for(int i = 1; i <= _difficulty; i++)
        {
          int randNum = rnd.Next(1,101);
          int randNum2 = rnd.Next(1,101);
          Card newCard = new Card(_theme, i, randNum);
          newCard.Save();
          Card new2Card = new Card(_theme, i, randNum2);
          new2Card.Save();
          game.Add(newCard);
          game.Add(new2Card);
        }
        return game;
      }

      public bool CheckWin()
      {
        bool winner = false;
        if(count == _difficulty)
        {
          winner = true;
        }
        return winner;
      }
    }
  }
