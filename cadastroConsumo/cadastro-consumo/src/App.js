import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import ClienteComponent from './components/ClienteComponent';
import UpdateClienteComponent from './components/UpdateClienteComponent';
import CreateClienteComponent from './components/CreateClienteComponent';

class App extends React.Component {
  render() {
    return (
      <Router>
        <div>
          <Route exact path="/" component={ClienteComponent} />
          <Route
            path="/UpdateClienteComponent/:id"
            component={UpdateClienteComponent}
          />
          <Route
            path="/CreateClienteComponent"
            component={CreateClienteComponent}
          />
        </div>
      </Router>
    );
  }
}
export default App;
