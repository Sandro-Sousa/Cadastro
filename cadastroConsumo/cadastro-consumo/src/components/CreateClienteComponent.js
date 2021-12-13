import React from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

class CreateClienteComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = { nome: '', cpf: '' };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleChange(event) {
    const state = this.state;
    state[event.target.nome] = event.target.value;
    this.setState(state);
  }
  handleSubmit(event) {
    event.preventDefault();

    let formData = new FormData();
    formData.append('nome', this.state.name);
    formData.append('cpf', this.state.cpf);

    axios({
      method: 'post',
      url: 'https://localhost:5001/api/cadastro/v1/InsertCliente',
      data: formData,
      config: { headers: { 'Content-Type': 'multipart/form-data' } },
    })
      .then(function (response) {
        //handle success
        console.log(response);
        alert('Cliente Criado com Sucesso');
      })
      .catch(function (response) {
        //handle error
        console.log(response);
      });
  }
  render() {
    return (
      <div className="container">
        <h1 className="page-header text-center">Adicionar Cadastro</h1>
        <Link to="/" className="btn btn-primary btn-xs">
          Home
        </Link>
        <div className="col-md-12">
          <div className="panel panel-primary">
            <div className="panel-body">
              <form onSubmit={this.handleSubmit}>
                <label>Nome</label>
                <input
                  type="text"
                  name="nome"
                  className="form-control"
                  defaultValue={this.state.nome}
                  onChange={this.handleChange}
                />

                <label>Cpf</label>
                <input
                  type="text"
                  name="cpf"
                  className="form-control"
                  defaultValue={this.state.cpf}
                  onChange={this.handleChange}
                />
                <br />
                <input
                  type="submit"
                  className="btn btn-primary btn-block"
                  value="Criar Cadastro"
                />
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default CreateClienteComponent;
