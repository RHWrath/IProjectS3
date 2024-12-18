import { createEffect, createResource, For, type Component } from 'solid-js';
import Navbar from './Navbar';
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle
} from "~/components/ui/card"

interface MenuItem{
  description: string;
  name: string;
  price: number;
} 


const MenuPage: Component = () => {
  const [Menu] = createResource<MenuItem[] | undefined>(() => fetch("https://api.localhost/MenuCard").then(body=>body.json()))
      createEffect(() => console.log(Menu()))
  
  
  return (
    <div>
      <Navbar/>
      <For each ={Menu()}>
        {item => 
          <div>
            <Card>
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
            </Card>
          </div>
        }
      </For>
    </div>
  );
};

export default MenuPage;
