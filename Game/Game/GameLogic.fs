module GameLogic

open GameTypes
open System

let [<Literal>] MoveSpeed  = 1
let [<Literal>] ScreenSize = 100

let move (entity : Entity) (dir : Direction) =
    let pos = entity.Position
    let step = 
        match dir with
        | Up -> {X = 0; Y = -MoveSpeed}
        | Down -> {X = 0; Y = MoveSpeed}
        | Left -> {X = -MoveSpeed; Y = 0}
        | Right -> {X = MoveSpeed; Y = 0}
    let newX = Math.Clamp(pos.X + step.X, 0, ScreenSize)
    let newY = Math.Clamp(pos.Y + step.Y, 0, ScreenSize)
    {entity with Position = {X = newX; Y = newY}}

let applyAction (entity : Entity) (action : GameAction) = 
    match action with
    | Move(dir) -> move entity dir
    | Idle -> entity

let updateState (state: GameState) (actions: GameAction List) =
    let newEntities = List.map2 applyAction state.Entities actions
    let newStep = state.Step + 1
    {Entities = newEntities; Step = newStep}