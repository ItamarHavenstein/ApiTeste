﻿namespace Cadastro
{
    public class CidadeServicos
    {
        private CidadeAdaptador CidadeAdapt;
        private CidadeValidador CidadeVali;
        private ICidadeRepositorio CidadeRepo;

        public CidadeServicos(CidadeAdaptador cidadeAdapt,CidadeValidador cidadeVali, ICidadeRepositorio cidadeRepo)
        {
            CidadeAdapt = cidadeAdapt;
            CidadeVali = cidadeVali;
            CidadeRepo = cidadeRepo;
        }

        public ResultadoOperacao InserirCidade(CidadeDTO cidade)
        {
            var novo = new Cidade();
            CidadeAdapt.AdaptInserir(cidade, novo);

            var resposta = CidadeVali.Validar(novo);
            if (!resposta.GetValido())
            {
                return resposta;
            }

            CidadeRepo.Inserir(novo);
            CidadeRepo.Commit();
            return resposta;
        }
    }
}
