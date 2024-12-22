/* @refresh reload */
import { render } from 'solid-js/web';
import { Router, Route } from "@solidjs/router";

import './index.css';
import Homepage from '../Pages/HomePage';
import Menupage from '../Pages/MenuPage';
import CatListPage from '../Pages/CatListPage';
import CreateCatPage from '../Pages/CreateCatPage';
import CreateMenuItemPage from '../Pages/CreateMenuItemPage';
import UpdateCatPage from '../Pages/UpdateCatPage';
import UpdateMenuItemPage from '../Pages/UpdateMenuItemPage';
import LoginPage from '../Pages/LoginPage';

const root = document.getElementById('root');

if (import.meta.env.DEV && !(root instanceof HTMLElement)) {
  throw new Error(
    'Root element not found. Did you forget to add it to your index.html? Or maybe the id attribute got misspelled?',
  );
}

render(
  () => (
      <Router>
          <Route path="/" component={LoginPage} />
          <Route path="/Homepage" component={Homepage} />
          <Route path="/MenuPage" component={Menupage} />
          <Route path="/CatListPage" component={CatListPage} />
          <Route path="/CreateCatPage" component={CreateCatPage} />
          <Route path="/CreateMenuItemPage" component={CreateMenuItemPage}/>
          <Route path="/UpdateCatPage" component={UpdateCatPage}/>
          <Route path="/UpdateMenuItemPage" component={UpdateMenuItemPage}/>
      </Router>
      
  ),
  document.getElementById("root")!
);
