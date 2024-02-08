module Input

open GameTypes
open Microsoft.Xna.Framework.Input

let findAction (state: KeyboardState) =
    if state.IsKeyDown Keys.W then Move Up else
    if state.IsKeyDown Keys.S then Move Down else
    if state.IsKeyDown Keys.A then Move Left else
    if state.IsKeyDown Keys.D then Move Right else
    Idle

