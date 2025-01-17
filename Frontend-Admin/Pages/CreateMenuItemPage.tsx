import {createSignal, type Component } from 'solid-js'
import Navbar from './Navbar';
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { useNavigate } from "@solidjs/router"
import { Button } from "~/components/ui/button"
import { showToast, Toaster } from "~/components/ui/toast"


const CreateMenuItemPage: Component = () => {

  const [GetItemName, setItemName] = createSignal("")
  const [GetItemDiscription, setItemDiscription] = createSignal("")
  const [GetItemPrice, setItemPrice] = createSignal("")   
  let LastRequestTime =0;  

  const navigate = useNavigate();

  function createMenuItem() {
    const now = Date.now();
    const MenuName = GetItemName();
    const MenuDescription = GetItemName();

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

    fetch(`http://api.localhost/MenuCard?MenuItemName=${GetItemName()}&MenuItemDescription=${GetItemDiscription()}&Price=${GetItemPrice()}`, {method: "POST"});
    setTimeout(() => navigate("/MenuPage"), 400)
  }


    return (
      <div>
          <Navbar/>
          <br/>
          <div class="flex justify-left">
                  <TextField>
                    <TextFieldLabel for="menuItemName">Menu item naam:</TextFieldLabel>
                    <TextFieldInput onInput={e => setItemName(e.currentTarget.value)} value={GetItemName()} type="text" id="inputMenuItemName" placeholder="" class="MenuitemName"/>

                    <TextFieldLabel for="menuItemDescription">Menu iten omschrijving:</TextFieldLabel>
                    <TextFieldInput  onInput={e => setItemDiscription(e.currentTarget.value)} value={GetItemDiscription()} type="text" id="InputMenuItemDescription" placeholder="" class="MenuItemDesciption"/>

                    <TextFieldLabel for="menuItemPrice">Menu Item prijs:</TextFieldLabel>
                    <TextFieldInput  onInput={e => setItemPrice(e.currentTarget.value)} value={GetItemPrice()} type="text" id="InputMenuItemPrice" placeholder="" class="MenuItemPrice"/>
                  </TextField>
          </div>
          <div>
            <Button class="send-button" onclick={() => createMenuItem()}>toevoegen</Button>
          </div>          
      <Toaster/>
      </div>
    );
  };
  
  export default CreateMenuItemPage;