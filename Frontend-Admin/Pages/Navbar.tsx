import {createSignal,createEffect, createResource, type Component, For } from 'solid-js';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { showToast, Toaster } from "~/components/ui/toast"
import { Button, buttonVariants } from "~/components/ui/button"
import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"

const Navbar: Component = () => {
  
      const navigate = useNavigate();
      const LoginName = sessionStorage.getItem("LoginName")
      const LoginPassword = sessionStorage.getItem("LoginPassword")

      function LoginValidation() 
      {
        fetch(`https://api.localhost/Login?username=${LoginName}&password=${LoginPassword}`,
        {method: "POST"} ).then((response)=>{
            console.log(response.status)
            if (response.status == 500) 
            {           
                 setTimeout(() => navigate("/"), 400)
            } 
        });
      }

      function Logout() 
      {
        sessionStorage.clear
        localStorage.clear
      }
  
      createEffect(() => {
        LoginValidation();
      })
  return (
          
    <div>
        <NavigationMenu>
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/HomePage">
          <Button onclick={() => Logout()} variant="ghost">Home</Button>
          </NavigationMenuTrigger>
        </NavigationMenuItem>  
        
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/MenuPage">
          <Button onclick={() => Logout()} variant="ghost">Het Menu</Button>
          </NavigationMenuTrigger>
        </NavigationMenuItem>
        
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/CatListPage">
          <Button onclick={() => Logout()} variant="ghost">De Katten</Button>
          </NavigationMenuTrigger>
        </NavigationMenuItem>

        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/">
            <Button onclick={() => Logout()} variant="ghost">Log out</Button>
          </NavigationMenuTrigger>
        </NavigationMenuItem>
      </NavigationMenu>
    </div>
    
    
  );
};
export default Navbar;
