using Binance.Net.Clients.CoinFuturesApi;
using Binance.Net.Interfaces.Clients.MarginApi;

namespace Binance.Net.Clients.MarginApi;

internal class BinanceRestClientMarginApiTrading(
    ILogger logger,
    BinanceRestClientMarginApi client,
    TimeSyncState timeSyncState) : IBinanceRestClientMarginApiTrading
{
    private readonly ILogger _logger = logger;
    private readonly BinanceRestClientMarginApi _client = client;
    private readonly TimeSyncState _timeSyncState = timeSyncState;
}
