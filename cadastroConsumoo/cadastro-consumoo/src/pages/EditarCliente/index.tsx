import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useHistory, useParams, Link } from 'react-router-dom';
import { useForm, SubmitHandler } from 'react-hook-form';
import 'bootstrap/dist/css/bootstrap.min.css';

interface IParam {
  id: string;
}

type Inputs = {
  nome: string;
  cpf: string;
  ddd: string;
  numero: string;
};

interface ITelefone {
  telefoneId: number;
  clienteId: number;
  ddd: string;
  numero: string;
}

const EditarCliente: React.FC = () => {
  const baseUrlTelefoneDelete =
    'https://localhost:5001/api/cadastro/v1/telefonedelete';

  const [data, setData] = useState<ITelefone[]>([]);

  const [telefoneSelecionado, setTelefoneSelecionado] = useState({
    telefoneId: '',
    clienteId: '',
    ddd: '',
    numero: '',
  });

  const resquestDelete = async (id: any) => {
    await axios
      .delete(baseUrlTelefoneDelete + '/' + id)
      .then((response) => {
        setData(
          data.filter((telefone) => telefone.telefoneId !== response.data),
        );
        telefonesGetAllByIdCliente();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const [cliente, setCliente] = useState({
    clienteId: '',
    nome: '',
    cpf: '',
  });

  const [telefones, setTelefones] = useState([
    {
      clienteId: '',
      ddd: '',
      numero: '',
    },
  ]);

  const telefonesGetAllByIdCliente = async () => {
    await axios
      .get(
        `https://localhost:5001/api/cadastro/v1/telefonesGetAllByIdCliente/${id}`,
      )
      .then((response) => {
        setData(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<Inputs>();

  let history = useHistory();
  const { id } = useParams<IParam>();

  const { clienteId, nome, cpf } = cliente;

  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCliente({ ...cliente, [e.target.name]: e.target.value });
  };

  const onInputChangeTelefone = (
    index: number,
    e: React.ChangeEvent<HTMLInputElement>,
  ) => {
    const values: Array<any> = [...telefones];
    values[index][e.target.name] = e.target.value;
    setTelefones(values);
  };

  const onSubmit = async () => {
    await axios
      .put(
        `https://localhost:5001/api/cadastro/v1/updatecliente/${id}`,
        cliente,
      )
      .then((response) => {
        console.log(JSON.stringify(cliente));
      })
      .catch((response) => {
        console.log(JSON.stringify(cliente));
      });
    await axios
      .post(
        'https://localhost:5001/api/cadastro/v1/cadastrotelefone',
        telefones,
      )
      .then((response) => {
        console.log(JSON.stringify(telefones));
      })
      .catch((response) => {
        console.log(JSON.stringify(telefones));
      });
    telefonesGetAllByIdCliente();
  };

  const clienteGetById = async () => {
    const result = await axios.get(
      `https://localhost:5001/api/cadastro/v1/clientegetbyid/${id}`,
    );
    setCliente(result.data);
  };

  const handleTelefoneAdd = () => {
    setTelefones([...telefones, { clienteId: '', ddd: '', numero: '' }]);
  };

  const handleTelefoneRemove = (index: any) => {
    const list = [...telefones];
    list.splice(index, 1);
    setTelefones(list);
  };

  useEffect(() => {
    clienteGetById();
    telefonesGetAllByIdCliente();
  }, []);

  return (
    <div className="container">
      <div className="w-75 mx-auto shadow p-5">
        <h2 className="text-center mb-4">Editar Cliente</h2>
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              readOnly
              name="clienteId"
              value={clienteId}
              onChange={(e) => onInputChange(e)}
            />
          </div>
          <br />
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              {...register('nome', { required: true, maxLength: 50 })}
              placeholder="Entre com o Nome do Cliente"
              name="nome"
              value={nome}
              onChange={(e) => onInputChange(e)}
            />
            {errors.nome && <span>Nome é requerido</span>}
          </div>
          <br />
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              {...register('cpf', { required: true, maxLength: 11 })}
              placeholder="Insera seu Cpf"
              name="cpf"
              value={cpf}
              onChange={(e) => onInputChange(e)}
            />
            {errors.cpf && <span>Cpf é requerido</span>}
          </div>
          <br />
          <h4 className="text-center mb-4">Telefone</h4>
          {telefones.map((telefoneService, index) => (
            <div key={index}>
              <div className="form-group">
                <br />
                <input
                  type="hidden"
                  readOnly
                  className="form-control form-control-lg"
                  name="clienteId"
                  value={(telefoneService.clienteId = id)}
                  onChange={(e) => onInputChangeTelefone(index, e)}
                />
                <br />
                <input
                  type="text"
                  className="form-control form-control-lg"
                  {...register('ddd', {
                    required: true,
                    minLength: 2,
                    maxLength: 3,
                  })}
                  placeholder="Insira seu DDD"
                  name="ddd"
                  value={telefoneService.ddd}
                  onChange={(e) => onInputChangeTelefone(index, e)}
                />
                {errors.ddd && <span>DDD é Requerido</span>}
                <br />
                <input
                  type="text"
                  className="form-control form-control-lg"
                  {...register('numero', {
                    required: true,
                    minLength: 9,
                    maxLength: 9,
                  })}
                  placeholder="Insira seu Telefone"
                  name="numero"
                  value={telefoneService.numero}
                  onChange={(e) => onInputChangeTelefone(index, e)}
                />
                {errors.numero && <span>Numero é Requerido</span>}
              </div>
              <br />
              {telefones.length - 1 === index && telefones.length && (
                <button
                  type="button"
                  onClick={handleTelefoneAdd}
                  className="btn btn-success"
                >
                  <span>+</span>
                </button>
              )}{' '}
              {telefones.length !== 1 && (
                <button
                  type="button"
                  onClick={() => handleTelefoneRemove(index)}
                  className="btn btn-success"
                >
                  <span>-</span>
                </button>
              )}
            </div>
          ))}
          <br />
          <button className="btn btn-warning btn-block">Atualizar</button>{' '}
          <Link to="/">
            <button className="btn btn-success ml-1">Voltar</button>
          </Link>
        </form>
        <br />
        <h4 className="text-center mb-4">Lista de Telefones:</h4>
        <table className="table table-bordered table-striped">
          <tbody>
            {data.map((telefone) => (
              <tr key={telefone.telefoneId}>
                <td>{telefone.telefoneId}</td>
                <td>{telefone.clienteId}</td>
                <td>{telefone.ddd}</td>
                <td>{telefone.numero}</td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => resquestDelete(telefone.telefoneId)}
                  >
                    Excluir
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default EditarCliente;
