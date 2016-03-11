using Nancy;
using MemoryGame;
using System.Collections.Generic;
using System;

namespace MemoryGame
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Game newGame = new Game(0,"");
      Get["/"] = _ =>
      {
        return View["index.cshtml"];
      };
      Post["/game1"] = _ =>
      {
        Card.DeleteAll();
        newGame.SetDifficulty(6);
        newGame.SetTheme("harrypotter");
        List<Card> gameCards = newGame.CreateGame();
        List<Card> allCards = Card.GetAll();

        return View["game1.cshtml", allCards];
      };
      Post["/game2"] = _ =>
      {
        Card.DeleteAll();
        newGame.SetDifficulty(12);
        newGame.SetTheme("rapper");
        List<Card> gameCards = newGame.CreateGame();
        List<Card> allCards = Card.GetAll();

        return View["game2.cshtml", allCards];
      };
      Post["/game3"] = _ =>
      {
        Card.DeleteAll();
        newGame.SetDifficulty(15);
        newGame.SetTheme("cartoon");
        List<Card> gameCards = newGame.CreateGame();
        List<Card> allCards = Card.GetAll();

        return View["game3.cshtml", allCards];
      };


      Post["/secondpick"] = _ =>
      {
        Dictionary<string, object> updatedBoard = new Dictionary<string, object>();

        Card card1 = newGame.GetFirstCard();
        Card card2 = Card.Find(Request.Form["clicked-card"]);
        card2.Update("yes");

        bool result = newGame.Check(card1, card2);
        bool winner = false;
        if(result != true)
        {
          card1.Update("no");
          card2.Update("no");
        }
        if(result == true)
        {
          winner = newGame.CheckWin();
        }
        if(winner == true)
        {
          return View["winner.cshtml"];
        }
        else
        {
          List<Card> allCards = Card.GetAll();

          updatedBoard.Add("allCards", allCards);
          updatedBoard.Add("result", result);

          return View["game.cshtml", updatedBoard];
        }
      };
    }
  }
}
