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
      public static count = 0;
      
      
      public Game(int Difficulty, string Theme, int Id = 0)
      {
        _id = Id;
        _theme = Theme;
        _difficulty = Difficulty;
      }
      
      public bool Check(Card card1, Card card2)
      {
        bool result = false;
        if(card1.GetPairNum() === card2.GetPairNum())
        {
          count++;
          result = true;
        }
        return result;
      }
      
      public List<Card> CreateGame()
      {
        List<Card> game = new List<Card>{};
        for(int i = 1; i <= _difficulty.Length; i++)
        {
          Random rnd = new Random();
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
      
      public int CheckCount()
      {
        if(count === _difficulty)
        {
          
        }
        return count;
      }

      
     //cardfront
      <img src = "/img/@model.GetTheme()@model.GetPairNum().jpg"
                  /img/harrypotter12.jpg
                  
    //cardback
      <img src= "/img/CardBack@Model.GetTheme().jpg"
                /img/CardBack2.jpg
                /img/CardBackHarryPotter.jpg
                
    }
  }

