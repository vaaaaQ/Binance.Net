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
    
    /// <summary>
    /// Gets the margin account information.
    /// </summary>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Margin account information</returns>
    Task<WebCallResult<BinanceMarginAccountInfo>> GetAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default);
    
    /// <summary>
    /// Gets the margin max borrowable amount for a specific asset.
    /// </summary>
    /// <param name="asset">The asset to get max borrowable amount for</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Margin max borrowable amount information</returns>
    Task<WebCallResult<BinanceMarginMaxBorrowable>> GetMaxBorrowableAsync(string asset, long? receiveWindow = null, CancellationToken ct = default);
}