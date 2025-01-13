//#region Imports
import {createSignal, createResource, type Component, For } from 'solid-js';
import Navbar from './Navbar';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { showToast, Toaster } from "~/components/ui/toast"
import { Button } from "~/components/ui/button"
//#endregion

interface MenuItem{
  id : number;
  description: string;
  name: string;
  price: number;
} 


const UpdateMenuItemPage: Component = () => {


  const [GetMenuName, setMenuName] = createSignal("")
  const [GetMenuDiscription, setMenuDiscription] = createSignal("")
  const [GetMenuPrice, setMenuPrice] = createSignal("")  
  let LastRequestTime =0;  
  const navigate = useNavigate();
  const MenuItemID = Number(localStorage.getItem("MenuItemID"))
  
  const [Menu] = createResource<MenuItem[] | undefined>(() => fetch(`https://api.localhost/MenuCard/${MenuItemID}`).then(body=>body.json()))

  function UpdateMenuItem() {
    console.log("item naam",GetMenuName())
    console.log("item description",GetMenuName())
    console.log("item ID",MenuItemID)

    const MenuName = GetMenuName();
    const MenuDescription = GetMenuDiscription();
    const now = Date.now();

    if (now - LastRequestTime < 1000) 
    {
      console.warn("Rate limit exceeded");
      return;
    }
    LastRequestTime = now;

    if (! /^[A-Za-z0-9 .]+$/.test(MenuName)) 
      {
        showToast({title: "Error", description: "menu naam ongeldig"})
        return
      }
  
    if (! /^[A-Za-z0-9 .]+$/.test(MenuDescription)) 
       {
        showToast({title: "Error", description: "menu description ongeldig"})
        return
       }

    fetch(`https://api.localhost/MenuCard/${MenuItemID}?MenuItemName=${GetMenuName()}&MenuItemDescription=${GetMenuDiscription()}&Price=${GetMenuPrice()}`,
    {method: "PUT"} );
    showToast({title: "Menu item aangepast", description: "item is aangepast je wordt terug gestuurd"})
    localStorage.removeItem("MenuItemID");
    setTimeout(() => navigate("/MenuPage"), 2000)
  }

  return (
    <div>
      <Navbar/>
      <br/>
      <div class="flex justify-center">
        <For each ={Menu()}>
          {item =>
            <TextField>
              <TextFieldLabel for="MenuDiscription">item naam:</TextFieldLabel>
              <TextFieldInput onInput={e => setMenuName(e.currentTarget.value)} value={GetMenuName()} type="text" id="InputMenuName" placeholder={item.name}/>

              <TextFieldLabel for="MenuDescription">item omschrijving:</TextFieldLabel>
              <TextFieldInput  onInput={e => setMenuDiscription(e.currentTarget.value)} value={GetMenuDiscription()} type="text" id="InputMenuDescription" placeholder={item.description} />
              
              <TextFieldLabel for="MenuPrice">item prijs:</TextFieldLabel>
              <TextFieldInput  onInput={e => setMenuPrice(e.currentTarget.value)} value={GetMenuPrice()} type="text" id="InputMenuPrice" placeholder={item.price.toString()} />
            
            </TextField>
          }              
        </For>
      </div>
      <div class="flex justify-center">
        <Button class="send-button" onclick={() => UpdateMenuItem()}>Aanpassen</Button>
      </div>
      <Toaster/>
    </div>
  );
};

export default UpdateMenuItemPage;
