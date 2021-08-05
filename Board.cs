using System;
using System.Collections.Generic;

namespace ToDoApp
{

    public class Board:Operations{

        private Line toDo;
        private Line inProgress;
        private Line done;

        
        public Line InProgress { get => inProgress; set => inProgress = value; }
        public Line Done { get => done; set => done = value; }
        public Line ToDo { get => toDo; set => toDo = value; }

        public void addCard()
        {
            Console.Write("\nEnter the title : ");
            string title = Console.ReadLine();
            Console.Write("\nEnter the content : ");
            string content = Console.ReadLine();
            
            int sizeInt; 

            while(true){
                
                Console.Write("\nChoose the card size -> XS(1) - S(2) - M(3) - L(4) - XL(5) : ");
                if(int.TryParse(Console.ReadLine(),out int sizeChoice)){

                    sizeInt = sizeChoice;
                    break;

                }else{

                    Console.WriteLine("Invalid Input");

                }

            }

            Console.WriteLine("\nAvailable Team Members\n----------------------");
            foreach (var member in Team.team)
            {
                Console.WriteLine(member.Key + "." + member.Value);
            }
            Console.WriteLine("----------------------");

            
            int assigneeInt;

            while(true){
                
                Console.Write("Choose the assignee : ");
                if(int.TryParse(Console.ReadLine(),out int assigneeChoice)){

                    assigneeInt = assigneeChoice;
                    break;

                }else{

                    Console.WriteLine("Invalid Input - Check the team list out!");

                }

            }

            Card card = new Card();
            card.Title = title;
            card.Content = content;
            
            switch(sizeInt){

                case 1:
                    card.Size = Size.XS.ToString();
                    break;

                case 2:
                    card.Size = Size.S.ToString();
                    break;

                case 3:
                    card.Size = Size.M.ToString();
                    break;    
                    
                case 4:
                    card.Size = Size.L.ToString();
                    break;
                    
                case 5:
                    card.Size = Size.XL.ToString();
                    break;

            }

            card.AssigneeID = assigneeInt;
            card.CurrentLine = ToDo;

            ToDo.Cards.Add(card);
            Console.WriteLine("\nThe card with ["+card.Title+"] title is added successfully."); 



        }

        public void deleteCard()
        {
            
            Console.Write("\nEnter the title of card you want to delete : ");
            string titleSearch = Console.ReadLine();
            int counter = 0;

            for (int i=0;i<ToDo.Cards.Count;i++)
            {
                if(ToDo.Cards[i].Title == titleSearch){

                    counter++;
                    ToDo.Cards.Remove(ToDo.Cards[i]);
                    
                }
            }

            for (int i=0;i<InProgress.Cards.Count;i++)
            {
                if(InProgress.Cards[i].Title == titleSearch){

                    counter++;
                    InProgress.Cards.Remove(InProgress.Cards[i]);
                    
                }
            }

            for (int i=0;i<Done.Cards.Count;i++)
            {
                if(Done.Cards[i].Title == titleSearch){

                    counter++;
                    Done.Cards.Remove(Done.Cards[i]);
                    
                }
            }
            
            if(counter == 1){

                Console.WriteLine(counter+ " card with ["+titleSearch+"] title is deleted.");

            }else if(counter != 0){
            
                Console.WriteLine(counter+ " cards with ["+titleSearch+"] title are deleted.");
            
            }else if(counter == 0){

                Console.WriteLine("There is not a card like that on the board!");
                Console.WriteLine("-> (1) Terminate this operation\n-> (2) Try again");
                
                int oneOrTwo;

                while(true){

                    Console.Write("-> (1) or (2) : ");
                    if(int.TryParse(Console.ReadLine(),out int choice)){

                        oneOrTwo = choice;
                        break;

                    }else{

                        Console.WriteLine("Invalid Input");

                    }


                }

                switch(oneOrTwo){

                    case 1:
                        Console.WriteLine("This operation is terminated.");
                        break;

                    case 2:
                        deleteCard();
                        break;

                }


            }

            

            
        }

        public void listBoard(){

            Console.WriteLine("TO DO LINE\n************************");
            foreach (var card in ToDo.Cards)
            {
                Console.WriteLine("Title".PadRight(12)+": "+card.Title);
                Console.WriteLine("Content".PadRight(12)+": "+card.Content);
                Console.WriteLine("Assignee".PadRight(12)+": "+Team.team[card.AssigneeID]);
                Console.WriteLine("Size".PadRight(12)+": "+card.Size);
                Console.WriteLine("-+-");
            }

            Console.WriteLine("IN PROGRESS LINE\n************************");
            foreach (var card in InProgress.Cards)
            {
                Console.WriteLine("Title".PadRight(12)+": "+card.Title);
                Console.WriteLine("Content".PadRight(12)+": "+card.Content);
                Console.WriteLine("Assignee".PadRight(12)+": "+Team.team[card.AssigneeID]);
                Console.WriteLine("Size".PadRight(12)+": "+card.Size);
                Console.WriteLine("-+-");
            }

            Console.WriteLine("DONE LINE\n************************");
            foreach (var card in Done.Cards)
            {
                Console.WriteLine("Title".PadRight(12)+": "+card.Title);
                Console.WriteLine("Content".PadRight(12)+": "+card.Content);
                Console.WriteLine("Assignee".PadRight(12)+": "+Team.team[card.AssigneeID]);
                Console.WriteLine("Size".PadRight(12)+": "+card.Size);
                Console.WriteLine("-+-");
            }



        }

