using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventureGame
{
    abstract class Mover
    {
        // FIELDS
        private const int MoveInterval = 10;
        protected Point location;
        protected Game game;
        
        // CONSTRUCTORS
        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }
        
        // PROPERTIES
        public Point Location { get { return location} }




        // METHODS
            // sprawdzenie bliskosci do innego obiektu
        public bool Nearby(Point locationToCheck, int distance)
        {
            if(
                (Math.Abs(location.X - locationToCheck.X)<distance) &&
                (Math.Abs(location.Y - locationToCheck.Y) < distance)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // przemieszanie się we wskazanym kierunku
        public Point Move (Direction direction, Rectangle boundaries)
        {
            Point newLocation = location;
            switch (direction)
            {
                case Direction.UP:
                    {
                        if (newLocation.Y - MoveInterval >= boundaries.Top) newLocation.Y -= MoveInterval;
                        break;
                    }
                case Direction.DOWN:
                    {
                        if (newLocation.Y + MoveInterval <= boundaries.Bottom) newLocation.Y += MoveInterval;
                        break;
                    }
                case Direction.LEFT:
                    {
                        if (newLocation.X - MoveInterval >= boundaries.Left) newLocation.X -= MoveInterval;
                        break;
                    }
                case Direction.RIGHT:
                    {
                        if (newLocation.X + MoveInterval <= boundaries.Right) newLocation.X += MoveInterval;
                        break;
                    }
                default: break;
            }
            return newLocation;
        }

    }
}
