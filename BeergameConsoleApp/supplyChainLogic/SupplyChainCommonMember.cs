using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeergameConsoleApp.supplyChainLogic
{
    public abstract class SupplyChainCommonMember : SupplyChainMember
    {
        public string Name { get; set; }
        public int WeekNumber { get; set; } = 0;
        public int Stock { get; set; } = 12;
        public int Backlog { get; set; } = 0;
        public SupplyChainMember DownStreamChainMember { get; set; }
        public SupplyChainMember UpStreamChainMember { get; set; }
        public int[] transportOrders { get; set; }
        public int[] IncomingOrders { get; set; }
        public int[] OutgoingOrders { get; set; }


        public void PlayRound()
        {
            // send placed outgoing order to upstream chain member
            UpStreamChainMember.PlaceIncomingOrder(OutgoingOrders[WeekNumber]);

            // add stock to downstream chainmember
           
            PackageAndTransportIncomingOrder();
            DownStreamChainMember.AddStock(transportOrders[WeekNumber]);
            WeekNumber++;
            this.UpStreamChainMember.PlayRound();
        }

        public void PackageAndTransportIncomingOrder()
        {
            int amountOrdered = IncomingOrders[WeekNumber];
            int amountTransported = amountOrdered;
            Stock -= amountOrdered;
            if (Stock < 0)
            {
                Backlog -= Stock;
                amountTransported += Stock;
                Stock = 0;
            }


            transportOrders[WeekNumber + 2] = amountTransported;
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
                Backlog -= removedFromBacklog;
                transportOrders[WeekNumber + 1] += removedFromBacklog;
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
