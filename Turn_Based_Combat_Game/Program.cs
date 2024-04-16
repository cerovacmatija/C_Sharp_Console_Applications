using System;

interface IEntityActions<T>
{
    void AttackTarget(T target);
    void Heal();
}

abstract class Entity<T> : IEntityActions<T>
{
    public int Hp { get; protected set; }
    public int Attack { get; protected set; }
    public int HealAmount { get; protected set; }

    public Entity(int hp, int attack, int healAmount)
    {
        Hp = hp;
        Attack = attack;
        HealAmount = healAmount;
    }

    public abstract void TakeDamage(int damage);
    public abstract void Heal();
    public abstract void AttackTarget(T target);
    public bool IsAlive() => Hp > 0;
}

class Character : Entity<Character>
{
    public Character(int hp, int attack, int healAmount) : base(hp, attack, healAmount)
    {
    }

    public override void TakeDamage(int damage)
    {
        Hp -= damage;
    }

    public override void Heal()
    {
        Hp += HealAmount;
    }

    public override void AttackTarget(Character target)
    {
        target.TakeDamage(Attack);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Character player = new Character(40, 5, 5);
        Character enemy = new Character(20, 7, 5);

        Random random = new Random();
        string choice;

        while (player.IsAlive() && enemy.IsAlive())
        {
            Console.WriteLine("-- Player turn --");
            Console.WriteLine("Player Hp - " + player.Hp + ". Enemy Hp - " + enemy.Hp + ".");
            Console.WriteLine("Enter 'a' to attack or 'h' to heal.");

            choice = Console.ReadLine();

            if (choice == "a")
            {
                player.AttackTarget(enemy);
                Console.WriteLine("Player attacks enemy and deals " + player.Attack + " damage!");
            }
            else if (choice == "h")
            {
                player.Heal();
                Console.WriteLine("Player restored " + player.HealAmount + " health points");
            }

            if (enemy.IsAlive())
            {
                Console.WriteLine("-- Enemy turn --");
                Console.WriteLine("Player Hp - " + player.Hp + ". Enemy Hp - " + enemy.Hp + ".");
                int enemyChoice = random.Next(0, 2);

                if (enemyChoice == 0)
                {
                    enemy.AttackTarget(player);
                    Console.WriteLine("Enemy attacks player and deals " + enemy.Attack + " damage!");
                }
                else
                {
                    enemy.Heal();
                    Console.WriteLine("Enemy restored " + enemy.HealAmount + " health points");
                }
            }
        }

        if (player.IsAlive())
        {
            Console.WriteLine("Congratulations, you have won!");
        }
        else
        {
            Console.WriteLine("You lose!");
        }
    }
}
