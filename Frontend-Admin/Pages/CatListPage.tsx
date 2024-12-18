//#region Imports
import { createEffect, createResource, For,type Component } from 'solid-js';
import Navbar from './Navbar';
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle
} from "~/components/ui/card"
import "../css/CategoryCardCss.css";
import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"
import {
  Dialog,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from "~/components/ui/dialog"
//#endregion


interface Cat{
  catID: number;
  catDescription: string;
  catIMG: string;
  catName: string;
}

const CatListPage: Component = () => {
  
  const [cats] = createResource<Cat[] | undefined>(() => fetch("https://api.localhost/Cats").then(body=>body.json()))
  createEffect(() => console.log(cats()))  


  function DeleteCat(Id : number) {
    fetch(`https://api.localhost/Cats/${Id}`, {method: "DELETE"});
    setTimeout(() => location.reload(), 400);    
  }

  return (
    <div>
      <Navbar/>
      <NavigationMenu>
                <NavigationMenuItem>
                  <NavigationMenuTrigger as="a" href="/CreateCatPage">
                    Nieuwe Kat toevoegen
                  </NavigationMenuTrigger>
                </NavigationMenuItem>
       </NavigationMenu>
      <For each ={cats()}>
        {item => 
          <div>
            <Card>
              <CardHeader>
                <CardTitle> {item.catName}  </CardTitle>
                <CardDescription> {item.catDescription} </CardDescription>
                <CardDescription> {item.catID} </CardDescription>
              </CardHeader>
              <CardContent>
                <img
                  class="cat-card-image"
                  src= {item.catIMG}
                  alt="Placeholder"
                />
                <div class="flex justify-right">
                <Dialog>
                  <DialogTrigger>Delete</DialogTrigger>
                  <DialogContent>
                    <DialogHeader>
                      <DialogTitle>Weet je zeker dat je deze wilt verwijderen?</DialogTitle>
                    </DialogHeader>
                    <DialogFooter>
                      <button onclick={() => DeleteCat(item.catID)}>Delete</button>
                    </DialogFooter>
                  </DialogContent>
                </Dialog>

                  
                </div>
              </CardContent>
            </Card>
          </div>
        }
      </For>
    </div>
  );
};

export default CatListPage;
