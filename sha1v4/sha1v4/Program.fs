// Learn more about F# at http://fsharp.org

open System
open System.Text
open File2

[<EntryPoint>]
let main argv =
    let lab1 s = 
        let list:list<int> = [0]
        let rec ContainsOne n =
            if n = 0 
                then false 
                else
            if n%10 = 1
                then true 
                else ContainsOne (n/10)
        let need,noneed = List.partition ContainsOne [1..100]
        //for i in need do
            //printfn "%d" i
        printfn "%d" (List.sum need)
    //lab1 0
    let getwords (s:string) = s.Split("\" ,:-.!?;()\t\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)
    let lab2 (s:string) =
        let words = getwords s
        let count pred = Array.filter pred >> Array.length
        Array.distinct words
        |> Array.map (fun w -> w, count ((=)w) words)
        |> Array.minBy (fun (_, n) -> n)
    //let text = System.IO.File.ReadAllText("words.txt",Encoding.UTF8)
    //let a = lab2 text
    //printfn "%A" a
    let lab3 (a:array<int>) =
        for i in [0..((Array.length a)-2)] do
            if (a.[i+1]%2=0) then
                Array.set a i (a.[i]-2) 
        printf "%A" a
    //lab3 [|1;2;3;4;5;6;7;8;9|]
    let lab4 a = 
        let client:Client = Client("Вася")
        let saleman:Salesman = Salesman("Ира")
        printf "%A" (client.ToString())
        printf "%A" (saleman.ToString())
    let lab2A (file) =
        async{
            let s = System.IO.File.ReadAllText(file,Encoding.UTF8)
            let a = lab2(s)
            printf "%A\n" a
        }
        

    let lab5 e =
        let files = [
            @"C:\Users\Admin\Documents\GitHub\Sem4\sha1v4\sha1v4\files\1.txt"
            @"C:\Users\Admin\Documents\GitHub\Sem4\sha1v4\sha1v4\files\2.txt"
            @"C:\Users\Admin\Documents\GitHub\Sem4\sha1v4\sha1v4\files\3.txt"
        ]
        files
        |>List.map lab2A
        |>Async.Parallel
        |>Async.RunSynchronously
        |> ignore
        0
    lab5 0
    0 // return an integer exit code



