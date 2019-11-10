using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmanjit_race_assignment
{
   public class Player
    {

        // global variable 
        String Name = "";
        int Budget = 0;
        int dog = 0;
        int bet = 0;
        

        // constructor method 
        public Player(String Name ,int Budget,int dog,int bet) {
            this.Name = Name;
            this.Budget = Budget;
            this.dog = dog;
            this.bet = bet;
        }



        // reset the budget no 
        public String result(int winer) {
            if (dog == winer)
            {
                Budget += bet;
                return Name + "'s Budget is "+ Budget+" Dollar";
            }
            else {
                Budget -= bet;
                return Name + "'s Budget is " + Budget + " Dollar";
            }
        }

    }
}
