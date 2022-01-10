import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

import Home from './pages/Home/index';
import IncluirCliente from './pages/IncluirCliente/index';
import EditarCliente from './pages/EditarCliente/index';

const Routes = () => {
    return (
        <Router>
            <Switch>
            <Route path="/" exact component={Home}  />
            <Route path="/IncluirCliente" component={IncluirCliente} />
            <Route path="/EditarCliente/:id"  component={EditarCliente} />
            </Switch>
        </Router>
    );
}

export default Routes;
