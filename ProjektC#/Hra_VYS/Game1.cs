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
        private Texture2D _pixel;
        public Vector2 _velikost_ctverecku_hrace = new Vector2(50, 50);
        public float _rychlost_ctverecku_hrace = 3f;
        public Vector2 _pozice_ctverecku_hrace = new Vector2(400, 200);


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

            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

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

            Vector2 smer = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                smer.Y -= 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                smer.Y += 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                smer.X += 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                smer.X -= 1;
            }

            if (smer != Vector2.Zero)
            {
                smer.Normalize();

                smer *= _rychlost_ctverecku_hrace;

                _pozice_ctverecku_hrace += smer;
            }

            // nastavení fullscreen
            if (klavesnice.IsKeyDown(Keys.F11))
            {
                _graphics.ToggleFullScreen();
                _graphics.ApplyChanges();
            }
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {   
            // Vykreslovaní snímku za frame
            
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_pixel, new Rectangle(_pozice_ctverecku_hrace.ToPoint(), _velikost_ctverecku_hrace.ToPoint()), Color.Red);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
