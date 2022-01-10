import React, { useState } from "react";
import axios from 'axios'
import { useHistory} from "react-router-dom";
import { useForm, SubmitHandler } from "react-hook-form";

type Inputs = {
  nome: string,
  cpf: string,
};

const IncluirCliente: React.FC = () => {

  const { register, handleSubmit, watch, formState: { errors } } = useForm<Inputs>();

  let history = useHistory();
  const [cliente, setCliente] = useState({
    nome: "",
    cpf: "",
  });

  const { nome, cpf} = cliente;
  const onInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCliente({ ...cliente, [e.target.name]: e.target.value });
  };

  const onSubmit = async () => {
    await axios.post("https://localhost:5001/api/cadastro/v1/InsertCliente", cliente);
    history.push("/");
  };
    return (
      <div className="container">
      <div className="w-75 mx-auto shadow p-5">
        <h2 className="text-center mb-4">Adicionar Usuario</h2>
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              {...register("nome", {required:true, maxLength: 50})}
              placeholder="Insera o Nome do Cliente"
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
              placeholder="Insira o Cpf"
              name="cpf"
              value={cpf}
              onChange={e => onInputChange(e)}
            />
            {errors.cpf && <span>Cpf é requerido</span>}
          </div>
          <br />
          <button className="btn btn-primary btn-block">Adicionar Cliente</button>
        </form>
      </div>
    </div>
    );
  }
export default IncluirCliente;