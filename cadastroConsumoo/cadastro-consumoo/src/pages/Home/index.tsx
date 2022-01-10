import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter} from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Link} from 'react-router-dom';

interface IData {
  idCliente:number;
  nome:string;
  cpf:string;
}

const Home: React.FC = () => {

  const baseUrl = 'https://localhost:5001/api/cadastro/v1/getall';
  const baseUrlDelete = 'https://localhost:5001/api/cadastro/v1/clientedelete';

  const [data, setData] = useState<IData[]>([]);

  const [modalExcluir, setModalExcluir] = useState(false);

  const [cadastroSelecionado, setCadastroSelecionado] = useState({
    idCliente: '',
    nome: '',
    cpf: '',
  });

  const selecionarCliente = (cliente:any, opcao:any) => {
    setCadastroSelecionado(cliente);
    abrirFecharModalExcluir();
  };

  const abrirFecharModalExcluir = () => {
    setModalExcluir(!modalExcluir);
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


  const resquestDelete = async () => {
    await axios
      .delete(baseUrlDelete + '/' + cadastroSelecionado.idCliente)
      .then((response) => {
        setData(data.filter((cliente) => cliente.idCliente !== response.data));
        clienteGet();
        abrirFecharModalExcluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };


  useEffect(() => {
      clienteGet();
  }, []);

    return (
      <div className="container">
         <br />
      <h3 className="text-center">Cadastro de Clientes</h3>
      <header>
        <Link to='/IncluirCliente'>
        <button
          className="btn btn-success">
          Incluir Cliente
        </button>
        </Link>
      </header>
      <br />
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
              <Link to={{ pathname: `/EditarCliente/${cliente.idCliente}`}}>
                <button
                  className="btn btn-primary"
                  >
                  Editar
                </button>{' '}
                </Link>
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
export default Home;