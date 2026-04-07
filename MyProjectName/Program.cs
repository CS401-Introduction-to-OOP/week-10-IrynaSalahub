using DefaultNamespace;

class Program
{
    static void Main()
    {
        var eventLog = new Eventcollection();
        var party = new Charactercollection();

        while (true)
        {
            Console.WriteLine("Оберіть головну дію: stop / create / make action");
            string input = Console.ReadLine();

            if (input == "stop") break;

            if (input == "create")
            {
                Console.WriteLine("Що створити? Person / Event");
                string input1 = Console.ReadLine();

                if (input1.ToLower() == "person")
                {
                    Console.Write("Ім'я: "); string name = Console.ReadLine();
                    Console.Write("Роль: "); string role = Console.ReadLine();
                    Console.Write("Рівень: "); float lvl = float.Parse(Console.ReadLine());
                    Console.Write("HP: "); float hp = float.Parse(Console.ReadLine());
                    Console.Write("Золото: "); float gold = float.Parse(Console.ReadLine());
                    Console.Write("Статус (Активний/Поранений/Мертвий): "); string status = Console.ReadLine();

                    party.Add(new Character(name, role, lvl, hp, gold, status));
                    Console.WriteLine("Персонаж доданий!");
                }

                if (input1.ToLower() == "event")
                {
                    Console.Write("Номер ходу: "); int num = int.Parse(Console.ReadLine());
                    Console.Write("Опис: "); string desc = Console.ReadLine();
                    Console.Write("Тип: "); string type = Console.ReadLine();
                    Console.Write("Характеристика: "); string charact = Console.ReadLine();

                    eventLog.Add(new Event(num, desc, type, charact));
                    Console.WriteLine("Подія додана!");
                }
            }

            if (input.ToLower() == "make action")
            {
                Console.WriteLine("Оберіть: show active / show persons / show events / show max gold / show groups");
                string uinp2 = Console.ReadLine();

                if (uinp2.ToLower() == "show active")
                {
                    foreach (var p in party.GetActiveCharacters()) 
                        Console.WriteLine($"Активний: {p.Name}");
                }

                if (uinp2.ToLower() == "show persons")
                {
                    foreach (var p in party) 
                        Console.WriteLine($"{p.Name} ({p.Role}) - HP: {p.HP}");
                }

                if (uinp2.ToLower() == "show events")
                {
                    foreach (var e in eventLog) 
                        Console.WriteLine($"Хід {e.MoveNumber}: {e.Description}");
                }

                if (uinp2.ToLower() == "show max gold")
                {
                    var richest = party.MostGold();
                    Console.WriteLine($"Найбагатший: {richest.Name} ({richest.Gold} золота)");
                }

                if (uinp2.ToLower() == "show groups")
                {
                    party.PrintGroupsByRole();
                }
            }
        }
    }
}