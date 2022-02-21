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

interface IEndereco {
  EnderecoId: number;
  logradouro: string;
  bairro: string;
  cidade: string;
  uf: string;
  clienteId: number;
}

interface IEmail {
  emailId: number;
  _Email: string;
  clienteId: number;
}

const EditarCliente: React.FC = () => {
  const baseUrlTelefoneDelete =
    'https://localhost:5001/api/cadastro/v1/telefonedelete';

  const baseUrlEnderecoDelete =
    'https://localhost:5001/api/cadastro/v1/enderecoDelete';

  const baseUrlEmailDelete =
    'https://localhost:5001/api/cadastro/v1/emaildelete';

  const [data, setData] = useState<ITelefone[]>([]);
  const [enderecoData, setEnderecoData] = useState<IEndereco[]>([]);
  const [emailData, setEmailData] = useState<IEmail[]>([]);

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

  const [enderecos, setEnderecos] = useState([
    {
      EnderecoId: '',
      logradouro: '',
      bairro: '',
      cidade: '',
      uf: '',
      clienteId: '',
    },
  ]);

  const [emails, setEmails] = useState([
    {
      _Email: '',
      clienteId: '',
    },
  ]);

  const clienteGetById = async () => {
    const result = await axios.get(
      `https://localhost:5001/api/cadastro/v1/clientegetbyid/${id}`,
    );
    setCliente(result.data);
  };

  const resquestDeleteTelefoneTelefone = async (id: any) => {
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

  const resquestDeleteEndereco = async (id: any) => {
    await axios
      .delete(baseUrlEnderecoDelete + '/' + id)
      .then((response) => {
        setEnderecoData(
          enderecoData.filter(
            (endereco) => endereco.EnderecoId !== response.data,
          ),
        );
        enderecosGetAllByIdCliente();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const enderecosGetAllByIdCliente = async () => {
    await axios
      .get(
        `https://localhost:5001/api/cadastro/v1/enderecosGetAllByIdCliente/${id}`,
      )
      .then((response) => {
        setEnderecoData(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const resquestDeleteEmail = async (id: any) => {
    await axios
      .delete(baseUrlEmailDelete + '/' + id)
      .then((response) => {
        console.log(JSON.stringify(response));
        setEmailData(
          emailData.filter((email) => email.emailId !== response.data),
        );
        emailsGetAllByIdCliente();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const emailsGetAllByIdCliente = async () => {
    await axios
      .get(
        `https://localhost:5001/api/cadastro/v1/emailsGetAllByIdCliente/${id}`,
      )
      .then((response) => {
        setEmailData(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
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
    await axios
      .post(
        'https://localhost:5001/api/cadastro/v1/cadastroEndereco',
        enderecos,
      )
      .then((response) => {
        console.log(JSON.stringify(enderecos));
      })
      .catch((response) => {
        console.log(JSON.stringify(enderecos));
      });
    enderecosGetAllByIdCliente();
    await axios
      .post('https://localhost:5001/api/cadastro/v1/cadastroemail', emails)
      .then((response) => {
        console.log(JSON.stringify(emails));
      })
      .catch((response) => {
        console.log(JSON.stringify(emails));
      });
    emailsGetAllByIdCliente();
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

  const onInputChangeEndereco = (
    index: number,
    e: React.ChangeEvent<HTMLInputElement>,
  ) => {
    const values: Array<any> = [...enderecos];
    values[index][e.target.name] = e.target.value;
    setEnderecos(values);
  };

  const onInputChangeEmail = (
    index: number,
    e: React.ChangeEvent<HTMLInputElement>,
  ) => {
    const values: Array<any> = [...emails];
    values[index][e.target.name] = e.target.value;
    setEmails(values);
  };

  const handleTelefoneAdd = () => {
    setTelefones([...telefones, { clienteId: '', ddd: '', numero: '' }]);
  };

  const handleTelefoneRemove = (index: any) => {
    const list = [...telefones];
    list.splice(index, 1);
    setTelefones(list);
  };

  const handleEnderecoAdd = () => {
    setEnderecos([
      ...enderecos,
      {
        EnderecoId: '',
        logradouro: '',
        bairro: '',
        cidade: '',
        uf: '',
        clienteId: '',
      },
    ]);
  };

  const handleEnderecoRemove = (index: any) => {
    const list = [...enderecos];
    list.splice(index, 1);
    setEnderecos(list);
  };

  const handleEmailAdd = () => {
    setEmails([
      ...emails,
      {
        _Email: '',
        clienteId: '',
      },
    ]);
  };

  const handleEmailRemove = (index: any) => {
    const list = [...emails];
    list.splice(index, 1);
    setEmails(list);
  };

  useEffect(() => {
    clienteGetById();
    telefonesGetAllByIdCliente();
    enderecosGetAllByIdCliente();
    emailsGetAllByIdCliente();
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
          <h4 className="text-center mb-4">Endereco</h4>
          {enderecos.map((enderecosService, index) => (
            <div key={index}>
              <div className="form-group">
                <br />
                <input
                  type="text"
                  className="form-control form-control-lg"
                  placeholder="Insira seu logradouro"
                  name="logradouro"
                  value={enderecosService.logradouro}
                  onChange={(e) => onInputChangeEndereco(index, e)}
                />
                <br />
                <input
                  type="text"
                  className="form-control form-control-lg"
                  placeholder="Insira seu Bairro"
                  name="bairro"
                  value={enderecosService.bairro}
                  onChange={(e) => onInputChangeEndereco(index, e)}
                />
                <br />
                <input
                  type="text"
                  className="form-control form-control-lg"
                  placeholder="Insira sua Cidade"
                  name="cidade"
                  value={enderecosService.cidade}
                  onChange={(e) => onInputChangeEndereco(index, e)}
                />
                <br />
                <input
                  type="text"
                  className="form-control form-control-lg"
                  placeholder="Insira seu UF"
                  name="uf"
                  value={enderecosService.uf}
                  onChange={(e) => onInputChangeEndereco(index, e)}
                />
                <br />
                <input
                  type="hidden"
                  readOnly
                  className="form-control form-control-lg"
                  name="clienteId"
                  value={(enderecosService.clienteId = id)}
                  onChange={(e) => onInputChangeEndereco(index, e)}
                />
              </div>
              {enderecos.length - 1 === index && enderecos.length && (
                <button
                  type="button"
                  onClick={handleEnderecoAdd}
                  className="btn btn-success"
                >
                  <span>+</span>
                </button>
              )}{' '}
              {enderecos.length !== 1 && (
                <button
                  type="button"
                  onClick={() => handleEnderecoRemove(index)}
                  className="btn btn-success"
                >
                  <span>-</span>
                </button>
              )}
            </div>
          ))}
          <br />
          <h4 className="text-center mb-4">Email</h4>
          {emails.map((emailsService, index) => (
            <div key={index}>
              <div className="form-group">
                <br />
                <input
                  type="hidden"
                  readOnly
                  className="form-control form-control-lg"
                  name="clienteId"
                  value={(emailsService.clienteId = id)}
                  onChange={(e) => onInputChangeEmail(index, e)}
                />
                <br />
                <input
                  type="text"
                  className="form-control form-control-lg"
                  placeholder="Insira seu Email"
                  name="_Email"
                  value={emailsService._Email}
                  onChange={(e) => onInputChangeEmail(index, e)}
                />
                <br />
              </div>
              <br />
              {emails.length - 1 === index && emails.length && (
                <button
                  type="button"
                  onClick={handleEmailAdd}
                  className="btn btn-success"
                >
                  <span>+</span>
                </button>
              )}{' '}
              {emails.length !== 1 && (
                <button
                  type="button"
                  onClick={() => handleEmailRemove(index)}
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
        <h4 className="text-center mb-4">Lista:</h4>
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
                    onClick={() =>
                      resquestDeleteTelefoneTelefone(telefone.telefoneId)
                    }
                  >
                    Excluir
                  </button>
                </td>
              </tr>
            ))}
            {enderecoData.map((endereco) => (
              <tr key={endereco.EnderecoId}>
                <td>{endereco.EnderecoId}</td>
                <td>{endereco.logradouro}</td>
                <td>{endereco.bairro}</td>
                <td>{endereco.cidade}</td>
                <td>{endereco.uf}</td>
                <td>{endereco.clienteId}</td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => resquestDeleteEndereco(endereco.EnderecoId)}
                  >
                    Excluir
                  </button>
                </td>
              </tr>
            ))}
            {emailData.map((email) => (
              <tr key={email.emailId}>
                <td>{email.emailId}</td>
                <td>{email._Email}</td>
                <td>{email.clienteId}</td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => resquestDeleteEmail(email.emailId)}
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
