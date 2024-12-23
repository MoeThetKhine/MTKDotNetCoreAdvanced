namespace MTKDotNetCoreAdvancedC_.RestClient
{
    public class RestClientService
    {
        public async Task<T> ExecuteAsync<T>(string endpoint, EnumHttpMethod httpMethod, object? requestModel = null)
        {
            RestSharp.RestClient client = new("");
            RestRequest request = new(endpoint);
            RestResponse? response = null;

            if(requestModel is not null)
            {
                string jsonStr = JsonConvert.SerializeObject(requestModel);
                request.AddJsonBody(jsonStr);
            }
            switch(httpMethod)
            {
                case EnumHttpMethod.GET:
                    response = await client.GetAsync(request);
                    break;
                case EnumHttpMethod.POST:
                    response = await client.PostAsync(request);
                    break;
                case EnumHttpMethod.PUT:
                    response = await client.PutAsync(request);
                    break;
                case EnumHttpMethod.PATCH:
                    response = await client.PatchAsync(request);
                    break;
                case EnumHttpMethod.DELETE:
                    response = await client.DeleteAsync(request);
                    break;
                default:
                    break;
            }
            string jsonResponse = response!.Content!;
            return JsonConvert.DeserializeObject<T>(jsonResponse)!;
        }
    }
}
