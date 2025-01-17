//#region Imports
import { createEffect, createResource, For,type Component } from 'solid-js';
import Navbar from './Navbar';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
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
import { useNavigate } from "@solidjs/router";
import { Button } from "~/components/ui/button"
//#endregion


interface Cat{
  catID: number;
  catDescription: string;
  catIMG: string;
  catName: string;
}

const CatListPage: Component = () => {

  const navigate = useNavigate();  
  const [cats] = createResource<Cat[] | undefined>(() => fetch("http://api.localhost/Cats").then(body=>body.json()))
  createEffect(() => console.log(cats()))  


  function DeleteCat(Id : number) {
    fetch(`http://api.localhost/Cats/${Id}`, {method: "DELETE"});
    setTimeout(() => location.reload(), 400);    
  }

  function UpdateCat(Id : number) {
      localStorage.CatID = Number(Id);
      localStorage.setItem("CatID", Id.toPrecision());
      setTimeout(() => navigate("/UpdateCatPage"), 400)
  }

  return (
    <div>
      <Navbar/>
      <NavigationMenu>
                <NavigationMenuItem>
                  <NavigationMenuTrigger as="a" href="/CreateCatPage">
                    <Button class="NieuwKatButton">Nieuwe Kat toevoegen</Button>
                  </NavigationMenuTrigger>
                </NavigationMenuItem>
       </NavigationMenu>
      <For each ={cats()}>
        {item => 
          <div>
            <Card class ="CatCard">
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
              </CardContent>
              <CardFooter>
                <div class="">
                      <Button onclick={() => UpdateCat(item.catID)}>Aanpassen</Button>
                      <Dialog>
                        <DialogTrigger><Button class="DeleteCatButton">Delete</Button></DialogTrigger>
                        <DialogContent>
                          <DialogHeader>
                            <DialogTitle>Weet je zeker dat je deze wilt verwijderen?</DialogTitle>
                          </DialogHeader>
                          <DialogFooter>
                            <Button onclick={() => DeleteCat(item.catID)} class="DeleteConfirm">Confirm</Button>
                          </DialogFooter>
                        </DialogContent>
                      </Dialog>                    
                  </div>
              </CardFooter>
            </Card>
          </div>
        }
      </For>
    </div>
  );
};

export default CatListPage;
