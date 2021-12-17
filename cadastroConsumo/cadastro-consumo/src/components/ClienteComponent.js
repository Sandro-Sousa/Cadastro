import React, { useState, useEffect } from 'react';
import $ from 'jquery';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

function ClienteComponent() {
  const baseUrl = 'https://localhost:5001/api/cadastro/v1/getall';
  const baseUrlEdit = 'https://localhost:5001/api/cadastro/v1/updatecliente';
  const baseUrlDelete = 'https://localhost:5001/api/cadastro/v1/clientedelete';

  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  const [data, setData] = useState([]);

  // evitar loop Infinito do UseEffect
  const [updateData, setUpdateData] = useState(true);

  const [cadastroSelecionado, setCadastroSelecionado] = useState({
    idCliente: '',
    nome: '',
    cpf: '',
  });

  const selecionarCliente = (cliente, opcao) => {
    setCadastroSelecionado(cliente);
    opcao === 'Editar' ? abrirFecharModalEditar() : abrirFecharModalExcluir();
  };

  const abrirFecharModalIncluir = () => {
    setModalIncluir(!modalIncluir);
  };

  const abrirFecharModalEditar = () => {
    setModalEditar(!modalEditar);
  };

  const abrirFecharModalExcluir = () => {
    setModalExcluir(!modalExcluir);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCadastroSelecionado({
      ...cadastroSelecionado,
      [name]: value,
    });
  };
  const clienteGet = async () => {
    await axios
      .get(baseUrl)
      .then((response) => {
        setData(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const clientePost = async () => {
    delete cadastroSelecionado.idCliente;
    await axios
      .post(
        'https://localhost:5001/api/cadastro/v1/InsertCliente',
        cadastroSelecionado,
      )
      .then((response) => {
        setData(data.concat(response.data));
        setUpdateData(true);
        abrirFecharModalIncluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const clientePut = async () => {
    await axios
      .put(
        baseUrlEdit + '/' + cadastroSelecionado.idCliente,
        cadastroSelecionado,
      )
      .then((response) => {
        var res = response.data;
        var aux = data;
        aux.map((cliente) => {
          if (cliente.idCliente === cadastroSelecionado.idCliente) {
            cliente.nome = res.nome;
            cliente.cpf = res.cpf;
          }
        });
        setUpdateData(true);
        abrirFecharModalEditar();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const resquestDelete = async () => {
    await axios
      .delete(baseUrlDelete + '/' + cadastroSelecionado.idCliente)
      .then((response) => {
        setData(data.filter((cliente) => cliente.idCliente !== response.data));
        setUpdateData(true);
        abrirFecharModalExcluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    if (updateData) {
      clienteGet();
      setUpdateData(false);
    }
  }, [updateData]);

  return (
    <div className="container">
      <br />
      <h3 className="text-center">Cadastro de Clientes</h3>
      <header>
        <button
          className="btn btn-success"
          onClick={() => abrirFecharModalIncluir()}
        >
          Incluir Cliente
        </button>
      </header>
      <table className="table table-bordered table-striped">
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Cpf</th>
            <th>Açoes</th>
          </tr>
        </thead>
        <tbody>
          {data.map((cliente) => (
            <tr key={cliente.idCliente}>
              <td>{cliente.idCliente}</td>
              <td>{cliente.nome}</td>
              <td>{cliente.cpf}</td>
              <td>
                <button
                  className="btn btn-primary"
                  onClick={() => selecionarCliente(cliente, 'Editar')}
                >
                  Editar
                </button>{' '}
                <button
                  className="btn btn-danger"
                  onClick={() => selecionarCliente(cliente, 'Excluir')}
                >
                  Excluir
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <Modal isOpen={modalIncluir}>
        <ModalHeader>Incluir Cliente</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Nome: </label>
            <br />
            <input
              type="text"
              className="form-control"
              name="nome"
              onChange={handleChange}
            />
            <br />
            <label>Cpf: </label>
            <br />
            <input
              type="text"
              className="form-control"
              name="cpf"
              onChange={handleChange}
            />
            <br />
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary" onClick={() => clientePost()}>
            Incluir
          </button>{' '}
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalIncluir()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar Cliente</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>ID: </label>
            <br />
            <input
              value={cadastroSelecionado && cadastroSelecionado.idCliente}
              readOnly
            />
            <br />
            <label>Nome: </label>
            <br />
            <input
              type="text"
              className="form-control"
              name="nome"
              onChange={handleChange}
              value={cadastroSelecionado && cadastroSelecionado.nome}
            />
            <br />
            <label>Cpf: </label>
            <br />
            <input
              type="text"
              className="form-control"
              name="cpf"
              onChange={handleChange}
              value={cadastroSelecionado && cadastroSelecionado.cpf}
            />
            <br />
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary" onClick={() => clientePut()}>
            Editar
          </button>{' '}
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalEditar()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalExcluir}>
        <ModalBody>
          Deseja excluir esse Cliente?
          {cadastroSelecionado && cadastroSelecionado.nome}
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-danger" onClick={() => resquestDelete()}>
            Sim
          </button>
          <button
            className="btn btn-secondary"
            onClick={() => abrirFecharModalExcluir()}
          >
            Não
          </button>
        </ModalFooter>
      </Modal>
    </div>
  );
}
export default ClienteComponent;
