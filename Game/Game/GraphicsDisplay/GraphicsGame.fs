module GraphicsGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Content
open MonoGame.Extended.Input.InputListeners
open GameTypes
open InputOutput
open Textures
open Input

type GraphicsGame () as this =
    inherit Game()
 
    do this.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>

    override this.Initialize() =
        spriteBatch <- new SpriteBatch(this.GraphicsDevice)
        base.Initialize()
         
        // TODO: Add your initialization logic here
        ()

    override this.LoadContent() =
        let tex = this.Content.Load<Texture2D>("hero.png")
        ()
 
    override this.Update (gameTime) =

         takeInput()
         base.Update gameTime
 
    override this.Draw (gameTime) =

        this.GraphicsDevice.Clear Color.CornflowerBlue
        spriteBatch.Begin()
        List.iter (fun entity ->
            let texture = getTexture this.Content entity.Texture
            spriteBatch.Draw(
                texture,
                entity.Position,
                new Rectangle(Point.Zero, new Point(texture.Width, texture.Height)),
                Color.White,
                0f,
                Vector2.Zero,
                Vector2.One * 4f,
                SpriteEffects.None,
                0f
            )
        ) game.Entities
        base.Draw gameTime
        spriteBatch.End()
