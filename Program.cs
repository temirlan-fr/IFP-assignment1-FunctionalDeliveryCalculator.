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
