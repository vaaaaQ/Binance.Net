using Binance.Net.Interfaces.Clients.CoinFuturesApi;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.SharedApis;
using Binance.Net.Objects.Options;
using Binance.Net.Interfaces.Clients.MarginApi;
using Binance.Net.Clients.MarginApi;

namespace Binance.Net.Clients.CoinFuturesApi
{
    internal partial class BinanceRestClientMarginApi : RestApiClient, IBinanceRestClientMarginApi
    {
        #region clients
        public IBinanceRestClientMarginApiTrading Trading => new BinanceRestClientMarginApiTrading(_logger, this, _timeSyncState);
        public IBinanceRestClientMarginApiAccount Account => new BinanceRestClientMarginApiAccount(_logger, this, _timeSyncState);

        #endregion

        internal static TimeSyncState _timeSyncState = new TimeSyncState("Margin Api");

        public BinanceRestClientMarginApi(ILogger logger, HttpClient? httpClient, BinanceRestOptions options)
        : base(logger, httpClient, options.Environment.MarginAccountRestAddress!, options, options.CoinFuturesOptions)
        {
        }
        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BinanceExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        public override TimeSpan? GetTimeOffset()
             => _timeSyncState.TimeOffset;

        public override TimeSyncInfo? GetTimeSyncInfo()
                    => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), _timeSyncState);


        protected override IStreamMessageAccessor CreateAccessor() => new SystemTextJsonStreamMessageAccessor(SerializerOptions.WithConverters(BinanceExchange._serializerContext));

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BinanceAuthenticationProvider(credentials);

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BinanceExchange._serializerContext));
    }
}
