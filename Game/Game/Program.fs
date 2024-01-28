open GameTypes
open System.Numerics

let [<Literal>] MoveSpeed  = 0.1f
let [<Literal>] ScreenSize = 100f

let move (entity : Entity) (dir : Direction) =
    let step = 
        (MoveSpeed * 
        match dir with 
        | Up -> -Vector2.UnitY
        | Down -> Vector2.UnitY
        | Left -> -Vector2.UnitX
        | Right -> Vector2.UnitX
        )
    {entity with Pos = Vector2.Clamp ( entity.Pos + step, Vector2.Zero, Vector2(ScreenSize)) }

let applyAction (entity : Entity) (action : Action) = 
    match action with
    | Move(dir) -> move entity dir

let updateState (state: GameState) (actions: Action List) =
    let newEntities = List.map2 applyAction state.Entities actions
    let newStep = state.Step + 1
    {Entities = newEntities; Step = newStep}

//We will construct a game state for each level
let newGame =
    {Entities = [{Pos = Vector2.Zero}]; Step = 0}

//Example of usage
let mutable game = newGame
for i in [0..1000] do
    game <- updateState game [Move(Down)]
    //This is an access of protected members, so will not be possible in consumer code.
    //We will write functions to access the internals of the game state in a limited manner
    printfn $"{game.Entities.Head.Pos}"