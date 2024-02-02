module EntitySelector

open GraphicsGame
open Microsoft.Xna.Framework

type EntitySelector(game:GraphicsGame) as this =
    inherit GameComponent(game)

    