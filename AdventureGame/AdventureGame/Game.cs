using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // dla klasy rectangle

namespace AdventureGame
{
    class Game
    {
        // FIELDS
        private Player player;
        private int level = 0;
        private Rectangle boundaries;
        // PROPERTIES


        public IEnumerable<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }


        public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }
        public int Level { get { return level; } }
        public Rectangle Boundaries { get { return boundaries; } }

        // CONSTRUCTORS
        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70));
        }

        // METHODS

            // poruszanie się
        public void Move(Direction direction, Random random)
        {
            player.Move(direction);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }
            // uzbrojenie w nową broń
        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }
            // sprawdzenie ekwipunku gracza
        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }
            // sprawdzenie hit pointów
        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }
            // zwiększenie hit pointów
        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }
            // atak
        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }
            // wyloswanie położenia
        private Point GetRandomLocation(Random random)
        {
                return new Point(boundaries.Left + random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,
                    boundaries.Top + random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        }
            // nowy poziom
        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    {
                        Enemies = new List<Enemy>();
                        Enemies.Add(new Bat(this, GetRandomLocation(random)));
                        WeaponInRoom = new Sword(this, GetRandomLocation(random));
                        break;
                    }
            }
        }

    }
}
