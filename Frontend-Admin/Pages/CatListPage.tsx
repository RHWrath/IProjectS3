//#region Imports
import { createEffect, createResource, For, Show, type Component } from 'solid-js';
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
  NavigationMenuContent,
  NavigationMenuIcon,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"
import { reload, useNavigate } from "@solidjs/router";
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


  function DeleteCat(Id : Number) {
    const createCatApiCall = fetch(`https://api.localhost/Cats?CatID=${Id}`, {method: "DELETE"});
    setTimeout(() => location.reload(), 3000);
    
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
              </CardHeader>
              <CardContent>
                <img
                  class="cat-card-image"
                  src= {item.catIMG}
                  alt="Placeholder"
                />
                <div class="flex justify-right">
                  <button onclick={() => DeleteCat(item.catID)}>Delete</button>
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
