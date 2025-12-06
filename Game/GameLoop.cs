using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils.Difficulty;
using System;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        private Difficulty difficulty;
        
        
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void SetDifficulty()
        {   
            while (difficulty == null) 
            {
                Console.WriteLine($"Let set difficulty for your adventure\n" +
                $"Type {DifficultyLevel.easy} = {(int)DifficultyLevel.easy} " +
                $"or {DifficultyLevel.hard} = {(int)DifficultyLevel.hard} ");
                if (Enum.TryParse<DifficultyLevel>(Console.ReadLine(), out var level))
                {
                    if (level == DifficultyLevel.easy) difficulty = new DifficultyEasy();
                    else difficulty = new DifficultyHard();

                }
                
             }
        }

        private void Initialize()
        {
            SetDifficulty();
            Console.WriteLine("Welcome, player!");
            Console.WriteLine("Enter your name");
            difficulty.SetDifficulty(Console.ReadLine(), out _player, out _dungeon);
            Console.WriteLine($"Hello {_player.Name}");
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void CheckDifficulty(DifficultyLevel level)
        { if (level == DifficultyLevel.hard) { }
            
        }
        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                    
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
