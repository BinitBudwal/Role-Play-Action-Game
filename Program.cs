//Populate weapons list with name of weapon and its damage
Weapon Fist = new Weapon("Fist", 10);
Weapon Knuckles = new Weapon("Knuckles", 25);
Weapon Blade= new Weapon("Blade", 50);
Weapon Knife= new Weapon("Knife", 70);
Weapon Bat = new Weapon("Bat", 50);
Weapon Axe = new Weapon("Axe", 85);
Weapon Pistol = new Weapon("Pistol", 150);
Weapon AK47 = new Weapon("AK47", 200);
Weapon RPG= new Weapon("RPG", 250);
Weapon NUCLEAR_BOMB = new Weapon("NUCLEAR BOMB", 499);

//Populate Armour list with the name of Armour and its strenght
Armour Level1 = new Armour("Police Vest", 10);
Armour Level2 = new Armour("Riot Vest", 20);
Armour Level3 = new Armour("Military Vest", 30);
Armour Level4 = new Armour("Zombie Shield", 50);
Armour Level5 = new Armour("SuperMan Cape", 100);


//Populate list of monsters with their name and strenght
Monster Magneto  = new Monster("Magneto", 500);
Monster GreenGoblin = new Monster("GreenGoblin", 500);
Monster RedSkull = new Monster("RedSkull", 500);
Monster Loki = new Monster("Loki", 500);
Monster Ultron= new Monster("Ultron", 500);
Monster Thanos = new Monster("Thanos", 500);
Monster Venom = new Monster("Venom", 500);
Monster Apocalypse = new Monster("Apocalypse", 500);
Monster Mystique = new Monster("Mystique", 500);
Monster MrSinister = new Monster("MrSinister", 500);


//Initiate new game 
Game BattleOfMITT = new Game();
BattleOfMITT.Start();



//Hero class contains all required information about Hero.
class Hero
{
    public Game Game { get; set; }
    public string Name { get; set; }
    public int BaseStrength { get; set; } = 100;
    public int BaseDefence { get; set; } = 50;
    public int OriginalHealth { get; set; } = 1000;//setting health value
    public int CurrentHealth { get; set; } = 1000; //setting initial health value
    public Weapon EquippedWeapon { get; set; }
    public Armour EquippedArmour { get; set; }
    
    //Selecting the first availabe weapon from the weapon lIst to being with at defaults(index[0])
    public Hero(Hero hero)
    {
        EquippedWeapon = WeaponList.Weapons[0];
        EquippedArmour = ArmourList.Armours[0];
        
    }
}
//Monster class contains all required information about Monster.
class Monster
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Defence { get; set; }
    public int OriginalHealth { get; set; } = 1000;//setting health value
    public int CurrentHealth { get; set; } = 1000;//setting initial health value
    public bool Defeated { get; set; } = false;

    //Selecting the first availabe Monster from the Monster lIst(Name and its strenght)
    public Monster(string name, int strength)
    {
        Name = name;
        Strength = strength;

        MonsterList.ListMonster(this);
    }
}

//Contains all information regarding Weapons
class Weapon
{
    public string Name { get; set; }
    public int Power { get; set; }

    //Selecting the first availabe Weapon from the Weapon lIst(Name and its strenght)
    public Weapon(string name, int power)
    {
        Name = name;
        Power = power;

        WeaponList.ListWeapon(this);
    }
}

//Contains all information regarding Armour
class Armour
{
    public string Name { get; set; }
    public int Power { get; set; }

    //Selecting the first availabe Weapon from the Weapon lIst(Name and its strenght)
    public Armour(string name, int power)
    {
        Name = name;
        Power = power;

        ArmourList.ListArmour(this);
    }
}
static class WeaponList
{
    public static List<Weapon> Weapons { get; set; } = new List<Weapon>();
    //Populating the newly created instance of Weapon list
    public static List<Weapon> ListWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
        return Weapons;
    }
}
static class ArmourList
{
    public static List<Armour> Armours { get; set; } = new List<Armour>();
    //Populating the newly created instance of Armour list
    public static List<Armour> ListArmour(Armour Armour)
    {
        Armours.Add(Armour);
        return Armours;
    }
}
static class MonsterList
{
    public static int DefeatedCounter { get; set; } = 0;//initail counter at 0
    public static List<Monster> Monsters { get; set; } = new List<Monster>();
    //Populating the newly created instance of Monster list
    public static List<Monster> ListMonster(Monster monster)
    {
        Monsters.Add(monster);
        return Monsters;
    }
}

