namespace Binance.Net.Objects.Models.Margin
{
    /// <summary>
    /// Represents a margin account balance on Binance.
    /// </summary>
    public record BinanceMarginAccountBalance
    {
        /// <summary>
        /// The asset symbol.
        /// </summary>
        [JsonPropertyName("asset")]
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// The total wallet balance.
        /// </summary>
        [JsonPropertyName("totalWalletBalance")]
        public decimal TotalWalletBalance { get; set; }

        /// <summary>
        /// The cross margin asset (optional, present only in the full response).
        /// </summary>
        [JsonPropertyName("crossMarginAsset")]
        public decimal? CrossMarginAsset { get; set; }

        /// <summary>
        /// The amount borrowed in cross margin.
        /// </summary>
        [JsonPropertyName("crossMarginBorrowed")]
        public decimal CrossMarginBorrowed { get; set; }

        /// <summary>
        /// The free amount in cross margin.
        /// </summary>
        [JsonPropertyName("crossMarginFree")]
        public decimal CrossMarginFree { get; set; }

        /// <summary>
        /// The interest in cross margin.
        /// </summary>
        [JsonPropertyName("crossMarginInterest")]
        public decimal CrossMarginInterest { get; set; }

        /// <summary>
        /// The locked amount in cross margin.
        /// </summary>
        [JsonPropertyName("crossMarginLocked")]
        public decimal CrossMarginLocked { get; set; }

        /// <summary>
        /// The wallet balance for UM (USDⓈ-M Futures).
        /// </summary>
        [JsonPropertyName("umWalletBalance")]
        public decimal UmWalletBalance { get; set; }

        /// <summary>
        /// The unrealized PNL for UM (optional, can be empty in response).
        /// </summary>
        [JsonPropertyName("umUnrealizedPNL")]
        public decimal? UmUnrealizedPNL { get; set; }

        /// <summary>
        /// The wallet balance for CM (COIN-M Futures).
        /// </summary>
        [JsonPropertyName("cmWalletBalance")]
        public decimal CmWalletBalance { get; set; }

        /// <summary>
        /// The unrealized PNL for CM (optional, can be empty in response).
        /// </summary>
        [JsonPropertyName("cmUnrealizedPNL")]
        public decimal? CmUnrealizedPNL { get; set; }

        /// <summary>
        /// The update time.
        /// </summary>
        [JsonPropertyName("updateTime")]
        public long UpdateTime { get; set; }

        /// <summary>
        /// The negative balance.
        /// </summary>
        [JsonPropertyName("negativeBalance")]
        public decimal NegativeBalance { get; set; }
    }
}