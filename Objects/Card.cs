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
      private string _turnt;

      public Card(string Theme, int PairNum, int RandNum, string Turnt = "false", int Id = 0)
      {
        _theme = Theme;
        _id = Id;
        _pairNum = PairNum;
        _randNum = RandNum;
        _turnt = Turnt;
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
          bool turntEquality = this.GetTurnt() == newCard.GetTurnt();
          return (idEquality && themeEquality && pairNumEquality && randNumEquality && turntEquality);
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
      public string GetTurnt()
      {
        return _turnt;
      }
      public void SetTurnt(string newTurnt)
      {
        _turnt = newTurnt;
      }

      public void Save()
      {
        SqlConnection conn = DB.Connection();
        SqlDataReader rdr = null;
        conn.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO cards (theme, pairnum, randnum, turnt) OUTPUT INSERTED.id VALUES(@Theme, @PairNum, @RandNum, @Turnt);", conn);

        SqlParameter themeParameter = new SqlParameter();
        themeParameter.ParameterName = "@Theme";
        themeParameter.Value = this.GetTheme();

        SqlParameter pairNumParameter = new SqlParameter();
        pairNumParameter.ParameterName = "@PairNum";
        pairNumParameter.Value = this.GetPairNum();

        SqlParameter randNumParameter = new SqlParameter();
        randNumParameter.ParameterName = "@RandNum";
        randNumParameter.Value = this.GetRandNum();
        
        SqlParameter turntParameter = new SqlParameter();
        turntParameter.ParameterName = "@Turnt";
        turntParameter.Value = this.GetTurnt();

        cmd.Parameters.Add(themeParameter);
        cmd.Parameters.Add(pairNumParameter);
        cmd.Parameters.Add(randNumParameter);
        cmd.Parameters.Add(turntParameter);
        
        rdr = cmd.ExecuteReader();
        
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
          string cardTurnt = rdr.GetString(4);

          Card newCard = new Card(cardTheme, cardPairNum, cardRandNum, cardTurnt, cardId);
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
      
      public void Update(string updateTurnt)
      {
        SqlConnection conn = DB.Connection();
        SqlDataReader rdr;
        conn.Open();
        
        SqlCommand cmd = new SqlCommand("UPDATE cards SET turnt = @UpdateTurnt OUTPUT INSERTED.turnt WHERE id = @CardId;", conn);
        
        SqlParameter updateTurntParameter = new SqlParameter();
        updateTurntParameter.ParameterName = "@UpdateTurnt";
        updateTurntParameter.Value = updateTurnt;
        cmd.Parameters.Add(updateTurntParameter);
        
        SqlParameter cardIdParameter = new SqlParameter();
        cardIdParameter.ParameterName = "@CardId";
        cardIdParameter.Value = this.GetId();
        cmd.Parameters.Add(cardIdParameter);
        
        rdr = cmd.ExecuteReader();
        
        while(rdr.Read())
        {
          this._turnt = GetString(0);
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
      
      public static Card Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cards WHERE id = @CardId;", conn);
      SqlParameter cardIdParameter = new SqlParameter();
      cardIdParameter.ParameterName = "@CardId";
      cardIdParameter.Value = id.ToString();
      cmd.Parameters.Add(cardIdParameter);
      rdr = cmd.ExecuteReader();

      int foundCardId = 0;
      string foundCardTheme = null;
      int foundCardPairNum = 0;
      int foundCardRandNum = 0;
      string foundCardTurnt = null;
      

      while(rdr.Read())
      {
        foundCardId = rdr.GetInt32(0);
        foundCardTheme = rdr.GetString(1);
        foundCardPairNum = rdr.GetInt32(2);
        foundCardRandNum = rdr.GetInt32(3);
        foundCardTurnt = rdr.GetString(4);
      }
      Card foundCard = new Card(foundCardTheme, foundCardPairNum, foundCardRandNum, foundCardTurnt, foundCardId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundCard;
    }
  }
}
