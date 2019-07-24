using System;
using System.Collections.Generic;
using System.Text;

namespace _08CreateCustomClassAttribute
{
    public class CastomAttributeAttribute : Attribute
    {
        //"Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio";


        public CastomAttributeAttribute(string author, int revision, string description,params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; set; }

        public int Revision { get; set; }

        public string Description { get; set; }

        public string[] Reviewers { get; set; }
    }
}
