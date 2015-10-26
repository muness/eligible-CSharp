namespace EligibleService.Model
{
    public class JsonResponseClass
    {
        private string jsonResponse;

        public void SetJsonResponse(string response)
        {
            this.jsonResponse = response;
        }
        public string JsonResponse()
        {
            return jsonResponse;
        }

    }
}
