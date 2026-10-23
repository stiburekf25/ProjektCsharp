using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hra_VYS
{
    public class Mojehra : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _pixel;
        private KeyboardState _predchozi_klavesnice;

        public Vector2 _velikost_ctverecku_hrace = new Vector2(50, 50);
        public float _rychlost_ctverecku_hrace = 3f;
        public Vector2 _pozice_ctverecku_hrace = new Vector2(400, 200);

        Vsechny_krabice vsechny_Krabice = new Vsechny_krabice(20);

        public Mojehra()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.HardwareModeSwitch = false;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // textura 1x1 bílý pixel, roztahuje se na libovolný obdélník
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavesnice = Keyboard.GetState();

            // vypnutí hry
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || klavesnice.IsKeyDown(Keys.Escape))
                Exit();

            // pohyb hráče
            Vector2 smer = Vector2.Zero;

            if (klavesnice.IsKeyDown(Keys.W)) smer.Y -= 1;
            if (klavesnice.IsKeyDown(Keys.S)) smer.Y += 1;
            if (klavesnice.IsKeyDown(Keys.A)) smer.X -= 1;
            if (klavesnice.IsKeyDown(Keys.D)) smer.X += 1;

            if (smer != Vector2.Zero)
            {
                smer.Normalize();
                _pozice_ctverecku_hrace += smer * _rychlost_ctverecku_hrace;
            }

            // fullscreen jen při stisku, ne při držení
            if (klavesnice.IsKeyDown(Keys.F11) && _predchozi_klavesnice.IsKeyUp(Keys.F11))
            {
                if (_graphics.IsFullScreen)
                {
                    _graphics.PreferredBackBufferWidth = 1600;
                    _graphics.PreferredBackBufferHeight = 900;
                    _graphics.IsFullScreen = false;
                }
                else
                {
                    _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                    _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                    _graphics.IsFullScreen= true;
                }
                _graphics.ApplyChanges();
            }
            _predchozi_klavesnice = klavesnice;

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_pixel, new Rectangle(_pozice_ctverecku_hrace.ToPoint(), _velikost_ctverecku_hrace.ToPoint()), Color.Red);
            vsechny_Krabice.VykreslitKrabice(_spriteBatch, _pixel);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}