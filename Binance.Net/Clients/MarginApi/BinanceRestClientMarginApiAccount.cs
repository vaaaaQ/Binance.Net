using Binance.Net.Clients.CoinFuturesApi;
using Binance.Net.Interfaces.Clients.MarginApi;
using Binance.Net.Objects.Models.Margin;

namespace Binance.Net.Clients.MarginApi;

internal class BinanceRestClientMarginApiAccount(BinanceRestClientMarginApi client) : IBinanceRestClientMarginApiAccount
{
    private readonly BinanceRestClientMarginApi _client = client;
    private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

    /// <summary>
    /// Gets all margin account balances.
    /// </summary>
    public async Task<WebCallResult<BinanceMarginAccountBalance[]>> GetAccountBalanceAsync(long? receiveWindow = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture));

        var request = _definitions.GetOrCreate(HttpMethod.Get, "/papi/v1/balance", BinanceExchange.RateLimiter.MarginRest, 20, true);
        return await _client.SendAsync<BinanceMarginAccountBalance[]>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets the margin account balance for a specific asset.
    /// </summary>
    public async Task<WebCallResult<BinanceMarginAccountBalance>> GetAccountBalanceAsync(string asset, long? receiveWindow = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddParameter("asset", asset);
        parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture));

        var request = _definitions.GetOrCreate(HttpMethod.Get, "/papi/v1/balance", BinanceExchange.RateLimiter.MarginRest, 20, true);
        return await _client.SendAsync<BinanceMarginAccountBalance>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets the margin account information.
    /// </summary>
    public async Task<WebCallResult<BinanceMarginAccountInfo>> GetAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture));

        var request = _definitions.GetOrCreate(HttpMethod.Get, "/papi/v1/account", BinanceExchange.RateLimiter.MarginRest, 20, true);
        return await _client.SendAsync<BinanceMarginAccountInfo>(request, parameters, ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets the margin max borrowable amount for a specific asset.
    /// </summary>
    public async Task<WebCallResult<BinanceMarginMaxBorrowable>> GetMaxBorrowableAsync(string asset, long? receiveWindow = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddParameter("asset", asset);
        parameters.AddOptionalParameter("recvWindow", receiveWindow?.ToString(CultureInfo.InvariantCulture));

        var request = _definitions.GetOrCreate(HttpMethod.Get, "/papi/v1/margin/maxBorrowable", BinanceExchange.RateLimiter.MarginRest, 5, true);
        return await _client.SendAsync<BinanceMarginMaxBorrowable>(request, parameters, ct).ConfigureAwait(false);
    }
}