class Inventory
{
    public Hero Hero { get; set; }
    public void ChangeEquippedWeapon()//To change selected Weapon for fight
    {
        int number = 0;

        Console.WriteLine($"Your current weapon of choice is : {Hero.EquippedWeapon.Name}");
        Console.WriteLine($"Select your new weapon:");
        foreach (Weapon weapon in WeaponList.Weapons)
        {
            Console.WriteLine($"PRESS {number} - Name: {weapon.Name} | Power: {weapon.Power}");
            number++;
        }
        char charKey = Console.ReadKey(true).KeyChar;
        for (int i = 0; i < WeaponList.Weapons.Count; i++)
        {
            if (charKey == char.Parse(i.ToString()))
            {
                Hero.EquippedWeapon = WeaponList.Weapons[i];
                break;
            }
        }
        Console.WriteLine($"Your NEW current weapon of choice is: {Hero.EquippedWeapon.Name}");
        Console.WriteLine("Return back to Main Menu : (PRESS M)");
        Console.WriteLine("To Change Vest : (PRESS V)");
        if (Console.ReadKey(true).KeyChar == 'm')
        {
            Hero.Game.MainMenu.Menu();
        }

    }
    public void ChangeEquippedArmour()//To change selected Armour for fight
    {

        int number = 0;
        Console.WriteLine($"Your current Armour of choice is: {Hero.EquippedArmour.Name}");
        Console.WriteLine($"Select your new Armour:");
        foreach (Armour Armour in ArmourList.Armours)
        {
            Console.WriteLine($"PRESS {number} - Name: {Armour.Name} | Power: {Armour.Power}");
            number++;
        }
        char charKey = Console.ReadKey(true).KeyChar;
        for (int i = 0; i < ArmourList.Armours.Count; i++)
        {
            if (charKey == char.Parse(i.ToString()))
            {
                Hero.EquippedArmour = ArmourList.Armours[i];
                break;
            }
        }
        Console.WriteLine($"Your NEW current Armour of choice is: {Hero.EquippedArmour.Name}");
        Console.WriteLine("Return back to Main Menu : (PRESS M)");
        Console.WriteLine("To Change Weapon : (PRESS W)");
        if (Console.ReadKey(true).KeyChar == 'm')
        {
            Hero.Game.MainMenu.Menu();
        }
    }
    public Inventory(Hero hero)
    {
        Hero = hero;
    }
}

class MainMenu
{

    public Inventory Inventory { get; set; }
    public Fight Fight { get; set; }
    public void Menu()//Creating Menu
    {
        Console.WriteLine("------Menu------");

        Console.WriteLine("PRESS I TO CHANGE Weapon/Armour");
        Console.WriteLine("\nPRESS F TO START THE FIGHT !");
        switch (Console.ReadKey(true).KeyChar)
        {

            case 'i':
                Console.WriteLine("------Inventory------");
                Inventory.ChangeEquippedWeapon();
                Inventory.ChangeEquippedArmour();
                Menu();
                break;
            case 'f':
                Console.WriteLine("------Fight------");
                Fight.StartFight();
                break;
            default:
                Console.WriteLine("Error : Invalid entry, Try again");
                Menu();
                break;
        }
    }

    public MainMenu(Inventory inventory, Fight fight)
    {
        Inventory = inventory;
        Fight = fight;
    }
}
class Fight
{
    public Game Game { get; set; }
    public Hero Hero { get; set; }
    
    public int MonsterIndex { get; set; }
    //Declearing Initial State of game
    public bool HeroWon { get; set; } = false;
    public bool HeroDied { get; set; } = false;
    public Monster CurrentMonster { get; set; }

