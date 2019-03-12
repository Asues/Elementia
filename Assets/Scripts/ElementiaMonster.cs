///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>

public class ElementiaMonsterNames{
    //Fire monsters
    public const string FireDemon = "FireDemon";
    public const string Dragon = "Dragon";

    //Water monsters
    public const string Whale = "Whale";
    public const string Elf = "Elf";

    //Aire monsters
    public const string Wizard = "Wizard";
    public const string Bee = "Bee";

    //Earth monsters
    public const string Skeleton = "Skeleton";
    public const string Mouse = "Mouse";
  
    // Demo, for test or game beginn, have 0 hp and 0 attack
    public const string Demo = "Demo";
}

public class ElementiaMonsterTypes
{
    public const string Fire = "Fire";
    public const string Earth = "Earth";
    public const string Water = "Water";
    public const string Air = "Air";
}

public class ElementiaMonster
{
    public string Name ;
    public int HP;
    public float Attact;
    public float Defense;
    public int Evasiveness;
    public string Type;

    public ElementiaMonster(string name, int hp, float attact, float defense, int evasiveness, string type)
    {
        Name = name;
        HP = hp;
        Attact = attact;
        Defense = defense;
        Evasiveness = evasiveness;
        Type = type;
    }
}

class ElementiaDemoMonster : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Demo;
    static int hp = 0;
    static float attact = 0;
    static int evasiveness = 0;
    static float defense = 0;
    static string type = ElementiaMonsterTypes.Fire;
    public ElementiaDemoMonster() : base(name, hp, attact, defense, evasiveness, type) { }
}

// Fire Monster 1
class ElementiaFireDemon : ElementiaMonster
{
    static string name = ElementiaMonsterNames.FireDemon;
    static int hp = 30;
    static float attact = 40;
    static int evasiveness = 30;
    static float defense = 10;
    static string type = ElementiaMonsterTypes.Fire;
    public ElementiaFireDemon() : base(name, hp, attact, defense, evasiveness, type) { }
}

// Fire Monster 2
public class ElementiaDragon : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Dragon;
    static int hp = 20;
    static float attact = 65;
    static int evasiveness = 20;
    static float defense = 15;
    static string type = ElementiaMonsterTypes.Fire;
    public ElementiaDragon() : base(name, hp, attact, defense, evasiveness, type) { }
}

// Water Monster 1
class ElementiaWhale : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Whale;
    static int hp = 30;
    static float attact = 50;
    static int evasiveness = 5;
    static float defense = 35;
    static string type = ElementiaMonsterTypes.Water;
    public ElementiaWhale() : base(name, hp, attact, defense, evasiveness, type) { }
}

// Water Monster 2
class ElementiaElf : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Elf;
    static int hp = 30;
    static float attact = 60;
    static int evasiveness = 5;
    static float defense = 15;
    static string type = ElementiaMonsterTypes.Earth;
    public ElementiaElf() : base(name, hp, attact, defense, evasiveness, type) { }
}

// Air Monster 1
public class ElementiaWizzard : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Wizard;
    static int hp = 20;
    static float attact = 60;
    static int evasiveness = 10;
    static float defense = 20;
    static string type = ElementiaMonsterTypes.Air;
    public ElementiaWizzard() : base(name, hp, attact, defense, evasiveness, type) { }
}
// Air Monster 2
public class ElementiaBee : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Bee;
    static int hp = 20;
    static float attact = 55;
    static int evasiveness = 10;
    static float defense = 20;
    static string type = ElementiaMonsterTypes.Air;
    public ElementiaBee() : base(name, hp, attact, defense, evasiveness, type) { }
}
// Earth Monster 1
public class ElementiaSkeleton : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Skeleton;
    static int hp = 45;
    static float attact = 50;
    static int evasiveness = 10;
    static float defense = 20;
    static string type = ElementiaMonsterTypes.Earth;
    public ElementiaSkeleton() : base(name, hp, attact, defense, evasiveness, type) { }
}

//Earth Monster 2
public class ElementiaMouse : ElementiaMonster
{
    static string name = ElementiaMonsterNames.Mouse;
    static int hp = 40;
    static float attact = 55;
    static int evasiveness = 10;
    static float defense = 25;
    static string type = ElementiaMonsterTypes.Earth;
    public ElementiaMouse() : base(name, hp, attact, defense, evasiveness, type) { }
}

















