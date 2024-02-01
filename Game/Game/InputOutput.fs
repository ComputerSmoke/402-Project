module InputOutput

open GameTypes
open GameLogic

open Microsoft.Xna.Framework

//We will construct a game state for each level
let newGame =
    {Entities = [{Pos = Vector2.Zero; Id = 0; Color = new Color(255, 0, 0)}]; Step = 0}
let mutable game = newGame

let input (actions:ActionBinding list) =
    let actionByEntity = 
        List.map (fun entity ->
            match List.tryFind (fun (id, _) -> entity.Id = id) actions with
            | None -> Idle
            | Some (_, action) -> action
        ) game.Entities
    game <- updateState game actionByEntity
    game