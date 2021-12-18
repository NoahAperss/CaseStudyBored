using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudyBored
{
    class FavouriteActivity : Activity
    {


        public bool isFavourite { get; set; }

        public FavouriteActivity()
        {
        }

        public FavouriteActivity(string activity, string type, string participants, double price) : base(activity, type, participants, price)
        {
            isFavourite = true;
        }

        
        
        
    }
}
