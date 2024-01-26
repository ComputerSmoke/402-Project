module OutputHandlers

open GameTypes
open Graphics
    
//Output handler for graphics
let graphicsOutput () =
    let game = new Graphics.GraphicsDisplay();
    //run game graphics in seperate thread
    backgroundTask {
        game.Run();
    } |> ignore
    //TODO: vary size, color
    let toDisplayEntities (entities: Entity list) = 
        List.map (fun entity -> new DisplayEntity(1f, 1, entity.pos)) entities
        |> ResizeArray<DisplayEntity>

    let outputHandler (state:GameState) = 
        game.SetEntities(toDisplayEntities state.Entities)
    outputHandler
