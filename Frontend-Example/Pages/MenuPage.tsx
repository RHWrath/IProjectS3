import type { Component } from 'solid-js';

import logo from './logo.svg';
import styles from './App.module.css';
import { createResource, createSignal, For } from 'solid-js';
import { Flex } from '../src/components/ui/flex';
import { Switch, SwitchControl, SwitchLabel, SwitchThumb } from '../src/components/ui/switch';
import { TextField, TextFieldInput, TextFieldLabel } from '../src/components/ui/text-field';
import { Button } from "~/components/ui/button"
import { buttonVariants } from "~/components/ui/button"
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuIcon,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"

const HomePage: Component = () => {
  const [weatherLocation, setWeatherLocation] = createSignal('London')
  const [weather] = createResource(weatherLocation, (location) => fetch(`https://localhost:7123/weatherforecast?location=${location}`).then(res => res.json()))

  return (
    <Flex>
      <NavigationMenu>
        <NavigationMenuItem>
        <NavigationMenuTrigger as="a" href="HomePage">
            Home
          </NavigationMenuTrigger>
          <NavigationMenuTrigger as="a" href="MenuPage">
            Menu
          </NavigationMenuTrigger>
          <NavigationMenuTrigger as="a" href="">
            Onze Katten
          </NavigationMenuTrigger>
          <NavigationMenuTrigger as="a" href="">
            Over ons
          </NavigationMenuTrigger>
        </NavigationMenuItem>
      </NavigationMenu>
      <TextField>Get out</TextField>
    </Flex>
    
  );
};
function Test() {
  return "test";
}

export default HomePage;
