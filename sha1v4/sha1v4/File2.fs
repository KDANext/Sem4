module File2

open System
open System.Text
open System.Text.Unicode

[<AbstractClass>]
type People(name) = 
    member val Name = name with get,set
    override this.ToString() = "People:"+name
 
type Client(name) = 
    inherit People(name)

    
type Salesman(name) =
    inherit People(name)
    let Sale(client:Client) = 
        printf "Продавец %A продал клиенту %A",name,client.Name;    
