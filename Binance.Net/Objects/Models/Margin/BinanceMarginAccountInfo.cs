using System;

namespace Binance.Net.Objects.Models.Margin
{
    /// <summary>
    /// Represents margin account information on Binance.
    /// </summary>
    public record BinanceMarginAccountInfo
    {
        /// <summary>
        /// Portfolio margin account maintenance margin rate.
        /// </summary>
        [JsonPropertyName("uniMMR")]
        public decimal UniMMR { get; set; }

        /// <summary>
        /// Account equity, in USD value.
        /// </summary>
        [JsonPropertyName("accountEquity")]
        public decimal AccountEquity { get; set; }

        /// <summary>
        /// Account equity without collateral rate, in USD value.
        /// </summary>
        [JsonPropertyName("actualEquity")]
        public decimal ActualEquity { get; set; }

        /// <summary>
        /// Account initial margin.
        /// </summary>
        [JsonPropertyName("accountInitialMargin")]
        public decimal AccountInitialMargin { get; set; }

        /// <summary>
        /// Portfolio margin account maintenance margin, unit: USD.
        /// </summary>
        [JsonPropertyName("accountMaintMargin")]
        public decimal AccountMaintMargin { get; set; }

        /// <summary>
        /// Portfolio margin account status: "NORMAL", "MARGIN_CALL", "SUPPLY_MARGIN", "REDUCE_ONLY", "ACTIVE_LIQUIDATION", "FORCE_LIQUIDATION", "BANKRUPTED".
        /// </summary>
        [JsonPropertyName("accountStatus")]
        public string AccountStatus { get; set; } = string.Empty;

        /// <summary>
        /// Portfolio margin maximum amount for transfer out in USD.
        /// </summary>
        [JsonPropertyName("virtualMaxWithdrawAmount")]
        public decimal VirtualMaxWithdrawAmount { get; set; }

        /// <summary>
        /// Total available balance.
        /// </summary>
        [JsonPropertyName("totalAvailableBalance")]
        public decimal? TotalAvailableBalance { get; set; }

        /// <summary>
        /// Total margin open loss, in USD.
        /// </summary>
        [JsonPropertyName("totalMarginOpenLoss")]
        public decimal? TotalMarginOpenLoss { get; set; }

        /// <summary>
        /// Last update time.
        /// </summary>
        [JsonPropertyName("updateTime")]
        public long UpdateTime { get; set; }
    }
}
