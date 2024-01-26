module GameTypes

type Entity = {
    id: int
}

type GameState = {
    Entities: Entity list
}
type Direction = Up | Down | Left | Right
//type for actions, and input bindings should then be a list of pairs entity, action
type Action = 
    Melee 
    | Shoot 
    | Move of Direction