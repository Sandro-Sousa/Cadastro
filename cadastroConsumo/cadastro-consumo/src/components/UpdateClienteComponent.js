import React from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

class UpdateClienteComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      idCliente: '',
      nome: '',
      cpf: '',
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    axios
      .get(
        'https://localhost:5001/api/cadastro/v1/clientegetbyid/' +
          this.props.match.params.idCliente,
      )
      .then((response) => response.data)
      .then((data) => {
        console.log(data);
        this.setState({
          idCliente: data.idCliente,
          nome: data.name,
          cpf: data.cpf,
        });
      })
      .catch(function (error) {
        console.log(error);
      })
      .then(function () {});
  }

  handleChange(event) {
    const state = this.state;
    state[event.target.name] = event.target.value;
    this.setState(state);
  }

  handleSubmit(event) {
    event.preventDefault();

    let formData = new FormData();
    formData.append('nome', this.state.name);
    formData.append('cpf', this.state.email);

    axios({
      method: 'put',
      url:
        'https://localhost:5001/api/cadastro/v1/updatecliente/' +
        this.props.match.params.idCliente,
      data: formData,
      config: { headers: { 'Content-Type': 'multipart/form-data' } },
    })
      .then(function (response) {
        console.log(response);
        if (response.status === 200) {
          alert('Contact update successfully.');
        }
      })
      .catch(function (response) {
        //handle error
        console.log(response);
      });
  }

  render() {
    return (
      <div className="container">
        <h1 className="page-header text-center">Atualizar Cliente</h1>
        <Link to="/" className="btn btn-primary btn-xs">
          Home
        </Link>
        <div className="col-md-12">
          <div className="panel panel-primary">
            <div className="panel-body">
              <form onSubmit={this.handleSubmit}>
                <input
                  type="hidden"
                  name="idCliente"
                  value={this.state.idCliente}
                />
                <label>Name</label>
                <input
                  type="text"
                  name="nome"
                  className="form-control"
                  value={this.state.nome}
                  onChange={this.handleChange}
                />

                <label>Cpf</label>
                <input
                  type="text"
                  name="cpf"
                  className="form-control"
                  value={this.state.cpf}
                  onChange={this.handleChange}
                />
                <br />
                <input
                  type="submit"
                  className="btn btn-primary btn-block"
                  value="Atualizar Cliente"
                />
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default UpdateClienteComponent;
