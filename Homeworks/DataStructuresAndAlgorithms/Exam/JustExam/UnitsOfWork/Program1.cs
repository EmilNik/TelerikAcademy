namespace UnitsOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var names = new HashSet<string>();
            var byAttack = new Dictionary<int, SortedSet<Unit>>();
            var attacks = new SortedSet<int>(new DescAttackComparer());
            var byType = new Dictionary<string, SortedSet<Unit>>();
            var byName = new Dictionary<string, SortedSet<Unit>>();
            var line = Console.ReadLine();
            while (line != "end")
            {
                var lineArr = line.Split(' ');
                var command = lineArr[0];
                if (command == "add")
                {
                    var name = lineArr[1];
                    var type = lineArr[2];
                    var attack = int.Parse(lineArr[3]);
                    if (!names.Contains(name))
                    {
                        var newUnit = new Unit(name, type, attack);
                        names.Add(name);
                        if (!(byName.ContainsKey(name)))
                        {
                            byName[name] = new SortedSet<Unit>();
                        }

                        if (!(byAttack.ContainsKey(attack)))
                        {
                            byAttack[attack] = new SortedSet<Unit>();
                        }

                        if (!(byType.ContainsKey(type)))
                        {
                            byType[type] = new SortedSet<Unit>();
                        }

                        byType[type].Add(newUnit);
                        byAttack[attack].Add(newUnit);
                        byName[name].Add(newUnit);
                        attacks.Add(newUnit.Attack);
                        Console.WriteLine("SUCCESS: {0} added!", name);
                    }
                    else
                    {
                        Console.WriteLine("FAIL: {0} already exists!", name);
                    }
                }
                else if (command == "remove")
                {
                    var name = lineArr[1];
                    if (!names.Contains(name))
                    {
                        Console.WriteLine("FAIL: {0} could not be found!", name);
                    }
                    else
                    {
                        var unit = byName[name].FirstOrDefault();
                        byName.Remove(name);
                        if (byAttack[unit.Attack].Count == 1)
                        {
                            byAttack.Remove(unit.Attack);
                            attacks.Remove(unit.Attack);
                        }
                        else
                        {
                            byAttack[unit.Attack].Remove(unit);
                        }

                        if (byType[unit.Type].Count == 1)
                        {
                            byType.Remove(unit.Type);
                        }
                        else
                        {
                            byType[unit.Type].Remove(unit);
                        }

                        Console.WriteLine("SUCCESS: {0} removed!", name);
                    }
                }
                else if (command == "find")
                {
                    var type = lineArr[1];
                    IEnumerable<Unit> foundUnits;
                    if (byType.ContainsKey(type))
                    {
                        foundUnits = byType[type].Take(10);
                    }
                    else
                    {
                        foundUnits = null;
                    }

                    if (foundUnits != null)
                    {
                        Console.WriteLine("RESULT: {0}", string.Join(", ", foundUnits));
                    }
                    else
                    {
                        Console.WriteLine("RESULT: ");
                    }
                }
                else // power
                {
                    var selectedAttacks = attacks.Take(15);
                    var numberOfUnits = int.Parse(lineArr[1]);

                    List<Unit> unitsasd = new List<Unit>();

                    foreach (var attack in selectedAttacks)
                    {
                        if (unitsasd.Count >= numberOfUnits)
                        {
                            break;
                        }

                        foreach (var unit in byAttack[attack])
                        {
                            if (unitsasd.Count >= numberOfUnits)
                            {
                                break;
                            }

                            unitsasd.Add(unit);
                        }
                    }

                    var foundUnits = unitsasd;

                    if (foundUnits != null)
                    {
                        Console.WriteLine("RESULT: {0}", string.Join(", ", foundUnits));
                    }
                    else
                    {
                        Console.WriteLine("RESULT: ");
                    }
                }

                line = Console.ReadLine();
            }
        }
    }

    public class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public int CompareTo(Unit other)
        {
            var attackCompareResult = this.Attack.CompareTo(other.Attack);
            attackCompareResult = 0 - attackCompareResult;
            if (attackCompareResult == 0)
            {
                var namesCompareResult = this.Name.CompareTo(other.Name);
                if (namesCompareResult == 0)
                {
                    return this.Type.CompareTo(other.Type);
                }
                else
                {
                    return namesCompareResult;
                }
            }
            else
            {
                return attackCompareResult;
            }
        }
    }

    public class DescAttackComparer : IComparer<int>
    {
        public int Compare(int attack, int other)
        {
            int ascResult = Comparer<int>.Default.Compare(attack, other);
            return 0 - ascResult;
        }
    }
}
