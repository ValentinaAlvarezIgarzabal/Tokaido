namespace Library
{
    public class TokioExperienceHandler : BaseHandler
    {
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Tokio")
            {
                return $"Hello welcome to the begining of this journey";
            }
            else
            {
                return base.Handler(request,traveller);
            }
        }
    }
}