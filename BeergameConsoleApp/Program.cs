using BeergameConsoleApp.supplyChainLogic;

var turns = 11;

//setup

var manufacturer = new ManuFacturer { transportOrders = new int[turns], IncomingOrders = new int[turns], DownStreamChainMember = null, Brews = new int[turns], Stock = 12 };
var retailer = new Retailer { UpStreamChainMember = null ,IncomingOrders = new int[turns], OutgoingOrders = new int[turns], Stock = 12 };
var distributer = new Distributor { UpStreamChainMember = manufacturer, transportOrders = new int[turns], IncomingOrders = new int[turns], DownStreamChainMember = null, OutgoingOrders = new int[turns], Stock = 12};
var wholesaler = new Wholesaler { UpStreamChainMember = distributer, transportOrders = new int[turns], IncomingOrders = new int[turns], DownStreamChainMember = retailer, OutgoingOrders = new int[turns], Stock = 12 };

retailer.UpStreamChainMember = wholesaler;
manufacturer.DownStreamChainMember = distributer;
distributer.DownStreamChainMember = wholesaler;


// round 1
retailer.PlaceOutgoingOrder(8);
wholesaler.PlaceOutgoingOrder(7);
distributer.PlaceOutgoingOrder(3);
manufacturer.PlaceOutgoingOrder(2);

retailer.PlayRound();
Console.WriteLine("");
Console.WriteLine("Retailer stock = " + retailer.Stock + " Retailer backlog = " + retailer.Backlog);
Console.WriteLine("Wholesaler stock = " + wholesaler.Stock + " Wholesaler backlog = " + wholesaler.Backlog);
Console.WriteLine("Distributer stock = " + distributer.Stock + " Distributer backlog = " + distributer.Backlog);
Console.WriteLine("ManuFacturer stock = " + manufacturer.Stock + " Manufacturer backlog = " + manufacturer.Backlog);


//round 2
retailer.PlaceOutgoingOrder(2);
wholesaler.PlaceOutgoingOrder(6);
distributer.PlaceOutgoingOrder(5);
manufacturer.PlaceOutgoingOrder(4);

retailer.PlayRound();
Console.WriteLine("");
Console.WriteLine("Retailer stock = " + retailer.Stock + " Retailer backlog = " + retailer.Backlog);
Console.WriteLine("Wholesaler stock = " + wholesaler.Stock + " Wholesaler backlog = " + wholesaler.Backlog);
Console.WriteLine("Distributer stock = " + distributer.Stock + " Distributer backlog = " + distributer.Backlog);
Console.WriteLine("ManuFacturer stock = " + manufacturer.Stock + " Manufacturer backlog = " + manufacturer.Backlog);

//round 3
retailer.PlaceOutgoingOrder(2);
wholesaler.PlaceOutgoingOrder(2);
distributer.PlaceOutgoingOrder(3);
manufacturer.PlaceOutgoingOrder(2);

retailer.PlayRound();
Console.WriteLine("");
Console.WriteLine("Retailer stock = " + retailer.Stock + " Retailer backlog = " + retailer.Backlog);
Console.WriteLine("Wholesaler stock = " + wholesaler.Stock + " Wholesaler backlog = " + wholesaler.Backlog);
Console.WriteLine("Distributer stock = " + distributer.Stock + " Distributer backlog = " + distributer.Backlog);
Console.WriteLine("ManuFacturer stock = " + manufacturer.Stock + " Manufacturer backlog = " + manufacturer.Backlog);

////round 4
retailer.PlaceOutgoingOrder(2);
wholesaler.PlaceOutgoingOrder(8);
distributer.PlaceOutgoingOrder(3);
manufacturer.PlaceOutgoingOrder(2);

retailer.PlayRound();

Console.WriteLine("");
Console.WriteLine("Retailer stock = " + retailer.Stock + " Retailer backlog = " + retailer.Backlog);
Console.WriteLine("Wholesaler stock = " + wholesaler.Stock + " Wholesaler backlog = " + wholesaler.Backlog);
Console.WriteLine("Distributer stock = " + distributer.Stock + " Distributer backlog = " + distributer.Backlog);
Console.WriteLine("ManuFacturer stock = " + manufacturer.Stock + " Manufacturer backlog = " + manufacturer.Backlog);

////round5
retailer.PlaceOutgoingOrder(2);
wholesaler.PlaceOutgoingOrder(4);
distributer.PlaceOutgoingOrder(3);
manufacturer.PlaceOutgoingOrder(2);

retailer.PlayRound();

Console.WriteLine("");
Console.WriteLine("Retailer stock = " + retailer.Stock + " Retailer backlog = " + retailer.Backlog);
Console.WriteLine("Wholesaler stock = " + wholesaler.Stock + " Wholesaler backlog = " + wholesaler.Backlog);
Console.WriteLine("Distributer stock = " + distributer.Stock + " Distributer backlog = " + distributer.Backlog);
Console.WriteLine("ManuFacturer stock = " + manufacturer.Stock + " Manufacturer backlog = " + manufacturer.Backlog);



