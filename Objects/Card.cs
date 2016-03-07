Using System;
Using System.Collections.Generic;

namespace MemoryGame
  {
    public class Card
    {
      private int _id;
      private string _cardBack;
      private string _cardFront;
      private int _pairNum;
      
      
      public Card(int cardBack, string cardFront, int Id = 0)
      {
        _cardBack = cardBack;
        _cardFront = cardFront;
        _id = Id;
        _pairNum = 
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
          bool cardBackEquality = this.GetCardBack() == newCard.GetCardBack();
          bool cardFrontEquality = this.GetCardFront() == newCard.GetCardFront();
          return (idEquality && cardBackEquality && cardFrontEquality);
        }
      }
      
      public int GetId()
      {
        return _id;
      }
      public string GetCardBack()
      {
        return _cardBack;
      }
      public void SetCardBack(string newCardBack)
      {
        _cardBack = newCardBack;
      }
      public string GetCardFront()
      {
        return _cardFront;
      }
      public void SetCardFront(string newCardFront)
      {
        _cardFront = newCardFront;
      }
      
      public void Save()
      {
        SqlConnection conn = DB.Connection();
        SqlDataReader rdr;
        conn.Open();
        
        SqlCommand cmd = new SqlCommand("INSERT INTO cards (cardback, cardfront) OUTPUT INSERTED.id VALUES(@CardBack, @CardFront);"; conn);
        
        SqlParameter cardBackParameter = new SqlParameter();
        cardBackParameter.ParameterName = "@CardBack";
        cardBackParameter.Value = this.GetCardBack();
        
        SqlParameter cardFrontParameter = new SqlParameter();
        cardFrontParameter.ParameterName = "@CardFront";
        cardFrontParameter.Value = this.GetCardFront();
        
        cmd.Parameters.Add(cardFrontParameter);
        cmd.Parameters.Add(cardBackParameter);
        
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
      
      
    }
  }
