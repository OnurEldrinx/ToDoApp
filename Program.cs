using System;
using System.Collections.Generic;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Board Initialization
            Board board = new Board();
            
            board.ToDo = new Line();
            board.ToDo.Cards = new List<Card>();
            board.ToDo.Name = "To Do";

            board.InProgress = new Line();
            board.InProgress.Cards = new List<Card>();
            board.InProgress.Name = "In Progress"; 


            board.Done = new Line();
            board.Done.Cards = new List<Card>();
            board.Done.Name = "Done";
            
            // Default Cards
            Card card1 = new Card("CyberLink Calculations","Review the calculations again.",1,Size.M.ToString(),board.ToDo);
            Card card2 = new Card("Business Meeting","Investors are coming for Amazon",5,Size.L.ToString(),board.InProgress);
            Card card3 = new Card("Instagram Negotiations","Try to buy Instagram",4,Size.XL.ToString(),board.Done);

            board.ToDo.Cards.Add(card1);
            board.InProgress.Cards.Add(card2);
            board.Done.Cards.Add(card3);

            string menu = "\nOperations\n----------\n" +
                          "-> 1.List the board\n" +
                          "-> 2.Add a new card\n" +
                          "-> 3.Delete a card\n" +
                          "-> 4.Replace a card\n" +
                          "-> 0.Exit\n" ;

            bool flag = true;

            while(flag){

                Console.WriteLine(menu);

                Console.Write("\nYour Choice : ");
                int choice = int.Parse(Console.ReadLine());

                switch(choice){

                    case 1:
                        board.listBoard();
                        break;
                    case 2:
                        board.addCard();
                        break;
                    case 3:
                        board.deleteCard();
                        break;
                    case 4:
                        board.replaceCard();
                        break;
                    case 0:
                        Console.WriteLine("\n>> Program is terminated.\n>> Have a nice day.");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input");
                        break;        


                }


            }              
            



            

        }
    }
}
