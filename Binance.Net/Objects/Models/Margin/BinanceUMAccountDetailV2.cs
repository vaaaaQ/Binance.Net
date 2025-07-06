namespace Binance.Net.Objects.Models.Margin
{
    /// <summary>
    /// Represents the UM (USDⓈ-M Futures) account detail information.
    /// </summary>
    public record BinanceUMAccountDetailV2
    {
        /// <summary>
        /// List of assets in the UM account.
        /// </summary>
        [JsonPropertyName("assets")]
        public BinanceUMAccountAssetV2[] Assets { get; set; } = Array.Empty<BinanceUMAccountAssetV2>();
        
        /// <summary>
        /// List of positions in the UM account.
        /// </summary>
        [JsonPropertyName("positions")]
        public BinanceUMAccountPositionV2[] Positions { get; set; } = Array.Empty<BinanceUMAccountPositionV2>();
    }
    
    /// <summary>
    /// Represents an asset in the UM (USDⓈ-M Futures) account detail.
    /// </summary>
    public record BinanceUMAccountAssetV2
    {
        /// <summary>
        /// Asset name.
        /// </summary>
        [JsonPropertyName("asset")]
        public string Asset { get; set; } = string.Empty;
        
        /// <summary>
        /// Wallet balance.
        /// </summary>
        [JsonPropertyName("crossWalletBalance")]
        public decimal CrossWalletBalance { get; set; }
        
        /// <summary>
        /// Unrealized profit.
        /// </summary>
        [JsonPropertyName("crossUnPnl")]
        public decimal CrossUnPnl { get; set; }
        
        /// <summary>
        /// Maintenance margin required.
        /// </summary>
        [JsonPropertyName("maintMargin")]
        public decimal MaintMargin { get; set; }
        
        /// <summary>
        /// Total initial margin required with current mark price.
        /// </summary>
        [JsonPropertyName("initialMargin")]
        public decimal InitialMargin { get; set; }
        
        /// <summary>
        /// Initial margin required for positions with current mark price.
        /// </summary>
        [JsonPropertyName("positionInitialMargin")]
        public decimal PositionInitialMargin { get; set; }
        
        /// <summary>
        /// Initial margin required for open orders with current mark price.
        /// </summary>
        [JsonPropertyName("openOrderInitialMargin")]
        public decimal OpenOrderInitialMargin { get; set; }
        
        /// <summary>
        /// Last update time.
        /// </summary>
        [JsonPropertyName("updateTime")]
        public long UpdateTime { get; set; }
    }
    
    /// <summary>
    /// Represents a position in the UM (USDⓈ-M Futures) account detail.
    /// </summary>
    public record BinanceUMAccountPositionV2
    {
        /// <summary>
        /// Symbol name.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        
        /// <summary>
        /// Initial margin required with current mark price.
        /// </summary>
        [JsonPropertyName("initialMargin")]
        public decimal InitialMargin { get; set; }
        
        /// <summary>
        /// Maintenance margin required.
        /// </summary>
        [JsonPropertyName("maintMargin")]
        public decimal MaintMargin { get; set; }
        
        /// <summary>
        /// Unrealized profit.
        /// </summary>
        [JsonPropertyName("unrealizedProfit")]
        public decimal UnrealizedProfit { get; set; }
        
        /// <summary>
        /// Position side: BOTH for One-way mode, LONG or SHORT for Hedge mode.
        /// </summary>
        [JsonPropertyName("positionSide")]
        public string PositionSide { get; set; } = string.Empty;
        
        /// <summary>
        /// Position amount.
        /// </summary>
        [JsonPropertyName("positionAmt")]
        public decimal PositionAmt { get; set; }
        
        /// <summary>
        /// Last update time.
        /// </summary>
        [JsonPropertyName("updateTime")]
        public long UpdateTime { get; set; }
        
        /// <summary>
        /// Notional value of position.
        /// </summary>
        [JsonPropertyName("notional")]
        public decimal Notional { get; set; }
    }
}
