module Input

open EntitySelection
open GameTypes
open Microsoft.Xna.Framework.Input


let findAction (state:KeyboardState) =
    match state.IsKeyDown(Keys.W) with
    | true -> Move Up
    | false ->
        match state.IsKeyDown(Keys.S) with
        | true -> Move Down
        | false -> 
            match state.IsKeyDown(Keys.A) with
            | true -> Move Left
            | false -> 
            match state.IsKeyDown(Keys.D) with
            | true -> Move Right
            | false -> Idle

//Read keyboard and update selection based on it. Then control selected entity
let takeInput() =
    let state = Keyboard.GetState ()
    updateEntitySelection state
    let action = findAction state
    match getSelected() with
    | None -> ()
    | Some entity ->
        [(entity.Id, action)]
        |> InputOutput.input 
        |> ignore