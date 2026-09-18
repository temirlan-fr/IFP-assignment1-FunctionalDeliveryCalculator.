Console.Write("Базалық баға: ");
string? text = Console.ReadLine();

bool ok = decimal.TryParse(text, out decimal price);

if (ok == false)
{
    Console.WriteLine("Қате: баға сан болуы керек.");
    return;
}
if (price < 0)
{
    Console.WriteLine("Қате: баға теріс болмауы керек.");
    return;
}


Console.Write("Тауар саны: ");
string? itemsText = Console.ReadLine();

bool itemsOk = int.TryParse(itemsText, out int items);

if (itemsOk == false)
{
    Console.WriteLine("Қате: тауар саны бүтін сан болуы керек.");
    return;
}

if (items < 1)
{
    Console.WriteLine("Қате: тауар саны кемінде 1 болуы керек.");
    return;
}


Console.Write("Express (true/false): ");
string? expressText = Console.ReadLine();

bool expressOk = bool.TryParse(expressText, out bool express);

if (expressOk == false)
{
    Console.WriteLine("Қате: express үшін true немесе false жазыңыз.");
    return;
}


Console.Write("Жеткізу түрі (Pickup/Courier/DoorToDoor): ");
string? typeText = Console.ReadLine();

bool typeOk = Enum.TryParse<DeliveryType>(typeText, true, out DeliveryType type);

if (typeOk == false || Enum.IsDefined(type) == false)
{
    Console.WriteLine("Қате: жеткізу түрі Pickup, Courier немесе DoorToDoor болуы керек.");
    return;
}

Console.Write("Аймақ (City/OutsideCity/Remote): ");
string? zoneText = Console.ReadLine();

bool zoneOk = Enum.TryParse<DeliveryZone>(zoneText, true, out DeliveryZone zone);

if (zoneOk == false || Enum.IsDefined(zone) == false)
{
    Console.WriteLine("Қате: аймақ City, OutsideCity немесе Remote болуы керек.");
    return;
}

Console.WriteLine("Баға: " + price);
Console.WriteLine("Тауар саны: " + items);
Console.WriteLine("Express: " + express);
Console.WriteLine("Жеткізу түрі: " + type);
Console.WriteLine("Аймақ: " + zone);



Func<decimal, decimal> expressRule = p => p * 1.30m;
Func<decimal, decimal> roundRule = p => Math.Round(p, 2);

decimal result = price;
result = ApplyRule(result, GetItemsRule(items));
result = ApplyRule(result, GetTypeRule(type));
result = ApplyRule(result, GetZoneRule(zone));
if (express)
{
    result = ApplyRule(result, expressRule);
}
result = ApplyRule(result, roundRule);

Console.WriteLine("Соңғы баға: " + result.ToString("F2"));



static decimal ApplyRule(decimal price, Func<decimal, decimal> rule) => rule(price);

static Func<decimal, decimal> GetItemsRule(int items)
{
    if (items >= 8) return p => p * 1.20m;
    if (items >= 4) return p => p * 1.10m;
    return p => p;
}

static Func<decimal, decimal> GetTypeRule(DeliveryType type)
{
    if (type == DeliveryType.Pickup) return p => p * 0.80m;
    if (type == DeliveryType.DoorToDoor) return p => p * 1.15m;
    return p => p;
}

static Func<decimal, decimal> GetZoneRule(DeliveryZone zone)
{
    if (zone == DeliveryZone.OutsideCity) return p => p * 1.25m;
    return p => p;
}


enum DeliveryType
{
    Pickup,
    Courier,
    DoorToDoor
}

enum DeliveryZone
{
    City,
    OutsideCity,
    Remote
}
