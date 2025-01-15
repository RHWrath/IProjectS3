//#region Imports
import {createSignal,type Component } from 'solid-js';
import "../css/CategoryCardCss.css";
import { useNavigate } from "@solidjs/router";
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { showToast, Toaster } from "~/components/ui/toast"
import { Button } from "~/components/ui/button"
//#endregion

const LoginPage: Component = () => {


  const [GetUsername, SetUsername] = createSignal("")
  const [GetPassword, SetPassword] = createSignal("")
  
  let LastRequestTime =0;  
  
  const navigate = useNavigate();
  

  function Login() {
    const now = Date.now();

    if (now - LastRequestTime < 10) 
    {
      console.warn("Rate limit exceeded");
      return;
    }
    LastRequestTime = now;

    fetch(`https://api.localhost/Login?username=${GetUsername()}&password=${GetPassword()}`,
    {method: "POST"} ).then((response)=>{
        console.log(response.status)
        if (response.ok) 
        {
            sessionStorage.LoggedIn = true;
            sessionStorage.setItem("LoggedIn", "true");
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
              <TextFieldInput onInput={e => SetUsername(e.currentTarget.value)} value={GetUsername()} type="text" id="InputCatName" placeholder="Username" class="UsernameInput"/>

              <TextFieldLabel for="CatDescription">Password:</TextFieldLabel>
              <TextFieldInput  onInput={e => SetPassword(e.currentTarget.value)} value={GetPassword()} type="password" id="InputCatDescription" placeholder="Password" class="PasswordInput" />
            </TextField>
      </div>
      <div class="flex justify-center">
        <Button class="send-button LoginSubmit" onclick={() => Login()}>Login</Button>
        <Toaster class="LoginToaster"/>
      </div>
    </div>
  );
};

export default LoginPage;
