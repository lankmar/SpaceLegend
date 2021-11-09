namespace Geekbrains.Test
{
    public readonly struct Data
    {
        public int Damage { get; }
        public string Name { get; }

        public Data(int damage, string name)
        {
            Damage = damage;
            Name = name;
        }

        public override string ToString()
        {
            return $"Name {Name} - {Damage}";
        }
    }
}
