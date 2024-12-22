import {createSignal, type Component } from 'solid-js'
import Navbar from './Navbar';
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { useNavigate } from "@solidjs/router"
import { Button, buttonVariants } from "~/components/ui/button"


const CreateMenuItemPage: Component = () => {

  const [GetItemName, setItemName] = createSignal("")
  const [GetItemDiscription, setItemDiscription] = createSignal("")
  const [GetItemPrice, setItemPrice] = createSignal("")

  const navigate = useNavigate();

  function createMenuItem() {
    fetch(`https://api.localhost/MenuCard?MenuItemName=${GetItemName()}&MenuItemDescription=${GetItemDiscription()}&Price=${GetItemPrice()}`, {method: "POST"});
    setTimeout(() => navigate("/CatListPage"), 2000)
  }


    return (
      <div>
          <Navbar/>
          <br/>
          <div class="flex justify-left">
                  <TextField>
                    <TextFieldLabel for="menuItemName">Menu item naam:</TextFieldLabel>
                    <TextFieldInput onInput={e => setItemName(e.currentTarget.value)} value={GetItemName()} type="text" id="inputMenuItemName" placeholder="" />

                    <TextFieldLabel for="menuItemDescription">Menu iten omschrijving:</TextFieldLabel>
                    <TextFieldInput  onInput={e => setItemDiscription(e.currentTarget.value)} value={GetItemDiscription()} type="text" id="InputMenuItemDescription" placeholder="" />

                    <TextFieldLabel for="menuItemPrice">Menu Item prijs:</TextFieldLabel>
                    <TextFieldInput  onInput={e => setItemPrice(e.currentTarget.value)} value={GetItemPrice()} type="text" id="InputMenuItemPrice" placeholder="" />
                  </TextField>
          </div>
          <div>
            <Button class="send-button" onclick={() => createMenuItem()}>toevoegen</Button>
          </div>
          
      </div>
    );
  };
  
  export default CreateMenuItemPage;