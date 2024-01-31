module GameLogic

open GameTypes
open System.Numerics

let [<Literal>] MoveSpeed  = 0.1f
let [<Literal>] ScreenSize = 100f

let move (entity : Entity) (dir : Vector2) =
    let step = MoveSpeed * Vector2.Normalize(dir)
    {entity with Pos = Vector2.Clamp ( entity.Pos + step, Vector2.Zero, Vector2(ScreenSize)) }

let applyAction (entity : Entity) (action : GameAction) = 
    match action with
    | Move(dir) -> move entity dir

let updateState (state: GameState) (actions: GameAction List) =
    let newEntities = List.map2 applyAction state.Entities actions
    let newStep = state.Step + 1
    {Entities = newEntities; Step = newStep}