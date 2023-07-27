// See https://aka.ms/new-console-template for more information

using Advanced_Interfaces.Create_mixin;
using Advanced_Interfaces.SafelyUpdateInterfaces;

SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31))
{
    Reminders =
    {
        { new DateTime(2010, 08, 12), "childs's birthday" },
        { new DateTime(1012, 11, 15), "anniversary" }
    }
};

SampleOrder o = new SampleOrder(new DateTime(2012, 6, 1), 5m);
c.AddOrder(o);

o = new SampleOrder(new DateTime(2103, 7, 4), 25m);
c.AddOrder(o);

// <SnippetHighlightCast>
// Check the discount:
ICustomer theCustomer = c;
Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount_v1()}");
// </SnippetHighlightCast>
// </SnippetTestDefaultImplementation>

// Add more orders to get the discount:
DateTime recurring = new DateTime(2013, 3, 15);
for (int i = 0; i < 15; i++)
{
    o = new SampleOrder(recurring, 19.23m * i);
    c.AddOrder(o);

    recurring = recurring.AddMonths(2);
}

Console.WriteLine($"Data about {c.Name}");
Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
Console.WriteLine("Reminders:");
foreach (var item in c.Reminders)
{
    Console.WriteLine($"\t{item.Value} on {item.Key}");
}
foreach (IOrder order in c.PreviousOrders)
    Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");

Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount_v1()}");

// <SnippetSetLoyaltyThresholds>
ICustomer.SetLoyaltyThresholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount_v2()}");
// </SnippetSetLoyaltyThresholds>





//                       MIXIN EXAMPLE
//                     =================
//                     =================

Console.WriteLine("\r\r");
Console.WriteLine("This line is for the mixin");
Console.WriteLine("=============================");
Console.WriteLine("=============================");
Console.WriteLine("Testing the overhead light\r");
var overhead = new OverheadLight();
await TestLightCapabilities(overhead);
Console.WriteLine();

Console.WriteLine("Testing the halogen light");
var halogen = new HalogenLight();
await TestLightCapabilities(halogen);
Console.WriteLine();

Console.WriteLine("Testing the LED light");
var led = new LEDLight();
await TestLightCapabilities(led);
Console.WriteLine();

Console.WriteLine("Testing the fancy light");
var fancy = new ExtraFancyLight();
await TestLightCapabilities(fancy);
Console.WriteLine();
Console.ReadKey();

static async Task TestLightCapabilities(ILight light)
{
    // Perform basic tests:
    light.SwitchOn();
    Console.WriteLine($"\tAfter switching on, the light is {(light.IsOn() ? "on" : "off")}");
    light.SwitchOff();
    Console.WriteLine($"\tAfter switching off, the light is {(light.IsOn() ? "on" : "off")}");

    if (light is ITimerLight timer)
    {
        Console.WriteLine("\tTesting timer function");
        await timer.TurnOnFor(1000);
        Console.WriteLine("\tTimer function completed");
    }
    else
    {
        Console.WriteLine("\tTimer function not supported.");
    }

    if (light is IBlinkingLight blinker)
    {
        Console.WriteLine("\tTesting blinking function");
        await blinker.Blink(500, 5);
        Console.WriteLine("\tBlink function completed");
    }
    else
    {
        Console.WriteLine("\tBlink function not supported.");
    }
}