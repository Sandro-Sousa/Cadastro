export interface IParam {
  id: string;
}

export type Inputs = {
  nome: string;
  cpf: string;
  ddd: string;
  numero: string;
};

export interface ITelefone {
  telefoneId: number;
  clienteId: number;
  ddd: string;
  numero: string;
}

export interface IEndereco {
  EnderecoId: number;
  logradouro: string;
  bairro: string;
  cidade: string;
  uf: string;
  clienteId: number;
}

export interface IEmail {
  emailId: number;
  _Email: string;
  clienteId: number;
}