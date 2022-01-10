import React, { useState, useEffect } from "react";
import axios from "axios";
import { useHistory, useParams, Link } from "react-router-dom";
import { useForm, SubmitHandler } from "react-hook-form";

interface IParam {
  id:string;
}

type Inputs = {
  nome: string,
  cpf: string,
};


const EditarCliente: React.FC = () => {

  const { register, handleSubmit, watch, formState: { errors } } = useForm<Inputs>();

  let history = useHistory();
  const { id } = useParams<IParam>();
  const [cliente, setCliente] = useState({
    idCliente: "",
    nome: "",
    cpf: "",
  });

  const { idCliente, nome, cpf} = cliente;
  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCliente({ ...cliente, [e.target.name]: e.target.value });
  };

  useEffect(() => {
    clienteGetById();
  }, []);

  const onSubmit = async () => {
    await axios.put(`https://localhost:5001/api/cadastro/v1/updatecliente/${id}`, cliente);
    history.push("/");
  };

  const clienteGetById = async () => {
    const result = await axios.get(`https://localhost:5001/api/cadastro/v1/clientegetbyid/${id}`);
    setCliente(result.data);
  };
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
              name="idCliente"
              value={idCliente}
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
          <button className="btn btn-warning btn-block">Atualizar</button>
        </form>
      </div>
    </div>
  );
}

export default EditarCliente;