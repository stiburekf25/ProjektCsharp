using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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


        public mojehra()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_pixel, new Rectangle(_pozice_ctverecku_hrace.ToPoint(), _velikost_ctverecku_hrace.ToPoint()), Color.Red);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
