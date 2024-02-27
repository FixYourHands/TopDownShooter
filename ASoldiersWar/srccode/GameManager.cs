using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class GameManager
    {
        private readonly Player _player;
        public GameManager()
        {
            _player = new Player(Globals.Content.Load<Texture2D>("Assets\\ak47idleSheet"), new(200, 200));

        }

        public void Update()
        {
            InputManager.Update();
            _player.Update();
        }

        public void Draw()
        {
            _player.Draw();
        }
    }
}
