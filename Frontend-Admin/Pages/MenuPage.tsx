import { createEffect, createResource, For,type Component } from 'solid-js';
import Navbar from './Navbar';
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
  CardFooter
} from "~/components/ui/card"
import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"
import { Button } from "~/components/ui/button"
import { useNavigate } from "@solidjs/router";
import {
  Dialog,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from "~/components/ui/dialog"

interface MenuItem{
  id : number;
  description: string;
  name: string;
  price: number;
} 


const MenuPage: Component = () => {

  const navigate = useNavigate();  
  const [Menu] = createResource<MenuItem[] | undefined>(() => fetch("http://api.localhost/MenuCard").then(body=>body.json()))
      createEffect(() => console.log(Menu()))
  
  
  function DeleteMenuItem(Id : number) {
    fetch(`http://api.localhost/MenuCard/${Id}`, {method: "DELETE"});
    setTimeout(() => location.reload(), 400);
    
  }

  function UpdateMenuItem(Id : number) {
     localStorage.setItem("MenuItemID", Id.toPrecision());
    setTimeout(() => navigate("/UpdateMenuItemPage"), 400)
  }

  

  return (
    <div>
      <Navbar/>
      
      <NavigationMenu>
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/CreateMenuItemPage">
            <Button class="NieuwMenuItem">Nieuwe Menu item toevoegen</Button>
          </NavigationMenuTrigger>
        </NavigationMenuItem>
      </NavigationMenu>
      <For each ={Menu()}>
        {item => 
          <div>
            <Card class="MenuCard">
              <CardHeader>
                <CardTitle> {item.name}  </CardTitle>
                <CardDescription> {item.description} </CardDescription>
              </CardHeader>
              <CardContent>
                <img
                  class="card-image"
                  src="https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM="
                  alt="Placeholder"
                />                
                <p>€: {item.price}</p>
                
                
              </CardContent>
              <CardFooter>
                <div class="">
                      <Dialog>
                        <DialogTrigger><Button class="DeleteItemButton">Delete</Button></DialogTrigger>
                        <DialogContent>
                          <DialogHeader>
                            <DialogTitle>Weet je zeker dat je deze wilt verwijderen?</DialogTitle>
                          </DialogHeader>
                          <DialogFooter>
                            <Button onclick={() => DeleteMenuItem(item.id)} class="DeleteConfirm">Delete</Button>
                          </DialogFooter>
                        </DialogContent>
                      </Dialog>
                      <Button onclick={() => UpdateMenuItem(item.id)}>Update</Button>

                  </div>
              </CardFooter>
            </Card>
          </div>
        }
      </For>
    </div>
  );
};

export default MenuPage;
