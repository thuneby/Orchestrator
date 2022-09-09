using AutoMapper;
using Core.Models;

namespace Core.Mapping
{
    public class TextMapperBase<T1, T2>
        where T1 : TextModelBase
        where T2 : TenantModelBase
    {
        private readonly IMapper _mapper;

        public TextMapperBase()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            _mapper = config.CreateMapper();
        }
        
        public static T2 GetRecord(T1 record)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<T1, T2>(record);
            return result;
        }

        public static T2 GetRecord(T1 record, Tenant tenant)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<T1, T2>(record);
            result.TenantÍd = tenant.Id;
            return result;
        }

        public T2 Map(T1 record) 
        {
            var result = _mapper.Map<T1, T2>(record);
            return result;
        }
    }
}
