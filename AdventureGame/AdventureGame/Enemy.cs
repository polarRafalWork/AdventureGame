using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    abstract class Enemy : Mover
    {
        // FIELDS
        private const int NearPlayerDistance = 25;


        // CONSTRUCTORS
        public Enemy (Game game, Point location, int hitPoints)
            : base(game, location)
        {
            this.HitPoints = hitPoints;
        }

        // PROPERTIES
        public int HitPoints{get; private set;}
        public bool Dead {
            get
            {
                if (HitPoints <= 0) return true;
                else return false;
            }
        }

        // METHODS
        public abstract void Move(Random random);
        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }
        protected bool NearPlayer()
        {
            return (Nearby(game.PlayerLocation, NearPlayerDistance));
        }
        protected Direction FindPlayerDirection (Point playerlocation)
        {
            Direction directionToMove;
            if (playerlocation.X > location.X + 10)
                directionToMove = Direction.RIGHT;
            else if (playerlocation.X < location.X - 10)
                directionToMove = Direction.LEFT;
            else if (playerlocation.Y < location.Y - 10)
                directionToMove = Direction.UP;
            else
                directionToMove = Direction.DOWN;
            return directionToMove;
        }
    }

}
