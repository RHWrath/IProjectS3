import type { Component } from 'solid-js';
import Navbar from './Navbar';

const HomePage: Component = () => {
  return (
    <div>
        <Navbar/>
        <h1>Welcome to Catnap café!</h1>
          <p>
            Step into a cozy haven where the aroma of freshly brewed coffee mingles with the soothing purrs of our feline friends.
            At  Catnap café, we combine the joys of a welcoming café atmosphere with the irresistible charm of cats.
            Whether you're here to sip on your favorite latte, relax with a book, or make a new furry friend, our space is designed to bring comfort, happiness, and a touch of whiskered wonder.
            Come for the coffee, stay for the cuddles. your purr-fect escape awaits!
        </p>
    </div>
  );
};

export default HomePage;
