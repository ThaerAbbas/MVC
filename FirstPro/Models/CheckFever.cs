namespace FirstPro.Models
{
    public class CheckFever

    {
        public static string CheckTemp(int temp)
        {
            if (temp < 35)
                return "You have hypothermia";

            if (temp >= 38)
                return "You have fever ";
            else
                return "Nothing";

        }
    }
}
