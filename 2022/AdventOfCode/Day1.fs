module DayOne

open System
open System.IO

let run = 

    let paths = [@"..\..\..\Data\01.txt"; @"Data\01.txt"]

    let path = 
        paths
        |> List.filter (fun x -> File.Exists (Path.Combine (Environment.CurrentDirectory, x)))
        |> List.head

    let calculateCalories file = 
        use stream = new StreamReader (path)

        let mutable elfCalories = List.empty;
        let mutable curCalories = 0

        let incCalories v =
            let cal = v |> int
            curCalories <- curCalories + cal

        let newElf () =
            elfCalories <- List.append elfCalories [curCalories]
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

    let calories = calculateCalories path
    printfn $"Top three elves are carrying {calories} calories"

