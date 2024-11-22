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

interface Cat{
  catDescription: string;
  catIMG: string;
  catName: string;
}

const CatListPage: Component = () => {
  const [cats] = createResource<Cat[] | undefined>(() => fetch("https://api.localhost/Cat").then(body=>body.json()))
  createEffect(() => console.log(cats()))

  return (
    <div>
      <Navbar/>
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
              </CardContent>
            </Card>
          </div>
        }
      </For>
    </div>
  );
};

export default CatListPage;
