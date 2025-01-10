//#region Imports
import {createSignal, type Component } from 'solid-js';
import Navbar from './Navbar';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { showToast, Toaster } from "~/components/ui/toast"
import { Button, buttonVariants } from "~/components/ui/button"
//#endregion


const CreateCatPage: Component = () => {

  const [GetCatName, setCatName] = createSignal("")
  const [GetCatDiscription, setCatDiscription] = createSignal("")  
  let LastRequestTime =0;  
  
  const navigate = useNavigate();

  function createCat() {
    const now = Date.now();
    const CatName = GetCatName();
    const CatDescription = GetCatDiscription();

    if (now - LastRequestTime < 1000) 
    {
      console.warn("Rate limit exceeded");
      showToast({title: "Error", description: "beetje rustig aan je hebt al de request aangemaakt"})
      return;
    }
    LastRequestTime = now;

    if (! /^[A-Za-z0-9 .]+$/.test(CatName)) 
      {
        showToast({title: "Error", description: "kat naam ongeldig"})
        return
      }
  
      if (! /^[A-Za-z0-9 .]+$/.test(CatDescription)) 
      {
        showToast({title: "Error", description: "kat description ongeldig"})
        return
      }

    fetch(`https://api.localhost/Cats?CatName=${GetCatName()}&CatDescription=${GetCatDiscription()}`, {method: "POST"});
    showToast({title: "kat gemaakt", description: "kat is aangemaakt je wordt terug gestuurd"})
    setTimeout(() => navigate("/CatListPage"), 2000)
  }

  return (
    <div>
      <Navbar/>
      <br/>
      <div class="flex justify-center">
              <TextField>
                <TextFieldLabel for="CatName">Kat naam:</TextFieldLabel>
                <TextFieldInput onInput={e => setCatName(e.currentTarget.value)} value={GetCatName()} type="text" id="InputCatName" placeholder="Kat Naam" class="CatnameInput"/>

                <TextFieldLabel for="CatDescription">Kat omschrijving:</TextFieldLabel>
                <TextFieldInput  onInput={e => setCatDiscription(e.currentTarget.value)} value={GetCatDiscription()} type="text" id="InputCatDescription" placeholder="Kat omschrijving:" class="CatdescriptionInput" />
              </TextField>
      </div>
      <div class="flex justify-center">
        <Button class="send-button KatCreateButton" onclick={() => createCat()}>toevoegen</Button>
      </div>
      <Toaster/>
    </div>
  );
};

export default CreateCatPage;
