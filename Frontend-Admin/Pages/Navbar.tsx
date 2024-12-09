import type { Component } from 'solid-js';

import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuIcon,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"

const Navbar: Component = () => {
  return (
      <NavigationMenu>
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/HomePage">
            Home
          </NavigationMenuTrigger>
        </NavigationMenuItem>  
        
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/MenuPage">
            Menu
          </NavigationMenuTrigger>
        </NavigationMenuItem>
        
        <NavigationMenuItem>
          <NavigationMenuTrigger as="a" href="/CatListPage">
            De Katten
          </NavigationMenuTrigger>
        </NavigationMenuItem>
      </NavigationMenu>
    
  );
};
export default Navbar;
