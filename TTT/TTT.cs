using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TTT.Enums;
using TTT.Models;
using TTT.Services.Interfaces;

namespace TTT
{
    public class TTT : Game
    {
        readonly IContentService contentService;
        readonly IMapService mapService;
        readonly IRegistrationService registrationService;

        public TTT(
            IContentService contentService,
            IMapService mapService,
            IRegistrationService registrationService)
        {
            this.contentService = contentService;
            this.mapService = mapService;
            this.registrationService = registrationService;
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            World = new Rectangle(0, 0, WindowSize.width / zoom, WindowSize.height / zoom);
            GraphicsDeviceManager.PreferredBackBufferHeight = WindowSize.height;
            GraphicsDeviceManager.PreferredBackBufferWidth = WindowSize.width;
        }

        (int width, int height) WindowSize => (640, 640);
        const int zoom = 4;
        GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        SpriteBatch SpriteBatch { get; set; }
        Rectangle World { get; set; }

        public static Map Map { get; set; }
        public static Dictionary<Board, (Texture2D, Vector2)> BoardTextures { get; set; } = new Dictionary<Board, (Texture2D, Vector2)>();
        public static Dictionary<Player, (Texture2D, Vector2)> PlayerTextures { get; set; } = new Dictionary<Player, (Texture2D, Vector2)>();


        protected override async void Initialize()
        {
            await registrationService.InitializeAsync();
            await contentService.LoadContent(Content);
            Map = await mapService.GenerateNewMap();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyState.IsKeyDown(Keys.Escape))
                Exit();
            //foreach (var tile in Map.Tiles)
            //    tile.Update(tile.position, tile.Player);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);
            SpriteBatch.Begin(
                sortMode: SpriteSortMode.Immediate,
                samplerState: SamplerState.PointClamp,
                transformMatrix: Matrix.CreateScale(zoom));
            foreach (var tile in Map.Tiles)
                tile.Draw(SpriteBatch);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
