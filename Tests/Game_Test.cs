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
    public void Dispose()
    {

    }
  }
}
