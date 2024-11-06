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
          <NavigationMenuTrigger as="a" href="/MenuPage">
            Menu
          </NavigationMenuTrigger>
          <NavigationMenuTrigger as="a" href="/CatListPage">
            Onze Katten
          </NavigationMenuTrigger>
          <NavigationMenuTrigger as="a" href="/AboutUsPage">
            Over ons
          </NavigationMenuTrigger>
        </NavigationMenuItem>
      </NavigationMenu>
    
  );
};
export default Navbar;
