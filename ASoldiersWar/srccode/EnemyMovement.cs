using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class EnemyMovement
    {
        public EnemyPosition Position { get; set; }
        public EnemyMovement(EnemyPosition position)
        {
            Position = position;
        }

        public void TraverseRight()
        {
            while (Position.SoldierPosition.X < Position.Board.Columns)
            {
                Position.MoveRight();
                Console.WriteLine("Moving Right");
            }
            
        }
    }
}
