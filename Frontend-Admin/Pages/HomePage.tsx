import type { Component } from 'solid-js';
import Navbar from './Navbar';

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
