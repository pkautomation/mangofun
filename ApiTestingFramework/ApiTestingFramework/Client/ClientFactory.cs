namespace ApiTestingFramework.Client;

public static class ClientFactory
{
    public static RequestBuilder Create()
    {
        return new RequestBuilder(new RestSharp.RestClient());
    }
}
