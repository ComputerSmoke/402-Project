module InputOutput

open GameTypes

//This prevents a crash if the wrong length of action list is input
//I am not sure if that is a good thing or not
//Just making it crash may make debugging issues with incorrect IDs easier on the player
//We could get rid of IDs and force the player to provide a list of the correct length
//Not sure what is best
let actionBindingsToActionList (entities : Entity list) (actions: ActionBinding list) =
    List.map (fun entity ->
        match List.tryFind (fun (id, _) -> entity.Id = id) actions with
        | None -> Idle
        | Some (_, action: GameAction) -> action
    ) entities
