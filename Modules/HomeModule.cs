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
      Get["/"] = _ =>
      {
        return View["index.cshtml"];
      };
      Post["/game"] = _ = >
      {
        Game newGame = new Game(12, "harrypotter");
        return View[""]
      };
      
      Get[] = _ =>
      {
        
      };
      Post["/firstpick"] = _ =>
      {
   
        List<Card> gameCards = newGame.CreateGame();
        List<Card> randomCards = Card.GetAll();
        Card clickedCard1 = Card.Find(Request.Form["clicked-card"]);
        // bool result = Game.Check(newCard, newCard2);
        clickedCard1.SetFirstCard();
        
        List<Card> updatedBoard = Card.GetAll();
        return View["game.cshtml", updatedBoard];
      };
      
      Get[] = _ =>
      {
        
      };
      Post["/secondpick"] = _ =>
      {
        Card clickedCard2 = Card.Find(Request.Form["clicked-card2"]);
        Card clickedCard1 = Card.GetFirstCard();
        bool result = Game.Check(clickedCard1, clickedCard2);
        if(result == true)
        {
        bool winner = Game.CheckWin();
        }
        if(winner == true)
        {
          return View["winner.cshtml"];
        }
        List<Card> updatedBoard = Card.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("")
      }
    }
  }
}
