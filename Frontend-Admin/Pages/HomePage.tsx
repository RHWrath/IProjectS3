import type { Component } from 'solid-js';
import Navbar from './Navbar';
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"

const HomePage: Component = () => {
  return (
    <div>
        <Navbar/>
        <div  class="flex justify-center">
          <p>
            Welcome manager
          </p>
        </div>
        
    </div>
  );
};

export default HomePage;
