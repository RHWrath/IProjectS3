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

interface Cat{
  catDescription: string;
  catIMG: string;
  catName: string;
}

const CreateCatPage: Component = () => {
  const [cats] = createResource<Cat[] | undefined>(() => fetch("https://api.localhost/Cat").then(body=>body.json()))
  createEffect(() => console.log(cats()))

  return (
    <div>
      <Navbar/>
    </div>
  );
};

export default CreateCatPage;
