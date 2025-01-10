//#region Imports
import {createSignal,createEffect, createResource, type Component, For } from 'solid-js';
import Navbar from './Navbar';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { showToast, Toaster } from "~/components/ui/toast"
import { Item } from '@kobalte/core/navigation-menu';
import { Button, buttonVariants } from "~/components/ui/button"
//#endregion

interface Cat{
  catID: number;
  catDescription: string;
  catIMG: string;
  catName: string;
}


const UpdateCatPage: Component = () => {


  const [GetCatName, setCatName] = createSignal("")
  const [GetCatDiscription, setCatDiscription] = createSignal("")
  
  const navigate = useNavigate();
  const CatID = Number(localStorage.getItem("CatID"))
  let LastRequestTime =0;
  
  const [cat] = createResource<Cat[] | undefined>(() => fetch(`https://api.localhost/Cats/${CatID}`).then(body=>body.json()))

  function updateCat() {
    console.log("kat naam",GetCatName())
    console.log("kat description",GetCatName())
    console.log("kat ID",CatID)

    const CatName = GetCatName();
    const CatDescription = GetCatDiscription();
    const now = Date.now();

    if (now - LastRequestTime < 1000) 
    {
      console.warn("Rate limit exceeded");
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

    fetch(`https://api.localhost/Cats/${CatID}?CatName=${GetCatName()}&CatDescription=${GetCatDiscription()}`,
    {method: "PUT"} );
    showToast({title: "kat aangepast", description: "kat is aangepast je wordt terug gestuurd"})
    localStorage.removeItem("CatID");
    setTimeout(() => navigate("/CatListPage"), 400)
  }

  return (
    <div>
      <Navbar/>
      <br/>
      <div class="flex justify-center">
        <For each ={cat()}>
          {item =>
            <TextField>
              <TextFieldLabel for="CatName">Kat naam:</TextFieldLabel>
              <TextFieldInput onInput={e => setCatName(e.currentTarget.value)} value={GetCatName()} type="text" id="InputCatName" placeholder={item.catName}/>

              <TextFieldLabel for="CatDescription">Kat omschrijving:</TextFieldLabel>
              <TextFieldInput  onInput={e => setCatDiscription(e.currentTarget.value)} value={GetCatDiscription()} type="text" id="InputCatDescription" placeholder={item.catDescription} />
            </TextField>
          }              
        </For>
      </div>
      <div class="flex justify-center">
        <Button class="send-button" onclick={() => updateCat()}>Aanpassen</Button>
      </div>
      <Toaster/>
    </div>
  );
};

export default UpdateCatPage;
