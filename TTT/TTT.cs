using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TTT.Enums;
using TTT.Models;
using TTT.Services.Interfaces;

namespace TTT
{
    public class TTT : Game
    {
        readonly IContentService contentService;
        readonly ITileService tileService;
        readonly IMapService mapService;
        readonly IRegistrationService registrationService;

        public TTT(
            IContentService contentService,
            ITileService tileService,
            IMapService mapService,
            IRegistrationService registrationService)
        {
            this.contentService = contentService;
            this.tileService = tileService;
            this.mapService = mapService;
            this.registrationService = registrationService;
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            World = new Rectangle(0, 0, WindowDimensions.width / zoom, WindowDimensions.height / zoom);
            GraphicsDeviceManager.PreferredBackBufferHeight = WindowDimensions.height;
            GraphicsDeviceManager.PreferredBackBufferWidth = WindowDimensions.width;
            TransformMatrix = Matrix.CreateScale(zoom);
        }

        (int width, int height) WindowDimensions => (width: 270, height: 270);
        const int zoom = 1;
        GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        SpriteBatch SpriteBatch { get; set; }
        Rectangle World { get; set; }

        public static Camera Camera { get; set; }
        public static Matrix TransformMatrix { get; set; }
        public static Map Map { get; set; } = new Map();
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
            Camera = new Camera(SpriteBatch);
        }

        public static Vector2 ScreenToWorld(Vector2 onScreen)
        {
            var matrix = Matrix.Invert(Camera.TransformMatrix);
            return Vector2.Transform(onScreen, matrix);
        }

        protected override async void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyState.IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
                await tileService.UpdateTile(mouseState);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);
            SpriteBatch.Begin(
                sortMode: SpriteSortMode.Immediate,
                samplerState: SamplerState.PointClamp,
                transformMatrix: Camera.Transform(GraphicsDevice, WindowDimensions));
            foreach (var tile in Map.Tiles)
            {
                tile.Draw(SpriteBatch);
            }
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
