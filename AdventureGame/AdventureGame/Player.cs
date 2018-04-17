using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Player : Mover
    {
        // FIELDS
        private Weapon equippedWeapon;
        private List<Weapon> inventory = new List<Weapon>();

        // CONSTRUCTORS
        public Player(Game game, Point location)
            : base(game, location)
        {
            HitPoints = 10;
        }

        // PROPERTIES
        public int HitPoints { get; private set; }

        // SETTERS AND GETTERS
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach(Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }


        // METHODS
        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }
        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }
        public void Equip(string weaponName)
        {
            foreach(Weapon weapon in inventory)
            {
                if(weapon.Name == weaponName)
                {
                    equippedWeapon = weapon;
                }
            }
        }
        public void Move()
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                // sprawdz czy broń jest w pobliżu, a jeśli tak to podnieś ją
            }
        }
        public void Attack(Direction direction, Random random)
        {
            
        }
    }
}
