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
      Post["/"] = _ =>
      {
        Game newGame = new Game(2, "harrypotter", 1);
        
        Card testCard = new Card("harrypotter", 1, 15, 1);
        Card testCard2 = new Card("harrypotter", 1, 15, 2);
        
        testCard.Save();
        testCard2.Save();
        
        Card newCard = Card.Find(Request.Form["card1"];
        Card newCard2 = Card.Find(Request.Form["card2"];
        
        bool result = Game.Check(newCard, newCard2);
        return View["index.cshtml", result];
      };
    }
  }
}