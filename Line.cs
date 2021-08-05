using System;
using System.Collections.Generic;

namespace ToDoApp
{

    public class Line{

        private string name;
        private List<Card> cards;

        public List<Card> Cards { get => cards; set => cards = value; }
        public string Name { get => name; set => name = value; }
    }


}