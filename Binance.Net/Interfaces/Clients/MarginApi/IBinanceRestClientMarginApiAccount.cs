using Binance.Net.Objects.Models.Margin;

namespace Binance.Net.Interfaces.Clients.MarginApi;

/// <summary>
/// Interface for Binance Margin API account endpoints, providing methods to retrieve margin account balances.
/// </summary>
public interface IBinanceRestClientMarginApiAccount
{
    /// <summary>
    /// Gets all margin account balances.
    /// </summary>
    Task<WebCallResult<BinanceMarginAccountBalance[]>> GetAccountBalanceAsync(long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Gets the margin account balance for a specific asset.
    /// </summary>
    Task<WebCallResult<BinanceMarginAccountBalance>> GetAccountBalanceAsync(string asset, long? receiveWindow = null, CancellationToken ct = default);
}