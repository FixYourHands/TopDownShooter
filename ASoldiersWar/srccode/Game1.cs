using ConsoleApp1.WarriorFight;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ASoldiersWar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        bool keyReleased = true;
        Soldier soldier1 = new Soldier(new AK47());
        Soldier billyBob = new Soldier(new AK47());
        Board board = new Board(1000, 1000);
        
        Texture2D mySprite;
        
     
         

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            billyBob.Initialize(board);
           billyBob.Position.SoldierPosition = new Vector2(150, 300);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            mySprite = Content.Load<Texture2D>("Assets\\testSprite");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

         
            if (state.IsKeyDown(Keys.Up) && keyReleased)
            {
                soldier1.Position.SoldierPosition += new Vector2(0, -1);
                soldier1.PrintPosition();
                System.Console.WriteLine(soldier1.GetDistanceToSoldier(billyBob));
                keyReleased = false;
            }

            if (state.IsKeyDown(Keys.Down) && keyReleased)
            {
                soldier1.Position.SoldierPosition += new Vector2(0, 1);
                soldier1.PrintPosition();
                keyReleased = false;
            }

            if (state.IsKeyDown(Keys.Left) && keyReleased)
            {
                soldier1.Position.SoldierPosition += new Vector2(-1,0) * soldier1.Speed;
                soldier1.PrintPosition();
                keyReleased=false;
            }

            if (state.IsKeyDown(Keys.Right) && keyReleased)
            {
                soldier1.Position.SoldierPosition += new Vector2(1, 0);
                soldier1.PrintPosition();
                System.Console.WriteLine(soldier1.GetDistanceToSoldier(billyBob));
                keyReleased =false;
            }
            keyReleased = true;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //_spriteBatch.Draw(mySprite, new Rectangle((int)soldier1.Position.SoldierPosition.X,(int)soldier1.Position.SoldierPosition.Y,100,100), Color.White);
            _spriteBatch.Draw(mySprite, new Rectangle((int)billyBob.Position.SoldierPosition.X, (int)billyBob.Position.SoldierPosition.Y, 100, 100), Color.White);



            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}