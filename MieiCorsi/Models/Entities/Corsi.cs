using MieiCorsi.Models.ValueTypes;
using System;
using System.Collections.Generic;

namespace MieiCorsi.Models.Entities
{
    public partial class Corsi
    {
        public Corsi(String title,String author, String email)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("The Corse must have a title.");
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("The Corse must have an author.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("The Corse must have an email");
            }

            Title = title;
            Author = author;
            Email = email;
            Lessons = new HashSet<Lessons>();
        }

        public int Id { get;private set; }
        public string Title { get;private set; }
        public string Description { get;private set; }
        public string ImagePath { get;private set; }
        public string Author { get;private set; }
        public string Email { get;private set; }
        public float Rating { get;private set; }
        public Money FullPrice { get;private set; }
 
        public Money CurrentPrice { get;private set; }
  

        public virtual ICollection<Lessons> Lessons { get;private set; }

        public void ChangeTitle(String newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("The Corse must have a title.");
            }
            Title = newTitle;

        }

        public void ChangePrice(Money newFullPrice, Money newDiscountPrice)
        {
            if(newFullPrice==null || newDiscountPrice == null)
            {
                throw new ArgumentException("price can't be null");
            }
            if (newFullPrice.Currency != newDiscountPrice.Currency)
            {
                throw new ArgumentException("Currency don't match");
            }
            if (newFullPrice.Amount > newDiscountPrice.Amount)
            {
                throw new ArgumentException("Full price can't be less than current price");
            }
            FullPrice = newFullPrice;
            CurrentPrice = newDiscountPrice;

        }
    }
}
