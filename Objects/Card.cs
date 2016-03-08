using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MemoryGame
  {
    public class Card
    {
      private int _id;
      private string _theme;
      private int _pairNum;
      private int _randNum;

      public Card(string Theme, int PairNum, int RandNum, int Id = 0)
      {
        _theme = Theme;
        _id = Id;
        _pairNum = PairNum;
        _randNum = RandNum;
      }

      public override bool Equals(System.Object otherCard)
      {
        if(!(otherCard is Card))
        {
          return false;
        }
        else
        {
          Card newCard = (Card) otherCard;
          bool idEquality = this.GetId() == newCard.GetId();
          bool themeEquality = this.GetTheme() == newCard.GetTheme();
          bool pairNumEquality = this.GetPairNum() == newCard.GetPairNum();
          bool randNumEquality = this.GetRandNum() == newCard.GetRandNum();
          return (idEquality && themeEquality && pairNumEquality && randNumEquality);
        }
      }

      public int GetId()
      {
        return _id;
      }
      public int GetPairNum()
      {
        return _pairNum;
      }
      public void SetPairNum(int newPairNum)
      {
        _pairNum = newPairNum;
      }
      public int GetRandNum()
      {
        return _randNum;
      }
      public void SetRandNum(int newRandNum)
      {
        _randNum = newRandNum;
      }
      public string GetTheme()
      {
        return _theme;
      }
      public void SetTheme(string newTheme)
      {
        _theme = newTheme;
      }

      public void Save()
      {
        SqlConnection conn = DB.Connection();
        SqlDataReader rdr = null;
        conn.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO cards (theme, pairnum, randnum) OUTPUT INSERTED.id VALUES(@Theme, @PairNum, @RandNum);", conn);

        SqlParameter themeParameter = new SqlParameter();
        themeParameter.ParameterName = "@Theme";
        themeParameter.Value = this.GetTheme();

        SqlParameter pairNumParameter = new SqlParameter();
        pairNumParameter.ParameterName = "@PairNum";
        pairNumParameter.Value = this.GetPairNum();

        SqlParameter randNumParameter = new SqlParameter();
        randNumParameter.ParameterName = "@RandNum";
        randNumParameter.Value = this.GetRandNum();

        cmd.Parameters.Add(themeParameter);
        cmd.Parameters.Add(pairNumParameter);
        cmd.Parameters.Add(randNumParameter);
<<<<<<< HEAD
        
        rdr = cmd.ExecuteReader();
        
=======

        rdr = cmd.ExecuteReader();

>>>>>>> 45b1a038d4bb17ed0a0db438dcf4e367dd356a39
        while(rdr.Read())
        {
          this._id = rdr.GetInt32(0);
        }
        if(rdr != null)
        {
          rdr.Close();
        }
        if(conn != null)
        {
          conn.Close();
        }
      }
      public static List<Card> GetAll()
      {
        List<Card> allCards = new List<Card>{};

        SqlConnection conn = DB.Connection();
        SqlDataReader rdr = null;
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM cards ORDER BY randnum ASC;", conn);
        rdr = cmd.ExecuteReader();

        while(rdr.Read())
        {
          int cardId = rdr.GetInt32(0);
          string cardTheme = rdr.GetString(1);
          int cardPairNum = rdr.GetInt32(2);
          int cardRandNum = rdr.GetInt32(3);

          Card newCard = new Card(cardTheme, cardPairNum, cardRandNum, cardId);
          allCards.Add(newCard);
        }
        if(rdr != null)
        {
          rdr.Close();
        }
        if(rdr != null)
        {
          conn.Close();
        }
        return allCards;
      }
      public static void DeleteAll()
      {
        SqlConnection conn = DB.Connection();
        SqlDataReader rdr = null;
        conn.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM cards; DBCC CHECKIDENT ('cards', RESEED, 0);", conn);
        cmd.ExecuteNonQuery();
      }

    }
  }
