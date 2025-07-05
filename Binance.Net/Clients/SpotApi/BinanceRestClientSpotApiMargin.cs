using Binance.Net.Interfaces.Clients.SpotApi;

namespace Binance.Net.Clients.SpotApi
{
    /// <inheritdoc />
    internal class BinanceRestClientSpotApiMargin : IBinanceRestClientSpotApiMargin
    {
        private readonly BinanceRestClientSpotApi _baseClient;
        private readonly ILogger _logger;

        internal BinanceRestClientSpotApiMargin(ILogger logger, BinanceRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
            _logger = logger;
        }
    }
}
