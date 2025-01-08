import {createEffect,  type Component, For } from 'solid-js';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { Button} from "~/components/ui/button"
import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"

const Navbar: Component = () => {
  
      const navigate = useNavigate();
      const Loggedin = Boolean(sessionStorage.getItem("LoggedIn"));

      function LoginValidation() 
      {  if (Loggedin != true) {   navigate("/");   }    }

      function Logout() 
      {
        sessionStorage.clear
        localStorage.clear
        navigate("/")
      }
  
      createEffect(() => {
        LoginValidation();
      })
  return (
          
    <div>
        <NavigationMenu>
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/HomePage">
          <Button variant="ghost">Home</Button>
          </NavigationMenuTrigger>
        </NavigationMenuItem>  
        
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/MenuPage">
          <Button variant="ghost">Het Menu</Button>
          </NavigationMenuTrigger>
        </NavigationMenuItem>
        
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/CatListPage">
          <Button variant="ghost">De Katten</Button>
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
