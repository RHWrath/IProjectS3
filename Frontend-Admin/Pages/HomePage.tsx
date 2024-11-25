import type { Component } from 'solid-js';
import Navbar from './Navbar';

const HomePage: Component = () => {
  return (
    <div>
        <Navbar/>
        <p>
          Welcome manager
        </p>
    </div>
  );
};

export default HomePage;
