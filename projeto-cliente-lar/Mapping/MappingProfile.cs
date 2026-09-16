using AutoMapper;
using projeto_cliente_lar.DTO;
using projeto_cliente_lar.Entities;

namespace projeto_cliente_lar.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PessoaRequest, Pessoa>().ReverseMap();
            CreateMap<TelefoneRequest, Telefone>().ReverseMap();
        }
    }
}
