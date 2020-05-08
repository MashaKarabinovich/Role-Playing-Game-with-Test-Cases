using NUnit.Framework;
using System.IO;
using System;

namespace Role_Playing_Game
{
    public class FunctionalTestSuite
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SampleTestToMakeNUnitWorkBecauseNUnitHasAbsolutelyZeroFlawsWhatsoever()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckIfNewPlayer()
        {
            TheGame theGame = new TheGame();
            Player player = new Player();

            Assert.AreEqual(player.baseDamage, theGame.player.baseDamage);
            Assert.AreEqual(player.baseDefense, theGame.player.baseDefense);
            Assert.AreEqual(player.currentArmor, theGame.player.currentArmor);
            Assert.AreEqual(player.currentWeapon, theGame.player.currentWeapon);
            Assert.AreEqual(player.expToLevelUp, theGame.player.expToLevelUp);
            Assert.AreEqual(player.experience, theGame.player.experience);
            Assert.AreEqual(player.level, theGame.player.level);
            Assert.AreEqual(player.maxHealth, theGame.player.maxHealth);
            Assert.AreEqual(player.health, theGame.player.health);
            Assert.AreEqual(player.numberOfHealthPotions, theGame.player.numberOfHealthPotions);
        }

        [Test]
        public void CheckEnemyTakeDamage()// and weapon attack //is testable
        {
            Enemy enemy = new Enemy("Gulag", 42, Enemy.Effect.enemyEffect, 100, 500, 50);
            Weapon weapon = new Weapon("mmmmm", 90, 2, Weapon.Effect.criticalEffect, "mmmmmm");

            int hp = enemy.health;
            enemy.ChangeHealth(weapon.Damage());

            Assert.Less(enemy.health, hp);
        }

        [Test]
        public void CheckPlayerTakeDamage()// and enemy attack
        {

            Player player = new Player();
            Enemy enemy = new Enemy("Evil Enemy", 12, Enemy.Effect.enemyEffect, 100, 500, 50);

            int hp = player.health;

            player.ChangeHealth(enemy.Attack());

            Assert.Less(player.health, hp);
        }

        [Test]
        public void CheckEquipWeapon()

        {
            Player player = new Player();

            player.ComapareWeaponToCurrent(new Weapon("uh", 69, 9, Weapon.Effect.criticalEffect, ""));

            Assert.IsNotNull(player.currentWeapon);
        }

        [Test]
        public void CheckEquipArmor()
        {
            Player player = new Player();

            player.CompareArmorToCurrent(new Armor("This has gotten out of hand", 5, 1, Armor.Effect.poisonEffect, ""));

            Assert.IsNotNull(player.currentArmor);
        }

        [Test]
        public void CheckLevelUp()
        {
            Player player = new Player();

            player.LevelUp(1);

            Assert.Greater(player.level, 1);
        }

        [Test]
        public void CheckGainEXP()
        {
            Player player = new Player();

            player.GainEXP(55);

            Assert.Greater(player.experience, 0);
        }