    public void ChangeMonster(Monster currentMonster) 
    {
        //looping through the list of monsters to get next one. 
        foreach (Monster monster in MonsterList.Monsters)
        {
            if (monster.Defeated)
            {
                MonsterList.DefeatedCounter++;
            }
            //Check and move to next momster in the monsterList(if counter is greater than 0)
            if (monster != currentMonster && !monster.Defeated && MonsterList.DefeatedCounter > 0)
            {
                CurrentMonster = monster;
                Console.WriteLine($"Next Monster :  {monster.Name}");
                break;
            }
            else
            {
                CurrentMonster = currentMonster;
            }
        }
    }
    //Initiate fight 
    public void StartFight()
    {
        if (HeroDied) 
        {
            
            Hero.CurrentHealth = Hero.OriginalHealth;
            //declearing values for the start
            HeroDied = false;
            HeroWon = false;
            foreach (Monster defeatedMonster in MonsterList.Monsters)
            {
                defeatedMonster.Defeated = false;
                defeatedMonster.CurrentHealth = defeatedMonster.OriginalHealth;
            }
        }
        ChangeMonster(CurrentMonster);
        Console.WriteLine($"Your opponent is: {CurrentMonster.Name}");
        this.HeroTurn(CurrentMonster);

    }
    public void HeroTurn(Monster monsterOpponent) 
    { 
        this.Lose(CurrentMonster);
        if (!HeroWon && !HeroDied)
        {
            Console.WriteLine($"It's {Hero.Name}'s turn To attack");
            Console.WriteLine($"Your Current Gear is \nWeapon = {Hero.EquippedWeapon.Name} \nArmour = {Hero.EquippedArmour.Name} ");
            
            //calculating the damage done 
            int damage = Hero.BaseStrength + Hero.EquippedWeapon.Power;
            monsterOpponent.CurrentHealth -= damage;
            Console.WriteLine($"{monsterOpponent.Name} Took {damage} Damage from your {Hero.EquippedWeapon.Name}'s attack");
            if (monsterOpponent.CurrentHealth < 0)
            {
                monsterOpponent.CurrentHealth = 0;
            }
            Console.WriteLine($"{monsterOpponent.Name} remaining health is {monsterOpponent.CurrentHealth}");
            this.MonsterTurn(CurrentMonster);
        }
        else
        {
            return;
        }
    }
    public void MonsterTurn(Monster monster) 
    {
        this.Win(CurrentMonster);
        this.Lose(CurrentMonster);
        if (!HeroWon && !HeroDied)
        {
            Console.WriteLine($"It's {monster.Name}'s turn");
            //calculating damage done
            int damage = monster.Strength - Hero.BaseDefence;
            Hero.CurrentHealth -= damage;

            Console.WriteLine($"{monster.Name} caused {Hero.Name} {damage}");
            if (Hero.CurrentHealth < 0)
            {
                Hero.CurrentHealth = 0;
            }
            Console.WriteLine($"{Hero.Name} current health is {Hero.CurrentHealth}");
            this.HeroTurn(CurrentMonster);
        }
        else
        {
            return;
        }
    }

    //stating condition for win 
    public bool Win(Monster monster) 
    {
        if (monster.CurrentHealth <= 0)
        {
            monster.Defeated = true;
            Console.WriteLine($"{Hero.Name} Won the BattleOfMITT\n------x------");
            
            ChangeMonster(monster);
            HeroTurn(CurrentMonster);
            
            if (MonsterList.DefeatedCounter == MonsterList.Monsters.Count)
            {
                Game.MainMenu.Menu();
                HeroWon = true;
            }
            else
            {
                HeroWon = false;
            }
        }
        return false;
    }

    //Stating condition for lose
    public bool Lose(Monster monster)
    {
        if (Hero.CurrentHealth <= 0)
        {
            Console.WriteLine($"{Hero.Name} was killed by {monster.Name}");
            
            HeroDied = true;
            Game.MainMenu.Menu();
        }
        return false;
    }
    public Fight(Hero hero, Game game)
    {
        Hero = hero;
        Game = game;
        //selecting monster at random with a random function for monsterList index
        Random randomNum = new Random(); 
        MonsterIndex = randomNum.Next(MonsterList.Monsters.Count);
        CurrentMonster = MonsterList.Monsters[MonsterIndex];
    }
}

//Initiate game  
class Game
{
    public Inventory Inventory { get; set; }
    public Fight Fight { get; set; }
    public Hero Hero { get; set; }
    public MainMenu MainMenu { get; set; }
    public void Start()//asking for name and prompting menu 
    {
        
        Console.WriteLine("Enter your Character's Name:");
        string name = Console.ReadLine();
        Hero.Name = name;
        
        MainMenu.Menu();
    }
    public Game()//new instance of hero, fight , inventory and mainMenu
    {
        Hero = new Hero(Hero);
        Hero.Game = this;
        Fight = new Fight(Hero, this);
        Inventory = new Inventory(Hero);
        MainMenu = new MainMenu(Inventory, Fight);
    }
}