        public void replaceCard()
        {

            Console.Write("Enter the title of the card you want to replace : ");
            string titleR = Console.ReadLine();

            int counter = 0;
            
            // Search To Do Line
            foreach (var currentCard in ToDo.Cards)
            {
                if(currentCard.Title == titleR){

                    counter++;
                    Console.WriteLine("Information of the Card You Seached\n-----------------------------------");
                    Console.WriteLine("Title".PadRight(12)+": "+currentCard.Title);
                    Console.WriteLine("Content".PadRight(12)+": "+currentCard.Content);
                    Console.WriteLine("Assignee".PadRight(12)+": "+Team.team[currentCard.AssigneeID]);
                    Console.WriteLine("Size".PadRight(12)+": "+currentCard.Size);
                    Console.WriteLine("Current Line".PadRight(12)+": "+currentCard.CurrentLine.Name);
                    Console.WriteLine("-----------------------------------");

                    Console.WriteLine("Choose a new line for this card!");
                    Console.WriteLine("(1) TO DO\n(2) IN PROGRESS\n(3) DONE\n");

                    int newLineChoice;
                    
                    while(true){

                        Console.Write("-> (1) or (2) or (3) : ");
                        if(int.TryParse(Console.ReadLine(),out int choice)){

                            newLineChoice = choice;
                            break;

                        }else{

                            Console.WriteLine("Invalid Input");

                        }

                    }

                    switch(newLineChoice){

                        case 1:
                            ToDo.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = ToDo;
                            break;

                        case 2:    
                            InProgress.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = InProgress;
                            break;

                        case 3:
                            Done.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = Done;
                            break;    
                        

                    }

                    Console.WriteLine();
                    this.listBoard();

                    break;
                    

                    
                }
            }

            if  (counter != 0){

                titleR = "";

            }

            // Search InProgress Line
            foreach (var currentCard in InProgress.Cards)
            {
                if(currentCard.Title == titleR){

                    counter++;
                    Console.WriteLine("Information of the Card You Seached\n-----------------------------------");
                    Console.WriteLine("Title".PadRight(12)+": "+currentCard.Title);
                    Console.WriteLine("Content".PadRight(12)+": "+currentCard.Content);
                    Console.WriteLine("Assignee".PadRight(12)+": "+Team.team[currentCard.AssigneeID]);
                    Console.WriteLine("Size".PadRight(12)+": "+currentCard.Size);
                    Console.WriteLine("Current Line".PadRight(12)+": "+currentCard.CurrentLine.Name);
                    Console.WriteLine("-----------------------------------");

                    Console.WriteLine("Choose a new line for this card!");
                    Console.WriteLine("(1) TO DO\n(2) IN PROGRESS\n(3) DONE\n");

                    int newLineChoice;
                    
                    while(true){

                        Console.Write("-> (1) or (2) or (3) : ");
                        if(int.TryParse(Console.ReadLine(),out int choice)){

                            newLineChoice = choice;
                            break;

                        }else{

                            Console.WriteLine("Invalid Input");

                        }

                    }

                    switch(newLineChoice){

                        case 1:
                            ToDo.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = ToDo;
                            break;

                        case 2:    
                            InProgress.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = InProgress;
                            break;

                        case 3:
                            Done.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = Done;
                            break;    
                        

                    }

                    Console.WriteLine();
                    this.listBoard();

                    break;
                    

                    
                }
            }

            if  (counter != 0){

                titleR = "";

            }
            

            // Search Done Line
            foreach (var currentCard in Done.Cards)
            {
                if(currentCard.Title == titleR){

                    counter++;
                    Console.WriteLine("Information of the Card You Seached\n-----------------------------------");
                    Console.WriteLine("Title".PadRight(12)+": "+currentCard.Title);
                    Console.WriteLine("Content".PadRight(12)+": "+currentCard.Content);
                    Console.WriteLine("Assignee".PadRight(12)+": "+Team.team[currentCard.AssigneeID]);
                    Console.WriteLine("Size".PadRight(12)+": "+currentCard.Size);
                    Console.WriteLine("Current Line".PadRight(12)+": "+currentCard.CurrentLine.Name);
                    Console.WriteLine("-----------------------------------");

                    Console.WriteLine("Choose a new line for this card!");
                    Console.WriteLine("(1) TO DO\n(2) IN PROGRESS\n(3) DONE\n");

                    int newLineChoice;
                    
                    while(true){

                        Console.Write("-> (1) or (2) or (3) : ");
                        if(int.TryParse(Console.ReadLine(),out int choice)){

                            newLineChoice = choice;
                            break;

                        }else{

                            Console.WriteLine("Invalid Input");

                        }

                    }

                    switch(newLineChoice){

                        case 1:
                            ToDo.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = ToDo;
                            break;

                        case 2:    
                            InProgress.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = InProgress;
                            break;

                        case 3:
                            Done.Cards.Add(currentCard);
                            currentCard.CurrentLine.Cards.Remove(currentCard);
                            currentCard.CurrentLine = Done;
                            break;    
                        

                    }

                    Console.WriteLine();
                    this.listBoard();

                    break;
                    

                    
                }
            }

            if(counter == 0){

                Console.WriteLine("There is not a card like that on the board!");
                Console.WriteLine("-> (1) Terminate this operation\n-> (2) Try again");
                
                int oneOrTwo;

                while(true){

                    Console.Write("-> (1) or (2) : ");
                    if(int.TryParse(Console.ReadLine(),out int choice)){

                        oneOrTwo = choice;
                        break;

                    }else{

                        Console.WriteLine("Invalid Input");

                    }


                }

                switch(oneOrTwo){

                    case 1:
                        Console.WriteLine("This operation is terminated.");
                        break;

                    case 2:
                        replaceCard();
                        break;

                }

            }

            
        }

        
    }

    


}