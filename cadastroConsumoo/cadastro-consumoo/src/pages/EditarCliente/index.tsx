import React, { useState, useEffect } from "react";
import axios from "axios";
import { useHistory, useParams, Link } from "react-router-dom";
import { useForm, SubmitHandler } from "react-hook-form";
import 'bootstrap/dist/css/bootstrap.min.css';

interface IParam {
  id:string;
}

type Inputs = {
  nome: string,
  cpf: string,
};

const EditarCliente: React.FC = () => {

  const [cliente, setCliente] = useState({
    clienteId: "",
    nome: "",
    cpf: "",
  });

  const [telefones, setTelefones] = useState([{
    clienteId: "",
    ddd: "",
    numero: "",
  }]);

  const { register, handleSubmit, watch, formState: { errors } } = useForm<Inputs>();

  let history = useHistory();
  const { id } = useParams<IParam>();
  const { clienteId, nome, cpf} = cliente;

  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCliente({ ...cliente, [e.target.name]: e.target.value });
  };

  const onInputChangeTelefone = (index:number, e: React.ChangeEvent<HTMLInputElement>) => {
    const values:Array<any> = [...telefones];
    values[index][e.target.name] = e.target.value;
    setTelefones(values);
  };

  const onSubmit = async () => {
    await axios.put(`https://localhost:5001/api/cadastro/v1/updatecliente/${id}`, cliente)
    .then((response) => {
      console.log(JSON.stringify(cliente))
    })
    .catch((response) => {
      console.log(JSON.stringify(cliente))
    });
    history.push("/");

    await axios.post("https://localhost:5001/api/cadastro/v1/cadastrotelefone", telefones)
    .then((response) => {
      console.log(JSON.stringify(telefones))
    })
    .catch((response) => {
      console.log(JSON.stringify(telefones))
    });

  };


  const clienteGetById = async () => {
    const result = await axios.get(`https://localhost:5001/api/cadastro/v1/clientegetbyid/${id}`);
    setCliente(result.data);
  };

  const handleTelefoneAdd = () => {
    setTelefones([...telefones, { clienteId: "", ddd: "", numero: "",
     }]);
  };

  const handleTelefoneRemove = (index:any) => {
    const list = [...telefones];
    list.splice(index, 1);
    setTelefones(list);
  };

  useEffect(() => {
    clienteGetById();
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
              onChange={e => onInputChange(e)}
            />
          </div>
          <br />
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              {...register("nome", {required:true, maxLength: 50})}
              placeholder="Entre com o Nome do Cliente"
              name="nome"
              value={nome}
              onChange={e => onInputChange(e)}
            />
            {errors.nome && <span>Nome é requerido</span>}
          </div>
          <br />
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              {...register("cpf", {required:true, maxLength: 11})}
              placeholder="Insera seu Cpf"
              name="cpf"
              value={cpf}
              onChange={e => onInputChange(e)}
            />
            {errors.cpf && <span>Cpf é requerido</span>}
          </div>
          <br />
          <h4 className="text-center mb-4">Telefone</h4>
        {telefones.map((telefoneService, index) =>(
            <div key={index}>
            <div className="form-group">
            <br />
            <input 
                  type="text"
                  readOnly
                  className="form-control form-control-lg"
                  name="clienteId"
                  value={telefoneService.clienteId = id}
                  onChange={(e) => onInputChangeTelefone(index,e)}
                   />
             <br />
             <input
              type="text"
              className="form-control form-control-lg"
              placeholder="Insira seu DDD"
              name="ddd"
              value={telefoneService.ddd}
              onChange={e => onInputChangeTelefone(index,e)}
              />
              <br />
              <input
              type="text"
              className="form-control form-control-lg"
              placeholder="Insira seu Telefone"
              name="numero"
              value={telefoneService.numero}
              onChange={e => onInputChangeTelefone(index,e)}
              />
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
          <Link to='/'>
        <button
          className="btn btn-success ml-1">
           Voltar
        </button>
        </Link>
        </form>
        <br />
      </div>
    </div>
  );
}

export default EditarCliente;