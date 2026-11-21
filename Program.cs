// See https://aka.ms/new-console-template for more information

Move tackle = new Move("Tackle", 15, 100, 35);
Move spit = new Move("Spit", 100, 30, 5);
Move slap = new Move("Slap", 20, 100, 25);

Minibeast frog = new Minibeast("Frog", 80, 5, 9, new Move[] { tackle, spit });
Minibeast beetle = new Minibeast("Beetle", 80, 5, 10, new Move[] { tackle, slap });

battle(frog, beetle);

void battle(Minibeast a, Minibeast b)
{
    while(a.hp > 0 && b.hp > 0)
    {
        Console.WriteLine($"{a.name}: LV{a.level} HP: {a.hp} vs {b.name}: LV{b.level} HP: {b.hp}");
        Random rnd = new Random();
        int aMoveIndex = rnd.Next(0, a.moves.Length);
        int bMoveIndex = rnd.Next(0, b.moves.Length);

        if(a.speed < b.speed)
        {
            b = a.moves[aMoveIndex].use(b);
            Console.WriteLine($"{a.name} used {a.moves[aMoveIndex].name}!");
            if(b.hp <= 0)
            {
                Console.WriteLine($"{b.name} has fainted!");
                break;
            } else
            {
                a = b.moves[bMoveIndex].use(a);
                Console.WriteLine($"{b.name} used {b.moves[bMoveIndex].name}!");
            }
        } else
        {
            a = b.moves[bMoveIndex].use(a);
            Console.WriteLine($"{b.name} used {b.moves[bMoveIndex].name}!");
            if(a.hp <= 0)
            {
                Console.WriteLine($"{a.name} has fainted!");
                break;
            } else
            {
                b = a.moves[aMoveIndex].use(b);
                Console.WriteLine($"{a.name} used {a.moves[aMoveIndex].name}!");
            }
        }

        if(a.hp <= 0)
        {
            Console.WriteLine($"{a.name} has fainted!");
            break;
        } else if(b.hp <= 0)
        {
            Console.WriteLine($"{b.name} has fainted!");
            break;
        }


    }
    
}

class Move
{
    public String name;
    int power;
    int accuracy;
    public int pp;
    public Minibeast use(Minibeast enemy)
    {
        Random rnd = new Random();
        if(rnd.Next(0, 101) <= accuracy)
        {
            enemy.hp -= power;
        }
        pp -= 1;
        return enemy;
    }

    public Move(String name, int power, int accuracy, int pp)
    {
        this.name = name;
        this.power = power;
        this.accuracy = accuracy;
        this.pp = pp;
    }
}
class Minibeast
{
    public String name;
    public int hp;
    public int level;
    public int speed;
    public Move[] moves = new Move[4];

    public Minibeast(String name, int hp, int level, int speed, Move[] moves)
    {
        this.name = name;
        this.hp = hp;
        this.level = level;
        this.speed = speed;
        this.moves = moves;
    }

}


