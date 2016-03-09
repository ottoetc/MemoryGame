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

        Card testCard = new Card("harrypotter", 1, 15, 0);
        testCard.Save();
        Card testCard2 = new Card("harrypotter", 5, 35, 1);
        testCard2.Save();

        Card newCard = Card.Find(Request.Form["card1"]);
        Console.WriteLine(newCard.GetPairNum());

        int numb = Request.Form["card2"];

              Console.WriteLine(numb);
        Card newCard2 = Card.Find(numb);

        Console.WriteLine(newCard2.GetPairNum());

        bool result = newGame.Check(newCard, newCard2);
        return View["index.cshtml", result];
      };
    }
  }
}
