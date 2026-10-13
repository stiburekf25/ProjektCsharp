using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing.Text;

namespace Hra_VYS
{
    public class mojehra : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // vykres hrace.
        private Texture2D _textura_hrace;
        //

        // Udaje o hracovi.
        Vector2 _pozice_hrace;
        float _rychlost_hrace;
        Vector2 _velikost_hrace;
        //



        public mojehra()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Proměné

            _pozice_hrace = new Vector2(100, 200);
            _rychlost_hrace = 5f;
            _velikost_hrace = new Vector2 (100, 100);

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            


            base.Initialize();
        }

        protected override void LoadContent()
        {
            //.Content , Načtení tetxur do paměti 

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _textura_hrace = new Texture2D(GraphicsDevice, 1, 1);

            _textura_hrace.SetData(new Color[] { Color.Beige });

        }

        protected override void Update(GameTime gameTime)
        {
            // Logika hry

            // reakce na klavesnice state
            KeyboardState klavesnice = Keyboard.GetState();
            //

            // vypnutí hry
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //

            // chuze wasd
            if (klavesnice.IsKeyDown(Keys.W))
            {
                _pozice_hrace.Y -= _rychlost_hrace;
            }
            if (klavesnice.IsKeyDown(Keys.S))
            {
                _pozice_hrace.Y += _rychlost_hrace;
            }
            if (klavesnice.IsKeyDown(Keys.D))
            {
                _pozice_hrace.X += _rychlost_hrace;
            }
            if (klavesnice.IsKeyDown(Keys.A))
            {
                _pozice_hrace.X -= _rychlost_hrace;
            }
            //

            // nastavení fullscreen
            if (klavesnice.IsKeyDown(Keys.F11))
            {
                _graphics.ToggleFullScreen();
                _graphics.ApplyChanges();
            }
   
            //

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {   
            // Vykreslovaní snímku za frame
            
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_textura_hrace, new Rectangle((int)_pozice_hrace.X, (int)_pozice_hrace.Y, (int)_velikost_hrace.X, (int)_velikost_hrace.Y), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
