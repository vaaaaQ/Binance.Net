using System;

namespace Binance.Net.Objects.Models.Margin
{
    /// <summary>
    /// Represents margin max borrowable amount information on Binance.
    /// </summary>
    public record BinanceMarginMaxBorrowable
    {
        /// <summary>
        /// Account's currently max borrowable amount with sufficient system availability.
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Max borrowable amount limited by the account level.
        /// </summary>
        [JsonPropertyName("borrowLimit")]
        public decimal BorrowLimit { get; set; }
    }
}
