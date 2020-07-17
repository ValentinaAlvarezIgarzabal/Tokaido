namespace Library
{
    public class EdoExperienceHandler : BaseHandler
    {
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Edo")
            {
                int money = traveller.totalMoney;
                int points = traveller.totalPoints;
                return $"This is the end, {traveller.Name} your stats are the following : /n Coins: {traveller.totalMoney} /n Points: {traveller.totalPoints}";
            }
            else
            {
                return base.Handler(request,traveller);
            }
           
        }
    }
}