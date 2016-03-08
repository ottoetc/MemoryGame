using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MemoryGame
{
  public class CardTest : IDisposable
  {
    public CardTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=memory_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_GetAll()
    {
      Game testGame = new Game(12, "harrypotter");
      List<Card> gameCards = testGame.CreateGame();
      List<Card> allCards = Card.GetAll();
      foreach(var card in allCards)
      {
        Console.WriteLine("Test GetAll: Card ID: " + card.GetId() + " Card PairNum: " + card.GetPairNum() + " Card RandNum: " + card.GetRandNum());
      }
      Assert.Equal(allCards.Count, gameCards.Count);
    }
    public void Dispose()
    {
      Card.DeleteAll();
    }
  }
}
