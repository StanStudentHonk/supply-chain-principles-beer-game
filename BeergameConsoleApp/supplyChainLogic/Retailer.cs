﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeergameConsoleApp.supplyChainLogic
{
    public class Retailer : SupplyChainMember
    {
        public string Name { get; set; }
        public int WeekNumber { get; set; } = 0;
        public int Stock { get; set; } = 12;
        public int Backlog { get; set; } = 0;
        public SupplyChainMember UpStreamChainMember { get; set; }
        public int[] IncomingOrders { get; set; }
        public int[] OutgoingOrders { get; set; }

        public void PlayRound()
        {
            var random = new Random();
            this.PlaceIncomingOrder(random.Next(2, 5));
            PackageAndTransportIncomingOrder();
            // send placed outgoing order to upstream chain member
            if (UpStreamChainMember != null)
            {
                UpStreamChainMember.PlaceIncomingOrder(OutgoingOrders[WeekNumber]);
            }

            WeekNumber++;
            this.UpStreamChainMember.PlayRound();
        }

        public void PackageAndTransportIncomingOrder()
        {
            int amountOrdered = IncomingOrders[WeekNumber];
            Stock -= amountOrdered;
            if (Stock < 0)
            {
                Backlog -= Stock;
                Stock = 0;
            }
        }

        public void AddStock(int amount)
        {
            var addToStock = amount - Backlog;
            var removedFromBacklog = amount;
            if (addToStock > 0)
            {
                removedFromBacklog = amount - addToStock;
                Stock += addToStock;
            }
            if (removedFromBacklog > 0)
            {
                Backlog += removedFromBacklog;
            }
        }
        public void PlaceOutgoingOrder(int amount)
        {
            OutgoingOrders[WeekNumber] = amount;
        }

        public void PlaceIncomingOrder(int amount)
        {
            IncomingOrders[WeekNumber] = amount;
        }
    }
}
