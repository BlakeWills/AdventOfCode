module DayOne

open System.IO

let run = 
    let calculateCalories (file:string) = 
        use stream = new StreamReader (file)

        let mutable elfCalories = List.empty
        let mutable curCalories = 0

        let incCalories v =
            let cal = v |> int
            curCalories <- curCalories + cal

        let newElf () =
            elfCalories <- curCalories :: elfCalories
            curCalories <- 0

        let mutable moreData = true
        while moreData do
            let line = stream.ReadLine()
            match line with
            | "" -> newElf() |> ignore
            | null -> moreData <- false
            | v -> incCalories v

        elfCalories
            |> List.sort
            |> List.skip (elfCalories.Length - 3)
            |> List.sum

    let calories = calculateCalories (Helpers.getDataPath "01.txt")
    printfn $"Top three elves are carrying {calories} calories"

