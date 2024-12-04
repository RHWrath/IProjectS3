//#region Imports
import { createEffect, createResource, createSignal, For, Show, type Component } from 'solid-js';
import Navbar from './Navbar';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
//#endregion

interface Cat{
  catDescription: string;
  catIMG: string;
  catName: string;
}

const CreateCatPage: Component = () => {

  const [GetCatName, setCatName] = createSignal("")
  const [GetCatDiscription, setCatDiscription] = createSignal("")
  
  const navigate = useNavigate();

  function createCat() {
    const createCatApiCall = fetch(`https://api.localhost/Cats?CatName=${GetCatName()}&CatDescription=${GetCatDiscription()}`, {method: "POST"});
    setTimeout(() => navigate("/CatListPage"), 2000)
  }

  return (
    <div>
      <Navbar/>
      <br/>
      <div class="flex justify-left">
              <TextField>
                <TextFieldLabel for="CatName">Kat naam:</TextFieldLabel>
                <TextFieldInput onInput={e => setCatName(e.currentTarget.value)} value={GetCatName()} type="text" id="InputCatName" placeholder="Kat Naam" />

                <TextFieldLabel for="CatDescription">Kat omschrijving:</TextFieldLabel>
                <TextFieldInput  onInput={e => setCatDiscription(e.currentTarget.value)} value={GetCatDiscription()} type="text" id="InputCatDescription" placeholder="Kat omschrijving:" />
              </TextField>
      </div>
      <div>
        <button class="send-button" onclick={() => createCat()}>toevoegen</button>
      </div>

    </div>
  );
};

export default CreateCatPage;
