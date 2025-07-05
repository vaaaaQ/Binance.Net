namespace Binance.Net.Interfaces.Clients.MarginApi;


/// <summary>
/// Interface for Binance Margin API client, providing access to margin trading and account endpoints.
/// </summary>
public interface IBinanceRestClientMarginApi : IRestApiClient, IDisposable
{
    /// <summary>
    /// Access to margin trading endpoints.
    /// </summary>
    public IBinanceRestClientMarginApiTrading Trading { get; }

    /// <summary>
    /// Access to margin account endpoints.
    /// </summary>
    public IBinanceRestClientMarginApiAccount Account { get; }
}

