using RestSharp;

namespace ApiTestingFramework.Client;

public class RequestBuilder
{
    private readonly RestClient client;
    public RestRequest Request { get; set; }

    public RequestBuilder(RestClient client)
    {
        this.client = client;
        Request = new RestRequest();
    }

    public RequestBuilder WithEndpoint(string endpointPath)
    {
        Request.Resource = endpointPath;
        
        return this;
    }

    public RequestBuilder WithHeader(string name, string value)
    {
        Request.AddHeader(name, value);
        return this;
    }

    public RequestBuilder WithAuthHeader(string tokenValue)
    {
        Request.AddHeader("Authorization", $"Bearer {tokenValue}");
        return this;
    }

    public RequestBuilder WithBody(object bodyJson)
    {
        Request.AddBody(bodyJson);
        return this;
    }

    public RequestBuilder WithBody(string body)
    {
        Request.AddBody(body);
        return this;
    }

    public RequestBuilder WithJsonBody(object bodyJson)
    {
        Request.AddJsonBody(bodyJson);
        return this;
    }

    public async Task<RestResponse> WithGet()
    {
        return await client.ExecuteAsync(Request, Method.Get);
    }

    public async Task<RestResponse<T>> WithGet<T>()
    {
        return await client.ExecuteGetAsync<T>(Request);
    }

    public async Task<RestResponse<T>> WithPost<T>()
    {
        return await client.ExecutePostAsync<T>(Request);
    }

    public async Task<RestResponse> WithPost()
    {
        return await client.ExecuteAsync(Request, Method.Post);
    }

    public async Task<RestResponse<T>> WithPut<T>()
    {
        return await client.ExecutePutAsync<T>(Request);
    }

    public async Task<RestResponse> WithPut()
    {
        return await client.ExecuteAsync(Request, Method.Put);
    }

    public async Task<RestResponse<T>> WithDelete<T>()
    {
        return await client.ExecuteAsync<T>(Request, Method.Delete);
    }

    public async Task<RestResponse> WithDelete()
    {
        return await client.ExecuteAsync(Request, Method.Delete);
    }

    public async Task<RestResponse> WithMethod(Method method)
    {
        return await client.ExecuteAsync(Request, method);
    }

    public async Task<RestResponse<T>> WithMethod<T>(Method method)
    {
        return await client.ExecuteAsync<T>(Request, method);
    }

    public RequestBuilder WithFormDataContentTypeHeader()
    {
        Request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        return this;
    }

    public RequestBuilder WithJsonDataContentTypeHeader()
    {
        Request.AddHeader("Content-Type", "application/json");
        return this;
    }

    public RequestBuilder WithFile(string path, string fileName)
    {
        Request.AddFile(path, fileName);

        return this;
    }
    public RequestBuilder WithFile(string name, byte[] data, string fileName, string contentType)
    {
        Request.AddFile(name, data, fileName, contentType);

        return this;
    }
}