open GameTypes
open GameLogic
open Microsoft.Xna.Framework.Input
open Graphics
open Input
open Draw
open InputOutput
open System

//We will construct a game state for each level
let newGame =
    {Entities = [{Position = {X = 0; Y = 0}; Id = 0; Texture = Hero}]; Step = 0}
let mutable game = newGame
let mutable selectedIdx = 0
let mutable rightDown = false
let mutable leftDown = false

let updateEntitySelection (state:KeyboardState) (numEntities : int) =
    let IncrementSelected() =
        selectedIdx <- (selectedIdx + 1) % numEntities
    let DeincrementSelected() =
        selectedIdx <- Math.Max(selectedIdx - 1, 0)

    if state.IsKeyDown Keys.Right && not rightDown then IncrementSelected()
    else if state.IsKeyDown Keys.Left && not leftDown then DeincrementSelected()

    rightDown <- state.IsKeyDown Keys.Right
    leftDown <- state.IsKeyDown Keys.Left


//Read keyboard and update selection based on it. Then control selected entity
let takeInput() =
    let state = Keyboard.GetState()
    updateEntitySelection state game.Entities.Length
    let action: GameAction = findAction state
    game <- 
        [(selectedIdx, action)]
        |> (actionBindingsToActionList game.Entities)
        |> updateState game

let graphics = new Game1(takeInput, draw game.Entities)
//TODO: also get a thread going with our web server
graphics.Run()

