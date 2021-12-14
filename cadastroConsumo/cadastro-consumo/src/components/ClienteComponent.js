import React from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

class ClienteComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = { clientes: [] };
    this.headers = [
      { key: 'idCliente', label: 'IdCliente' },
      { key: 'nome', label: 'Nome' },
      { key: 'cpf', label: 'Cpf' },
    ];
    this.deleteContact = this.deleteContact.bind(this);
  }
  componentDidMount() {
    const url = 'https://localhost:5001/api/cadastro/v1/getall';
    axios
      .get(url)
      .then((response) => response.data)
      .then((data) => {
        this.setState({ clientes: data });
        console.log(this.state.clientes);
      });
  }

  deleteContact(idCliente, event) {
    //alert(id)
    event.preventDefault();
    if (window.confirm('Tem certeza que deseja excluir?')) {
      axios({
        method: 'delete',
        url:
          'https://localhost:5001/api/cadastro/v1/clientedelete/' + idCliente,
      })
        .then(function (response) {
          console.log(response);
          if (response.status === 200) {
            alert('Deletado com Sucesso');
          }
        })
        .catch(function (response) {
          //handle error
          console.log(response);
        });
    }
  }

  render() {
    return (
      <div className="container">
        <h1 className="text-center">Cadastro de Clientes</h1>
        <p>
          <Link to="/CreateClienteComponent" className="btn btn-primary btn-xs">
            Adicionar
          </Link>{' '}
        </p>
        <table className="table table-bordered table-striped">
          <thead>
            <tr>
              {this.headers.map(function (h) {
                return <th key={h.key}>{h.label}</th>;
              })}
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {this.state.clientes.map(
              function (item, key) {
                return (
                  <tr key={key}>
                    <td>{item.idCliente}</td>
                    <td>{item.nome}</td>
                    <td>{item.cpf}</td>
                    <td>
                      <Link
                        to={`/UpdateClienteComponent/${item.idCliente}`}
                        className="btn btn-primary btn-xs"
                      >
                        Editar
                      </Link>

                      <Link
                        to="#"
                        onClick={this.deleteContact.bind(this, item.idCliente)}
                        className="btn btn-danger btn-xs"
                      >
                        Deletar
                      </Link>
                    </td>
                  </tr>
                );
              }.bind(this),
            )}
          </tbody>
        </table>
      </div>
    );
  }
}

export default ClienteComponent;
