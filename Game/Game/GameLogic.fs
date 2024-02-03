module GameLogic

open GameTypes
open Microsoft.Xna.Framework

let [<Literal>] MoveSpeed  = 0.1f
let [<Literal>] ScreenSize = 100f

let move (entity : Entity) (dir : Direction) =
    let dirVec = 
        match dir with
        | Up -> -Vector2.UnitY
        | Down -> Vector2.UnitY
        | Left -> -Vector2.UnitX
        | Right -> Vector2.UnitX
    let step = MoveSpeed * dirVec
    {entity with Position = Vector2.Clamp ( entity.Position + step, Vector2.Zero, Vector2(ScreenSize)) }

let applyAction (entity : Entity) (action : GameAction) = 
    match action with
    | Move(dir) -> move entity dir
    | Idle -> entity

let updateState (state: GameState) (actions: GameAction List) =
    let newEntities = List.map2 applyAction state.Entities actions
    let newStep = state.Step + 1
    {Entities = newEntities; Step = newStep}