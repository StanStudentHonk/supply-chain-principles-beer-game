using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeergameConsoleApp.supplyChainLogic
{
    public interface SupplyChainMember
    {
        public void PlayRound();
        public void PackageAndTransportIncomingOrder();
        public void AddStock(int amount);
        public void PlaceOutgoingOrder(int amount);
        public void PlaceIncomingOrder(int amount);
    }
}
