using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudyBored
{
   public  class Activity
    {

        public string activity { get; set; }
        public string type { get; set; }
        public string participants { get; set; }
        public double price { get; set; }
        public string link { get; set; }
        public string key { get; set; }
        public string accessibility { get; set; }

        public List<string> favouriteList { get; set;}



        public Activity(string activity, string type, string participants, double price)
        {
            this.activity = activity;
            this.type = type;
            this.participants = participants;
            this.price = price;
            
            
        }

        public Activity()
        {
            favouriteList = new List<string>();
        }

        public void addFavourite(string nameActivity)
        {
            favouriteList.Insert(0 , nameActivity) ;
        }
    }
}
