namespace FirstPro.Models
{
    public class GuessModel
    {
        public static int GuessGamenumber { get; set; }
        public static int Count { get; private set; }

        internal static int GNR(int GuessGamenumber)
        {
            Random r = new Random();
            GuessGamenumber = r.Next(1, 100);
            return GuessGamenumber;
        }
        public static string GuessGame(int nr)
        {
            Count++;
            if (nr > GNR(GuessGamenumber))
                return "Less";

         else  if (nr < GNR(GuessGamenumber))
                return "mor";
            else
                return "yes";
        }

      
    }
}
