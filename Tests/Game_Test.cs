using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MemoryGame
{
  public class GameTest : IDisposable
  {
    public GameTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=memory_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_CreateGame()
    {
      Game testGame = new Game(12, "harrypotter");
      List<Card> allCards = testGame.CreateGame();
      foreach(var card in allCards)
      {
        Console.WriteLine("Card ID: " + card.GetId() + " Card PairNum: " + card.GetPairNum() + " Card RandNum: " + card.GetRandNum());
      }
      Assert.Equal(allCards.Count, 24);
    }
    [Fact]
    public void Test_CardsMatchTrue()
    {
      Card testCard = new Card("harrypotter", 1, 12, 1);
      Card testCard2 = new Card("harrypotter", 1, 23, 2);
      Game testGame = new Game(0, "test");
      bool result = testGame.Check(testCard, testCard2);
      Console.WriteLine("Card1: ID" + testCard.GetId() + " PairNum: " + testCard.GetPairNum() + " RandNum: " + testCard.GetRandNum());
      Console.WriteLine("Card2: ID" + testCard2.GetId() + " PairNum: " + testCard2.GetPairNum() + " RandNum: " + testCard2.GetRandNum());
      Console.WriteLine("Result: " + result);
      bool test = true;
      Assert.Equal(result, test);
    }
    [Fact]
    public void Test_CardsMatchFalse()
    {
      Card testCard = new Card("harrypotter", 1, 12, 1);
      Card testCard2 = new Card("harrypotter", 2, 23, 2);
      Game testGame = new Game(0, "test");
      bool result = testGame.Check(testCard, testCard2);
      Console.WriteLine("Card1: ID" + testCard.GetId() + " PairNum: " + testCard.GetPairNum() + " RandNum: " + testCard.GetRandNum());
      Console.WriteLine("Card2: ID" + testCard2.GetId() + " PairNum: " + testCard2.GetPairNum() + " RandNum: " + testCard2.GetRandNum());
      Console.WriteLine("Result: " + result);
      bool test = false;
      Assert.Equal(result, test);
    }
    public void Dispose()
    {
      Card.DeleteAll();
    }
  }
}
