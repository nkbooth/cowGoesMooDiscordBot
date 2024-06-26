using System.ComponentModel;
using System.Reflection;

namespace CowGoesMoo;

public static class CowTypesExtensions
{
    public static CowTypes GetRandomCowType()
    {
        const CowTypes cowType = CowTypes.Default;
        return cowType.GetRandomCowType();
    }
    public static CowTypes GetRandomCowType(this CowTypes cowType)
    {
        var rnd = new Random();
        return (CowTypes)rnd.Next(Enum.GetNames(typeof(CowTypes)).Length);
    }
    public static string? GetEnumDescription(this object enumObject)
    {
        if (enumObject is Enum)
        {
            var fieldInfo = enumObject.GetType().GetField(enumObject.ToString() ?? string.Empty);
            var attributes = (DescriptionAttribute[])fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false)!;
            return attributes.FirstOrDefault()?.Description;
        }
        else
        {
            return string.Empty;
        }
    }
}

public enum CowTypes
{
    
    [Description("C3PO")]
    C3PO,
    [Description("R2-D2")]
    R2D2,
    [Description("USA")]
    USA,
    [Description("ackbar")]
    Ackbar,
    [Description("aperture-blank")]
    ApertureBlank,
    [Description("aperture")]
    Aperture,
    [Description("armadillo")]
    Armadillo,
    [Description("atat")]
    ATAT,
    [Description("atom")]
    Atom,
    [Description("awesome-face")]
    AwesomeFace,
    [Description("banana")]
    Banana,
    [Description("bearface")]
    BearFace,
    [Description("beavis.zen")]
    BeavisZen,
    [Description("bees")]
    Bees,
    [Description("bill-the-cat")]
    BillTheCat,
    [Description("biohazard")]
    Biohazard,
    [Description("bishop")]
    Bishop,
    [Description("black-mesa")]
    BlackMesa,
    [Description("bong")]
    Bong,
    [Description("box")]
    Box,
    [Description("broken-heart")]
    BrokenHeart,
    [Description("bud-frogs")]
    BudFrogs,
    [Description("bunny")]
    Bunny,
    [Description("cake-with-candles")]
    CakeWithCandles,
    [Description("cake")]
    Cake,
    [Description("cat")]
    Cat,
    [Description("cat2")]
    Cat2,
    [Description("catfence")]
    CatFence,
    [Description("charizardvice")]
    CharizardVice,
    [Description("charlie")]
    Charlie,
    [Description("cheese")]
    Cheese,
    [Description("chessmen")]
    Chessmen,
    [Description("chito")]
    Chito,
    [Description("claw-arm")]
    ClawArm,
    [Description("clippy")]
    Clippy,
    [Description("companion-cube")]
    CompanionCube,
    [Description("cower")]
    Cower,
    [Description("cowfee")]
    Cowfee,
    [Description("cthulhu-mini")]
    CthulhuMini,
    [Description("cube")]
    Cube,
    [Description("daemon")]
    Daemon,
    [Description("dalek-shooting")]
    DalekShooting,
    [Description("dalek")]
    Dalek,
    [Description("default")]
    Default,
    [Description("docker-whale")]
    DockerWhale,
    [Description("doge")]
    Doge,
    [Description("dolphin")]
    Dolphin,
    [Description("dragon-and-cow")]
    DragonAndCow,
    [Description("dragon")]
    Dragon,
    [Description("ebi_furai")]
    EbiFurai,
    [Description("elephant-in-snake")]
    ElephantInSnake,
    [Description("elephant")]
    Elephant,
    [Description("elephant2")]
    Elephant2,
    [Description("explosion")]
    Explosion,
    [Description("eyes")]
    Eyes,
    [Description("fat-banana")]
    FatBanana,
    [Description("fat-cow")]
    FatCow,
    [Description("fence")]
    Fence,
    [Description("fire")]
    Fire,
    [Description("flaming-sheep")]
    FlamingSheep,
    [Description("fox")]
    Fox,
    [Description("ghost")]
    Ghost,
    [Description("ghostbusters")]
    Ghostbusters,
    [Description("glados")]
    Glados,
    [Description("goat")]
    Goat,
    [Description("goat2")]
    Goat2,
    [Description("golden-eagle")]
    GoldenEagle,
    [Description("hand")]
    Hand,
    [Description("happy-whale")]
    HappyWhale,
    [Description("hedgehog")]
    Hedgehog,
    [Description("hellokitty")]
    HelloKitty,
    [Description("hippie")]
    Hippie,
    [Description("hiya")]
    Hiya,
    [Description("hiyoko")]
    Hiyoko,
    [Description("homer")]
    Homer,
    [Description("hypno")]
    Hypno,
    [Description("ibm")]
    Ibm,
    [Description("iwashi")]
    Iwashi,
    [Description("jellyfish")]
    Jellyfish,
    [Description("karl_marx")]
    KarlMarx,
    [Description("kilroy")]
    Kilroy,
    [Description("king")]
    King,
    [Description("kiss")]
    Kiss,
    [Description("kitten")]
    Kitten,
    [Description("kitty")]
    Kitty,
    [Description("knight")]
    Knight,
    [Description("koala")]
    Koala,
    [Description("kosh")]
    Kosh,
    [Description("lamb")]
    Lamb,
    [Description("lamb2")]
    Lamb2,
    [Description("lightbulb")]
    Lightbulb,
    [Description("lobster")]
    Lobster,
    [Description("lollerskates")]
    Lollerskates,
    [Description("luke-koala")]
    LukeKoala,
    [Description("mailchimp")]
    Mailchimp,
    [Description("maze-runner")]
    MazeRunner,
    [Description("mech-and-cow")]
    MechAndCow,
    [Description("meow")]
    Meow,
    [Description("milk")]
    Milk,
    [Description("minotaur")]
    Minotaur,
    [Description("mona-lisa")]
    MonaLisa,
    [Description("moofasa")]
    Moofasa,
    [Description("mooghidjirah")]
    Mooghidjirah,
    [Description("moojira")]
    Moojira,
    [Description("moose")]
    Moose,
    [Description("mule")]
    Mule,
    [Description("mutilated")]
    Mutilated,
    [Description("nyan")]
    Nyan,
    [Description("octopus")]
    Octopus,
    [Description("okazu")]
    Okazu,
    [Description("owl")]
    Owl,
    [Description("pawn")]
    Pawn,
    [Description("periodic-table")]
    PeriodicTable,
    [Description("personality-sphere")]
    PersonalitySphere,
    [Description("pinball-machine")]
    PinballMachine,
    [Description("psychiatrichelp")]
    PsychiatricHelp,
    [Description("psychiatrichelp2")]
    PsychiatricHelp2,
    [Description("pterodactyl")]
    Pterodactyl,
    [Description("queen")]
    Queen,
    [Description("radio")]
    Radio,
    [Description("ren")]
    Ren,
    [Description("renge")]
    Renge,
    [Description("robot")]
    Robot,
    [Description("robotfindskitten")]
    Robotfindskitten,
    [Description("roflcopter")]
    Roflcopter,
    [Description("rook")]
    Rook,
    [Description("sachiko")]
    Sachiko,
    [Description("satanic")]
    Satanic,
    [Description("seahorse-big")]
    SeahorseBig,
    [Description("seahorse")]
    Seahorse,
    [Description("sheep")]
    Sheep,
    [Description("shikato")]
    Shikato,
    [Description("shrug")]
    Shrug,
    [Description("skeleton")]
    Skeleton,
    [Description("small")]
    Small,
    [Description("smiling-octopus")]
    SmilingOctopus,
    [Description("snoopy")]
    Snoopy,
    [Description("snoopyhouse")]
    SnoopyHouse,
    [Description("snoopysleep")]
    Snoopysleep,
    [Description("spidercow")]
    Spidercow,
    [Description("squid")]
    Squid,
    [Description("squirrel")]
    Squirrel,
    [Description("stegosaurus")]
    Stegosaurus,
    [Description("stimpy")]
    Stimpy,
    [Description("sudowoodo")]
    Sudowoodo,
    [Description("supermilker")]
    Supermilker,
    [Description("surgery")]
    Surgery,
    [Description("tableflip")]
    Tableflip,
    [Description("taxi")]
    Taxi,
    [Description("telebears")]
    Telebears,
    [Description("template")]
    Template,
    [Description("threader")]
    Threader,
    [Description("threecubes")]
    Threecubes,
    [Description("toaster")]
    Toaster,
    [Description("tortoise")]
    Tortoise,
    [Description("turkey")]
    Turkey,
    [Description("turtle")]
    Turtle,
    [Description("tux-big")]
    TuxBig,
    [Description("tux")]
    Tux,
    [Description("tweety-bird")]
    TweetyBird,
    [Description("vader-koala")]
    VaderKoala,
    [Description("vader")]
    Vader,
    [Description("weeping-angel")]
    WeepingAngel,
    [Description("whale")]
    Whale,
    [Description("wizard")]
    Wizard,
    [Description("wood")]
    Wood,
    [Description("world")]
    World,
    [Description("www")]
    Www,
    [Description("yasuna_01")]
    Yasuna01,
    [Description("yasuna_02")]
    Yasuna02,
    [Description("yasuna_03")]
    Yasuna03,
    [Description("yasuna_03a")]
    Yasuna03a,
    [Description("yasuna_04")]
    Yasuna04,
    [Description("yasuna_05")]
    Yasuna05,
    [Description("yasuna_06")]
    Yasuna06,
    [Description("yasuna_07")]
    Yasuna07,
    [Description("yasuna_08")]
    Yasuna08,
    [Description("yasuna_09")]
    Yasuna09,
    [Description("yasuna_10")]
    Yasuna10,
    [Description("yasuna_11")]
    Yasuna11,
    [Description("yasuna_12")]
    Yasuna12,
    [Description("yasuna_13")]
    Yasuna13,
    [Description("yasuna_14")]
    Yasuna14,
    [Description("yasuna_16")]
    Yasuna16,
    [Description("yasuna_17")]
    Yasuna17,
    [Description("yasuna_18")]
    Yasuna18,
    [Description("yasuna_19")]
    Yasuna19,
    [Description("yasuna_20")]
    Yasuna20,
    [Description("ymd_udon")]
    YmdUdon,
    [Description("zen-noh-milk")]
    ZenNohMilk
}
