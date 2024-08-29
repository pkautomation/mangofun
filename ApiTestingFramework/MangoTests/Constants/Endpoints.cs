namespace MangoTests.Constants;
internal class Endpoints
{
    private string baseUrl;
    public string Token() => $"{baseUrl}/v2.01/oauth/token";
    public string NaturalUser(string clientId) => $"{baseUrl}/v2.01/{clientId}/users/natural";
    public string Wallet(string clientId) => $"{baseUrl}/v2.01/{clientId}/wallets";

    public Endpoints(string baseUrl)
    {
        this.baseUrl = baseUrl;
    }
}
