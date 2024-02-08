module Draw

open GameTypes
open State
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework
open GameLogic
open System
let textureNames =
    Map [Hero, "hero"; Wall, "wall"]
   
//Load each texture once when first demanded
let mutable textures: Map<GameTypes.Texture, Texture2D> = Map []
let getTexture (content: ContentManager) texture =
    match Map.tryFind texture textures with
    | Some t -> t
    | None ->
        let name = textureNames[texture]
        let texture2D = content.Load<Texture2D>(name)
        textures <- Map.add texture texture2D textures
        texture2D

let [<Literal>] CanvasSize = 500
let draw (content: ContentManager) (spriteBatch: SpriteBatch) =
        spriteBatch.Begin()
        List.iter (fun entity ->
            let texture = getTexture content entity.Texture
            let x = entity.Position.X * CanvasSize / ScreenSize
            let y = entity.Position.Y * CanvasSize / ScreenSize
            let spriteSize = EntitySize * CanvasSize / ScreenSize
            spriteBatch.Draw(
                texture,
                Rectangle(Point(x - spriteSize / 2, y - spriteSize / 2), Point(spriteSize, spriteSize)),
                Nullable(),
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0f
            )
        ) game.Entities
        spriteBatch.End()
