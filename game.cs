using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


/* classes with a bunch of different objects and varibles to interact with to
 * the test cases provided*/
namespace Role_Playing_Game
{

    #region Objects and Entities

    public class Player
    {
        #region Variables

        public int level, experience, expToLevelUp;

        public int health, maxHealth, numberOfHealthPotions;

        public int baseDamage;

        public int baseDefense;

        public Weapon currentWeapon;

        public Armor currentArmor;

        #endregion

        public Player() //default constructor 
        {
            level = 0;
            experience = 0;
            expToLevelUp = 0;
            health = 0;
            maxHealth = 0;
            numberOfHealthPotions = 0;
            baseDamage = 0;
            baseDefense = 0;
            currentWeapon = new Weapon();
            currentArmor = new Armor();
        }
        
        public Player(int level, int experience, int expToLevelUp, int health, int maxHealth, 
            int numberOfHealthPotions, int baseDamage, int baseDefense, Weapon currentWeapon, Armor currentArmor) //constructor for testing 
        {
            this.level = level;
            this.experience = experience;
            this.expToLevelUp = expToLevelUp;
            this.health = health;
            this.maxHealth = maxHealth;
            this.numberOfHealthPotions = numberOfHealthPotions;
            this.baseDamage = baseDamage;
            this.baseDefense = baseDefense;
            this.currentWeapon = currentWeapon;
            this.currentArmor = currentArmor;
        }
        public void ChangeHealth(int change) //method to change health... dont know if needed for testing tbh
        {
            maxHealth = maxHealth - health; 
        }

        public void ComapareWeaponToCurrent(Weapon newWeapon) //compare old to new weapon
        {
            currentWeapon = newWeapon; 
        }

        public void CompareArmorToCurrent(Armor newArmor) //compare old to new armor
        {
            currentArmor = newArmor; 
        }

        public void GainEXP(int exp) //gain experience method
        {
            experience = expToLevelUp - experience; 
        }

        public void LevelUp(int levelUP) //leveling up based on experience max gain
        {
            
            if(levelUP == expToLevelUp)
            {
                level++;
            }
            else
            {
                Console.WriteLine("Go grind more.");
            }
        }
    }

    public class Enemy
    {
        #region Variables

        public string name;

        public int level;

        public int experienceOnDefeat;

        public int health;

        public enum Effect
        {
            enemyEffect = 0, 
        }

        public Effect effect;

        public int damage;

        public int defense;

        #endregion

        public Enemy() //enemy default constructor 
        {
            name = "";
            level = 0;
            effect = 0;
            experienceOnDefeat = 0;
            health = 0;
            damage = 0;
        }

        public Enemy(string name, int level, Effect effect, 
            int experienceOnDefeat, int health, int damage) //enemy main constructor for testing
        {
            this.name = name;
            this.level = level;
            this.effect = effect;
            this.experienceOnDefeat = experienceOnDefeat;
            this.health = health;
            this.damage = damage; 
        }
        public void ChangeHealth(int change) //similar to player
        {

            health = damage - defense; 
        }

        public int Attack() //different attack damage
        {
            int attack; 
            if(damage == 2)
            {
                attack = 2;
                return attack; 
            }
            else if(damage == 3)
            {
                attack = 3;
                return attack;
            }
            else if (damage == 4)
            {
                attack = 4;
                return attack;
            }
            else
            {
                attack = 0;
                return attack; 
            }         
        }
        public void UniqueBehaviour(Player player, Enemy enemy) //enemy dies if reaches 0
        {
            if(enemy.health == 0 || player.baseDamage >= enemy.health)
            {
                Console.WriteLine("You have defeated the enemy.");
            }
            else
            {
                Console.WriteLine("Keep fighting");
            }
        }

    }

    public class Location
    {
        #region Variables

        public string name, description;

        public int levelOfInhabitants, InhabitantsLevelRange;
        // false for things like dungeons

        public int numberOfEnemiesLeft;

        public enum Effect //location effect
        {
            locationEffect = 0,
        }

