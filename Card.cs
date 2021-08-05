using System;
using System.Collections.Generic;

namespace ToDoApp
{

    public class Card{

        private string title;
        private string content;
        private int assigneeID; // Must be one of the team members.
        private string size; // xs,s,m,l,xl
        private Line currentLine;

        

        public Card(){


        }

        public Card(string title, string content, int assigneeID, string size, Line currentLine)
        {
            Title = title;
            Content = content;
            AssigneeID = assigneeID;
            Size = size;
            CurrentLine = currentLine;
            
        }

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public int AssigneeID { get => assigneeID; set => assigneeID = value; }
        public Line CurrentLine { get => currentLine; set => currentLine = value; }
        public string Size { get => size; set => size = value; }





    
        

        
    
    }

    enum Size
    {

        XS = 1,
        S,
        M,
        L,
        XL


    }

    

    


}

