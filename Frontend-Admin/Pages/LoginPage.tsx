//#region Imports
import {createSignal,createEffect, createResource, type Component, For } from 'solid-js';
import Navbar from './Navbar';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { showToast, Toaster } from "~/components/ui/toast"
import { Item } from '@kobalte/core/navigation-menu';
import { Toast } from '@kobalte/core/*';
import { Button, buttonVariants } from "~/components/ui/button"
//#endregion

interface Cat{
  catID: number;
  catDescription: string;
  catIMG: string;
  catName: string;
}


const LoginPage: Component = () => {


  const [GetUsername, SetUsername] = createSignal("")
  const [GetPassword, SetPassword] = createSignal("")
  
  const navigate = useNavigate();
  

  function Login() {
    fetch(`https://api.localhost/Login?username=${GetUsername()}&password=${GetPassword()}`,
    {method: "POST"} ).then((response)=>{
        console.log(response.status)
        if (response.ok) 
        {
            sessionStorage.setItem("LoginSuccesfull", "true");
            showToast({title: "Succes:", description: "welcome"})            
            setTimeout(() => navigate("/Homepage"), 400)
        } else 
        {            
        showToast({title: "ERROR:", description: response.status})
        }
    });

  }

  return (
    <div>
      <div class="flex justify-center">        
            <TextField>
              <TextFieldLabel for="CatName">Username:</TextFieldLabel>
              <TextFieldInput onInput={e => SetUsername(e.currentTarget.value)} value={GetUsername()} type="text" id="InputCatName" placeholder="Username"/>

              <TextFieldLabel for="CatDescription">Password:</TextFieldLabel>
              <TextFieldInput  onInput={e => SetPassword(e.currentTarget.value)} value={GetPassword()} type="password" id="InputCatDescription" placeholder="Password" />
            </TextField>
      </div>
      <div class="flex justify-center">
        <Button class="send-button" onclick={() => Login()}>Login</Button>
        <Toaster/>
      </div>
    </div>
  );
};

export default LoginPage;
