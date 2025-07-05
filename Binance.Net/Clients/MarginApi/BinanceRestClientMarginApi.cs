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
        public IBinanceRestClientMarginApiAccount Account => new BinanceRestClientMarginApiAccount(this);

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

                internal async Task<WebCallResult> SendAsync(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null)
        {
            var result = await base.SendAsync(BaseAddress, definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result && result.Error!.Code == -1021 && (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp))
            {
                _logger.Log(LogLevel.Debug, "Received Invalid Timestamp error, triggering new time sync");
                _timeSyncState.LastSyncTime = DateTime.MinValue;
            }
            return result;
        }

        internal Task<WebCallResult<T>> SendAsync<T>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight);

        internal async Task<WebCallResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            var result = await base.SendAsync<T>(baseAddress, definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result && result.Error!.Code == -1021 && (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp))
            {
                _logger.Log(LogLevel.Debug, "Received Invalid Timestamp error, triggering new time sync");
                _timeSyncState.LastSyncTime = DateTime.MinValue;
            }
            return result;
        }
    }
}
