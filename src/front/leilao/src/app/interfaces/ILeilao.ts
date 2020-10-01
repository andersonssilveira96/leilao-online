export interface ILeilao {
    id: string;
    nome: string;
    valorInicial: number; 
    usado: boolean; 
    usuarioResponsavelId: string; 
    usuario: string; 
    dataAbertura: Date;
    dataFinalizacao: Date;
    encerrado: boolean;
}