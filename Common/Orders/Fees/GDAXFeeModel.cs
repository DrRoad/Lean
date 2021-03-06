﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

namespace QuantConnect.Orders.Fees
{
    /// <summary>
    /// Provides an implementation of <see cref="IFeeModel"/> that models GDAX order fees
    /// </summary>
    public class GDAXFeeModel : IFeeModel
    {
        /// <summary>
        /// Get the fee for this order
        /// </summary>
        /// <param name="security">The security matching the order</param>
        /// <param name="order">The order to compute fees for</param>
        /// <returns>The cost of the order in units of the account currency</returns>
        public decimal GetOrderFee(Securities.Security security, Order order)
        {
            //0% maker fee after reimbursement.
            if (order.Type == OrderType.Limit)
            {
                return 0m;
            }

            //todo: fee scaling with trade size
            var divisor = 0.0025m;

            decimal fee = security.Price * (order.Quantity < 0 ? (order.Quantity * -1) : order.Quantity) * divisor;
            return fee;
        }
    }
}
