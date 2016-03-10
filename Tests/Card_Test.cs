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
    [Fact]
    public void Test_Find()
    {
      Card testCard = new Card("harrypotter", 1, 10, "false", 1);
      testCard.Save();
      Card foundCard = Card.Find(1);
      Console.WriteLine("Test Find: TestCard ID: " + testCard.GetId());
      Console.WriteLine("Test Find: FoundCard ID: " + foundCard.GetId());
      Assert.Equal(testCard, foundCard);
    }
    public void Dispose()
    {
      Card.DeleteAll();
    }
  }
}