        public Effect effect;

        #endregion

        public Location() //default constructor 
        {
            name = "";
            description = "";
            levelOfInhabitants = 0;
            InhabitantsLevelRange = 0;
            numberOfEnemiesLeft = 0;
        }

        public Location(string name, string description, int levelOfInhabitants, int InhabitantsLevelRange, int numberOfEnemiesLeft, Effect effect) //location constructor 
        {
            this.name = name;
            this.description = description;
            this.levelOfInhabitants = levelOfInhabitants;
            this.InhabitantsLevelRange = InhabitantsLevelRange;
            this.numberOfEnemiesLeft = numberOfEnemiesLeft;
            this.effect = effect; 
        }

        public void EnvironmentalEffect(Player player, Enemy enemy) //different effects apply depending on player experience and level
        {
            if (player.experience == 100)
            {
                if (player.health == 500)
                {
                    Console.WriteLine("Your health randomly goes up one because of this location.");
                    player.health++;
                }
                else if (player.health >= 500)
                {
                    Console.WriteLine("You can equip extra armor");
                }
                else if (player.currentWeapon.damage <= 200)
                {
                    Console.WriteLine("Your weapon can not break.");
                }
                else
                {
                    Console.WriteLine("You can not level up anymore until you reach a certain threshhold in the game.");
                }
                int newLocationEffect = (int)Effect.locationEffect;
                Console.WriteLine(newLocationEffect);
                Console.WriteLine("Location effect is applied.");
            }
        }

        public override string ToString()
        {
            return description;
        }

    }

    public class Weapon
    {
        #region Variables

        public string name;
        public int damage, damageRange;
        public enum Effect

        {
           criticalEffect =1, 
        }

        public Effect effect;

        public string toString;

        #endregion

        public Weapon() // default constructor
        {
            name = "";
            damage = 1;
            damageRange = 4;
            toString = "";
        }
        public Weapon(string name, int damage, int damageRange, Effect effect, string toString) //constructor
        {
            this.name = name;
            this.damage = damage;
            this.damageRange = damageRange;
            this.toString = toString;
            this.effect = effect;
        }

        public int Damage()
        {
            return damage;
        }

        public void UniqueBehaviour(Player player, Enemy enemy)
        {
            if (player.currentWeapon.damage == 200) //on hit on the enemy
            {
                if (player.experience >= enemy.experienceOnDefeat)
                {
                    int newEffect = (int)Effect.criticalEffect;
                    Console.WriteLine(newEffect);
                    Console.WriteLine("Your weapon can crit. You landed a critical.");
                }
                else
                {
                    Console.WriteLine("Crit chance only 20%, but critical effect is applied.");
                }
                
            }
            else
            {
                Console.WriteLine("No Critical. Weapon no effect.");
            }
        }

        public override string ToString()
        {
            return "Put some stuffs here." + toString;
        }
    }

    public class Armor
    {
        #region Variables

        public string name;

        public int defense, defenseRange;

        public enum Effect
        {
            poisonEffect = 2, 
            bloodEffect = 3,
            increaseEffect = 4,
        }

        public Effect effect;

        public string toString;

        #endregion

        public Armor()  //default constructor 
        {
            name = "";
            defense = 0;
            defenseRange = 0;
            toString = "";
        }
        public Armor(string name, int defense, int defenseRange, Effect effect, string toString) //armor constructor 
        {
            this.name = name;
            this.defense = defense;
            this.effect = effect;
            this.toString = toString; 
        }

        public void UniqueBehaviour(Player player, Enemy enemy) //armor stats change depending on level 
        {
            if (player.level == 80)
            {
                int newEffect = (int)Effect.poisonEffect;
                Console.WriteLine(newEffect);
                Console.WriteLine("Your armor now has poison stats.");
            }
            else if (player.level == 60)
            {
                int newEffect2 = (int)Effect.bloodEffect;
                Console.WriteLine(newEffect2);
                Console.WriteLine("Your armor has an added blood effect.");
            }
            else if (player.level == 40)
            {
                int newEffect3 = (int)Effect.increaseEffect;
                Console.WriteLine(newEffect3);
                Console.WriteLine("Your armor has increased defense.");
            }
            else
                Console.WriteLine("No effect.");

        }

