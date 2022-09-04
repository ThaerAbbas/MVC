namespace FirstPro.Models
{
    public class GuessModel
    {
        public static int GuessGamenumber { get; set; }
        public static int Count { get; private set; }


      
        public static string GuessGame(int nr)
        {
           
         
           Count++;

            if (nr > GuessGamenumber)
                return "The number is Less than" +" "+ nr;

         else  if (nr < GuessGamenumber)
                return "The number is mor than" + " " + nr;
            else
                return "Yesssss you win!";
        }


        internal static int guessNum()
        {
            Random r = new Random();
            return r.Next(1, 10);
        }

    }
}
