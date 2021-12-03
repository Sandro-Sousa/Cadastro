import React from 'react';
import axios from 'axios';

export default class cadastroConsuming extends React.Component {
  state = {
    nome: '',
    cpf: '',
  };

  handleChange = (event) => {
    this.setState({ nome: event.target.value });
    this.setState({ cpf: event.target.value });
  };

  handleSubmit = (event) => {
    event.preventDefault();

    let dataClient = JSON.stringify({
      nome: this.state.nome,
      cpf: this.state.cpf,
    });

    const response = axios.post(
      'https://localhost:44325/api/cadastro/v1/CadastroCliente',
      dataClient,
      { headers: { 'Content-Type': 'application/json' } },
    );
  };

  render() {
    return (
      <div>
        <form onSubmit={this.handleSubmit}>
          <label>
            Nome:
            <input type="text" name="name" onChange={this.handleChange} />
          </label>
          <button type="submit">Enviar</button>
          <label>
            Cpf:
            <input type="text" name="cpf" onChange={this.handleChange} />
          </label>
        </form>
      </div>
    );
  }
}