        public override string ToString()
        {
            return "Put funny stuff here~" + toString;
        }

    }

    #endregion

    public class TheGame
    {
        public enum GameState
        {
            IN_BATTLE,
            AT_LOCATION,
            SELECTING_LOCATION,
            DEFEAT,
            DEFAULT
        }
        public GameState gameState;
        public List<Location> locations;
        public Player player;
        public Enemy currentEnemy;


        // I felt as though it was neccesary to give a starting point just in case
        // whoever recieves my project has no experience in game design.
        //
        // To my recipient, if you find that you have a better way to do something,
        // or that I forgot something, please don't hesitate to change it (so long as
        // it's in a way that you don't lose points).
        //
        // Good Luck!

        public TheGame() 
        {
            gameState = new GameState();
            locations = new List<Location>();
            player = new Player();    
        }

        public TheGame(GameState gameState, List<Location> locations, Player player)
        {
            this.gameState = gameState;
            this.locations = locations;
            this.player = player; 
        }

        //Main was commentted out to test

        /*public static void Main(string[] args)
        {
            
        }*/

        #region File Stuff

        public static TheGame LoadGame(string filePath)
        {
            
            filePath = @"loadGame.txt";
            string readData = File.ReadAllText(filePath);
            FileInfo loadFile = new FileInfo(filePath);
            bool filesExists = loadFile.Exists;
            return null;
            
            
        }
        public static void SaveGame(TheGame theGame, string filePath) 
        {
            filePath = @"saveTheGame.txt";
            string readData = File.ReadAllText(filePath);
            string destinationFilePath = @"overrWritedFile.txt";
            bool overWrite = true;
            File.Copy(filePath, destinationFilePath, overWrite);
            FileInfo deleteOldSaveFile = new FileInfo(filePath);
            deleteOldSaveFile.Delete();
        } 

        public static string GetDescription(string filePath)
        {
            filePath = "lotsofImportantStuff.txt";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            directory.Create();
            string[] file = Directory.GetFiles(filePath);
            string readData = File.ReadAllText(filePath);
            return null;
        }

        public void checkFileException(string filePath)
        {
            try
            {
                Console.WriteLine("What file do you want to read from?");
                string fileInput = Console.ReadLine(); 
                if(File.Exists(fileInput) == File.Exists(filePath))
                {
                    Console.WriteLine("the file exists");
                }
            }
            catch (FileNotFoundException e) when (e.FileName == "someFile")
            {
                if (e.Source != null)
                {
                    Console.WriteLine("Show Exception:" + e.Source);
                    throw;
                }
                else
                {
                    Console.WriteLine("Try another file name.");
                }
            }
            
            
        }

        #endregion

        #region Main Methods

        public void inBattle() 
        {
            player.numberOfHealthPotions.Equals(1);
            if (player.numberOfHealthPotions >= 1)
            {
                Console.WriteLine("Use potion option is available.");

            }
            else
                Console.WriteLine("You cannot use a potion in battle.");
            
        }

        public void atLocation(Player player, Enemy enemy) 
        {
            Console.WriteLine("Enemies have arrived.");
            if(player.level != enemy.level)
            {
                Console.WriteLine("Enemy can attack if from behind.");
            }
            
        }

        public void selectingLocation() 
        {
            Location locationMoutain = new Location();
            if (player.level == 20)
            {
                Console.WriteLine("You can enter this area.");
            }
            else if (player.level <= 20)
            {
                Console.WriteLine("You must be level 20 to enter here.");

            }
            else
                Console.WriteLine("Try another location.");
            }

        }

        #endregion
        /* masha comments for feeback reasons: 
         * discuss effect stuff
         * adjustments to tests to meet reqs for the effect clause 
         * had to fix all the tests to be testable with required information
         * 
         */
    }
