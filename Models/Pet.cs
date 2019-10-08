using System;

namespace Dojodachi.Models
{
    public class Pet
    {
        public int Fullness { get; set; }
        public int Happiness { get; set; }
        public int Meal { get; set; }
        public int Energy { get; set; }
        
        public Pet()
        {
            Fullness = 20;
            Happiness = 20;
            Meal = 3;
            Energy = 50;
        }

        public int Feed()
        {
            Random rand = new Random();
            int v = rand.Next(1,101);
            if(Meal > 0)
            {
                Meal -= 1; 
                if(v <= 75)
                {                                  
                    int fullnessGain = rand.Next(5,11);
                    Fullness += fullnessGain;
                    return fullnessGain;
                }
                else
                {
                    return 0;
                }               
            }
            return 0;
        }

        public int Play()
        {
            Random rand = new Random();
            int v = rand.Next(1,101);
            Energy -= 5;
            if(v <= 75)
            {
                int happinessGain = rand.Next(5,11);
                Happiness += happinessGain;
                return happinessGain;
            }
            return 0;            
        }

        public int Work()
        {
            Random rand = new Random();
            Energy -= 5;
            int mealGain = rand.Next(1,4);
            Meal += mealGain;
            return mealGain;
        }

        public void Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
        }

    }
}