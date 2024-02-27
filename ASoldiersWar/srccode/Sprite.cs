using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    
    public class Sprite
    {
        protected readonly Texture2D texture;
        protected readonly Vector2 origin;
        public Vector2 Position { get; set; }
        public float Rotation  { get; set; }
        public Color Color { get; set; }
        public float Scale { get; set; }

        public Sprite(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.Position = pos;
            this.Color = Color.White;


            this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(texture, Position, null, Color.White, Rotation, origin, 1, SpriteEffects.None, 1);
        }
    }
}