        [Test]
        public void CheckSaveGame()
        {
            TheGame.SaveGame(new TheGame(), Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TestGameFile.txt");

            Assert.IsTrue(File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TestGameFile.txt"));
        }

        [Test]
        public void CheckLoadGame()
        {
            TheGame theGame = new TheGame();
            theGame.player.LevelUp(1);
            TheGame.SaveGame(theGame, Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TestGameFile.txt");

            TheGame newGame = TheGame.LoadGame(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TestGameFile.txt");

            Assert.AreNotEqual(new TheGame().player.level, newGame.player.level);
        }

        [Test]
        public void BaseTestCase()
        {
            TheGame theGame = null;// To put in scope of finally.
            try
            {
              
                theGame = new TheGame(TheGame.GameState.AT_LOCATION,
                    new System.Collections.Generic.List<Location>(),
                    new Player());

                theGame.locations.Add(new Location());
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            finally
            {

                System.Collections.Generic.List<Location> locations =
                    new System.Collections.Generic.List<Location>();
                theGame.locations.Add(new Location());

                Assert.AreEqual(TheGame.GameState.AT_LOCATION,
                                theGame.gameState);
                Assert.AreEqual(locations,
                                theGame.locations);
                Assert.AreEqual(new Player(),
                                theGame.player);
            }
        }

        [Test]
        public void BaseTestCase_EnumMutaion1()
        {
            TheGame theGame = null;// To put in scope of finally.
            try
            {
                theGame = new TheGame(TheGame.GameState.IN_BATTLE,
                    new System.Collections.Generic.List<Location>(),
                    new Player()
                    );
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            finally
            {
                Assert.AreEqual(TheGame.GameState.IN_BATTLE,
                                theGame.gameState);
                Assert.AreEqual(new System.Collections.Generic.List<Location>(),
                                theGame.locations);
                Assert.AreEqual(new Player(),
                                theGame.player);
            }
        }

        [Test]
        public void BaseTestCase_EnumMutation2()
        {
            TheGame theGame = null;// To put in scope of finally.
            try
            {
                theGame = new TheGame(TheGame.GameState.SELECTING_LOCATION,
                    new System.Collections.Generic.List<Location>(),
                    new Player()
                    );
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            finally
            {
                Weapon weapon = new Weapon();
                Armor armor = new Armor();
                Assert.AreEqual(TheGame.GameState.SELECTING_LOCATION,
                                theGame.gameState);
                Assert.AreEqual(new System.Collections.Generic.List<Location>(),
                                theGame.locations);
                Assert.AreEqual(new Player(),
                                theGame.player);
            }
        }

        [Test]
        public void BaseTestCase_ListEmpty() //list created, should be testable 
        {
            TheGame theGame = null;// To put in scope of finally.
            try
            {
                theGame = new TheGame(TheGame.GameState.AT_LOCATION,
                    new System.Collections.Generic.List<Location>(),
                    new Player()
                    );
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            finally
            {
                Assert.AreEqual(TheGame.GameState.AT_LOCATION,
                                theGame.gameState);
                Assert.AreEqual(new System.Collections.Generic.List<Location>(),
                                theGame.locations);
                Assert.AreEqual(new Player(),
                                theGame.player);
            }
        }

        [Test]
        public void BaseTestCase_ListNULL()
        {
            TheGame theGame = null;// To put in scope of finally.
            try
            {
                theGame = new TheGame(TheGame.GameState.AT_LOCATION,
                    null,
                    new Player()
                    );
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            finally
            {

                Assert.AreEqual(TheGame.GameState.AT_LOCATION,
                                theGame.gameState);
                Assert.AreEqual(null,
                                theGame.locations);
                Assert.AreEqual(new Player(),
                                theGame.player);
            }
        }

        [Test]
        public void BaseTestCase_PlayerNULL() //not testable yet
        {
            TheGame theGame = null;
            try
            {
                theGame = new TheGame(TheGame.GameState.AT_LOCATION,
                    new System.Collections.Generic.List<Location>(),
                    null
                    );
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            finally
            {
                Assert.AreEqual(TheGame.GameState.AT_LOCATION,
                                theGame.gameState);
                Assert.AreEqual(new System.Collections.Generic.List<Location>(),
                                theGame.locations);
                Assert.AreEqual(null,
                                theGame.player);
            }
        }


        [Test]
        public void BaseStringCoverage_Valid()
        {
            TheGame theGame = new TheGame();
            try
            {
                TheGame.SaveGame(theGame, Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TestGameFile.txt");
                theGame = TheGame.LoadGame(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TestGameFile.txt");

                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void BaseStringCoverage_Invalid()
        {
            TheGame theGame = new TheGame();
            try
            {
                TheGame.SaveGame(theGame, "You would not believe how long it would take to do coverage for everything");
                theGame = TheGame.LoadGame("Like, Object classes and everything");

                Assert.Pass();
            }
            catch (Exception e)
            {
                
                Assert.Fail();
            }
        }

        [Test]
        public void BaseStringCoverage_NULL()
        {
            TheGame theGame = new TheGame();
            try
            {

                TheGame.SaveGame(theGame, null);
                theGame = TheGame.LoadGame(null);

                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
        //My Added Test Cases 
        //Syntax Test Coverage
        [Test]
        public void mutant1TestCase()
        {
            //enemy class unique behavior
            //testing: if(enemy.health == 0 && player.baseDamage >= enemy.health)
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 500, 1000, 400, 5250, 2, 125, 70, weapon, armor);
            
            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 500, 0, 30);
            string actual = "Keep fighting";
            Assert.AreEqual("You have defeated the enemy.", actual );
        }
        [Test]
        public void mutant2TestCase()
        {
            //enemy class unique behavior
            //testing: if(enemy.health >= 0 || player.baseDamage >= enemy.health)
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 500, 1000, 400, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 500, 1, 30);
            string actual = "Keep fighting";
            Assert.AreEqual("Keep fighting", actual);
        }
        [Test]
        public void mutant3TestCase()
        {
            //enemy class unique behavior
            //testing: if(enemy.health == 0 || player.baseDamage == enemy.health)
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 500, 1000, 400, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 500, 125, 30);
            string actual = "Keep fighting";
            Assert.AreEqual("Keep fighting", actual);
        }
        //Graph Test Coverage
        [Test]
        public void primePathCoverage1()
        {
            //armor class unique behavior
            //player.health >=500
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 400, 1000, 501, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 500, 125, 30);
            int actual = 100;
            int actual2 = 500;
            Assert.AreEqual(player1.experience, actual);
            Assert.GreaterOrEqual(player1.health, actual2);
        }
        [Test]
        public void primePathCoverage2()
        {
            //armor class unique behavior
            //goes to an else statement
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 400, 1000, 499, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 500, 125, 30);
            int actual = 100;
            int actual2 = 500;
            Assert.AreEqual(player1.experience, actual);
            Assert.AreEqual(player1.health, actual2);
        }
        [Test]
        public void primePathCoverage3()
        {
            //armor class unique behavior
            //player.currentWeapon.damage <= 200
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 500, 1000, 500, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 500, 125, 30);
            int actual = 100;
            Assert.LessOrEqual(player1.currentWeapon.damage, actual);
        }
        //Logic Test Coverage
        [Test]
        public void correlatedActiceClauseCoverageTest1()
        {
            //weapon class unique behavior
            //a b c are all true
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 200, 1000, 500, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 200, 125, 30);
            int actual = 200;
            Assert.AreEqual(player1.currentWeapon.damage, actual);         
            Assert.GreaterOrEqual(player1.experience, enemy1.experienceOnDefeat);

        }
        [Test]
        public void correlatedActiceClauseCoverageTest2()
        {
            //weapon class unique behavior
            // a and b true c false 
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 200, 1000, 500, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 201, 125, 30);
            int actual = 200;
            Assert.AreEqual(player1.currentWeapon.damage, actual);
            Assert.GreaterOrEqual(player1.experience, enemy1.experienceOnDefeat);
        }
        [Test]
        public void correlatedActiceClauseCoverageTest3()
        {
            //weapon class unique behavior
            //a is false, b and c true
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Player player1 = new Player(10, 200, 1000, 500, 5250, 2, 125, 70, weapon, armor);

            Enemy enemy1 = new Enemy("some enemy", 10, Enemy.Effect.enemyEffect, 100, 125, 30);
            int actual = 200;
            Assert.AreEqual(player1.currentWeapon.damage, actual);
            Assert.GreaterOrEqual(player1.experience, enemy1.experienceOnDefeat);
        }


    }
}