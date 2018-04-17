using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Bat : Enemy
    {
        public Bat (Game game, Point location)
            : base(game, location, 6)
        {

        }

        public override void Move(Random random)
        {
            throw new NotImplementedException();
        }
    }
}
