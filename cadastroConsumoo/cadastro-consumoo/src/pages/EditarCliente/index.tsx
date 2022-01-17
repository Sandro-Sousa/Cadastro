import React, { useState, useEffect } from "react";
import axios from "axios";
import { useHistory, useParams, Link } from "react-router-dom";
import { useForm, SubmitHandler } from "react-hook-form";
import { array } from "yup";
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import { event } from "jquery";

interface IParam {
  id:string;
}

type Inputs = {
  nome: string,
  cpf: string,
};

const EditarCliente: React.FC = () => {

  const [telefone, setTelefone] = useState([{
    numero: "",
    idCliente: "",
  }]);

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


  const onInputChangeTelefone = (index:number, e: React.ChangeEvent<HTMLInputElement>) => {
    const values:Array<any> = [...telefone];
    values[index][e.target.name] = e.target.value;
    setTelefone(values);
  };

  // const handleServiceChange = (e: React.ChangeEvent<HTMLInputElement>, index:number) => {
  //   const { name, value } = e.target;
  //   const list:Array<any> = [...serviceList];
  //   list[index][name] = value;
  //   setServiceList(list);
  // };

   // const onSubmitTelefone = async () => {
  //   await axios.post("https://localhost:5001/api/cadastro/v1/cadastroTelefone", telefone);
  // };

  useEffect(() => {
    clienteGetById();
  }, []);

  const onSubmit = async () => {
    await axios.put(`https://localhost:5001/api/cadastro/v1/updatecliente/${id}`, cliente);
    history.push("/");
  };

  const onSubmitTelefone = async (e:any) => {
    e.preventDefault();
    await axios.post("https://localhost:5001/api/cadastro/v1/cadastrotelefone", telefone);
    
  };

  const clienteGetById = async () => {
    const result = await axios.get(`https://localhost:5001/api/cadastro/v1/clientegetbyid/${id}`);
    setCliente(result.data);
  };


  const handleServiceAdd = () => {
    setTelefone([...telefone, {  numero: "",
    idCliente: "" }]);
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
          <br />
        </form>
        <br />
        <h4 className="text-center mb-4">Telefone</h4>
        <form onSubmit={handleSubmit(onSubmitTelefone)}>
        {telefone.map((telefoneService, index) =>(
            <div key={index}>
            <div className="form-group">
             <input
              type="text"
              className="form-control form-control-lg"
              placeholder="Insira seu Telefone"
              name="numero"
              value={telefoneService.numero}
              onChange={e => onInputChangeTelefone(index,e)}
              />
              <br />
              <input 
                  type="text"
                  readOnly
                  className="form-control form-control-lg"
                  name="idCliente"
                  value={telefoneService.idCliente = id}
                  onChange={(e) => onInputChangeTelefone(index,e)}
                   />
            </div>
            <br />
            {telefone.length - 1 === index && telefone.length < 4 && (
                <button
                  type="button"
                  onClick={handleServiceAdd}
                  className="btn btn-success"
                >
                  <span>+</span>
                </button>
              )}
          </div>
          ))}
          <br />
          <button className="btn btn-warning btn-block" onClick={onSubmitTelefone}>Adicionar Telefone</button>
          </form>
      </div>
    </div>
  );
}

export default EditarCliente;