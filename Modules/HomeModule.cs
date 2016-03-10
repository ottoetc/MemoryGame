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
      Post["/game"] = _ =>
      {
        newGame.SetDifficulty(Request.Form["game-difficulty"]);
        newGame.SetTheme(Request.Form["game-theme"]);
        List<Card> gameCards = newGame.CreateGame();
        List<Card> allCards = Card.GetAll();

        Dictionary<string, object> gameBoard = new Dictionary<string, object>();
        gameBoard.Add("allCards", allCards);

        return View["game.cshtml", gameBoard];
      };

      Get["/firstpick"] = _ =>
      {
        Dictionary<string, object> updatedBoard = new Dictionary<string, object>();

        List<Card> allCards = Card.GetAll();

        updatedBoard.Add("allCards", allCards);

        return View["game.cshtml", updatedBoard];
      };
      Post["/firstpick"] = _ =>
      {
        Dictionary<string, object> updatedBoard = new Dictionary<string, object>();


        Card clickedCard1 = Card.Find(Request.Form["clicked-card"]);

        clickedCard1.Update("yes");

        newGame.SetFirstCard(clickedCard1);

        List<Card> allCards = Card.GetAll();

        updatedBoard.Add("allCards", allCards);

        return View["game.cshtml", updatedBoard];
      };

      Get["/secondpick"] = _ =>
      {
        Dictionary<string, object> updatedBoard = new Dictionary<string, object>();

        List<Card> allCards = Card.GetAll();
        Card card1 = newGame.GetFirstCard();

        updatedBoard.Add("allCards", allCards);

        return View["index.cshtml", updatedBoard];
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
