using Binance.Net.Clients.CoinFuturesApi;
using Binance.Net.Interfaces.Clients.MarginApi;

namespace Binance.Net.Clients.MarginApi;

internal class BinanceRestClientMarginApiAccount(
    ILogger logger,
    BinanceRestClientMarginApi client,
    TimeSyncState timeSyncState) : IBinanceRestClientMarginApiAccount
{
    private readonly ILogger _logger = logger;
    private readonly BinanceRestClientMarginApi _client = client;
    private readonly TimeSyncState _timeSyncState = timeSyncState;
}
