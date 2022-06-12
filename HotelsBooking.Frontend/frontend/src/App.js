import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'; 
import {RegisterPage, LoginPage, HomePage} from "../src/components/pages";
import Header from "../src/components/Header/Header";

function App() {
  return (
    <Router>
      <div className="App">
        <Header/>
        <nav>
          
          <Switch>

            <Route exact path="/Home">
              <HomePage/>
            </Route>

            <Route exact path="/Register">
              <RegisterPage/>
            </Route>
            
            <Route exact path="/Login">
              <LoginPage/>
            </Route>
            
          </Switch>
        </nav>

      </div>
    </Router>
  );
}

export default App;
